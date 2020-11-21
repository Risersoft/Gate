Imports risersoft.app.mxform.talent
Imports Infragistics.Win.UltraWinTabControl

Public Class frmContentUnitView
    Inherits frmMax
    Friend fMat As frmCourseView
    Dim f1 As frmPDFView, f2 As IMxBrowser
    Dim oSort As clsWinSort

    Private Sub InitForm()
        'WinFormUtils.SetButtonConf(Me.btnOk, Me.btnCancel, Me.btnSave)

        f1 = New frmPDFView
        uTab = f1.AddtoTab(Me.UltraTabControl1, "upload", True)

        f2 = myWinApp.objAppExtender.fBrowser
        'uTab = f2.AddtoTab(Me.UltraTabControl1, "matlist", True)

        'f3 = New frmAssessTestView
        'uTab = f3.AddtoTab(Me.UltraTabControl1, "test", True)

        Me.UltraTabControl1.Style = UltraTabControlStyle.Wizard

    End Sub

    Public Overrides Function PrepForm(oView As clsWinView, ByVal prepMode As EnumfrmMode, ByVal prepIdx As String, Optional ByVal strXML As String = "") As Boolean
        Me.FormPrepared = False
        Dim objModel As frmContentUnitViewModel = Me.InitData("frmContentUnitViewModel", oView, prepMode, prepIDX, strXML)
        If Me.BindModel(objModel, oView) Then

            If frmIDX > 0 Then
                If myRow("ContentType") = "HTML" Then
                    Me.UltraTabControl1.Tabs("HTML").Selected = True
                    Me.CtlRTFHTML.HTMLText = myUtils.cStrTN(myRow("ContentHTML"))
                ElseIf myRow("ContentType") = "Upload" Then
                    Me.UltraTabControl1.Tabs("Upload").Selected = True
                    Me.CtlRTFUpload.HTMLText = myUtils.cStrTN(myRow("ContentHTML"))
                ElseIf myRow("ContentType") = "Web" Then
                    Me.UltraTabControl1.Tabs("Web").Selected = True
                    Me.CtlRTFWeb.HTMLText = myUtils.cStrTN(myRow("ContentHTML"))
                ElseIf myUtils.IsInList(myRow("ContentType"), "Test", "Survey", "Assignment") Then
                    Me.UltraTabControl1.Tabs("Assess").Selected = True
                    Me.HandleAssessment(myRow("ContentType"))
                End If
            End If

            Me.FormPrepared = True

        End If
        Return Me.FormPrepared
    End Function

    Public Overrides Function BindModel(NewModel As clsFormDataModel, oView As clsView) As Boolean
        If MyBase.BindModel(NewModel, oView) Then

            Return True
        End If
        Return False
    End Function

    Public Sub HandleAssessment(ContentType As String)
        btnContPrev.Visible = False
        btnStartNew.Visible = False
        btnStart.Visible = False

        Dim dt As DataTable = Me.Model.DatasetCollection("as").Tables(ContentType)
        If dt.Rows.Count = 0 Then
            btnStart.Visible = True
        Else
            btnContPrev.Visible = True
            btnStartNew.Visible = True
        End If
    End Sub
    Public Sub StartAssessment(StartType As String)
        Dim Params As New List(Of clsSQLParam)
        Params.Add(New clsSQLParam("@CourseID", myUtils.cValTN(myRow("CourseID")), GetType(Integer), False))
        Params.Add(New clsSQLParam("@TestID", myUtils.cValTN(myRow("AssessTestID")), GetType(Integer), False))
        Params.Add(New clsSQLParam("@SurveyID", myUtils.cValTN(myRow("AssessSurveyID")), GetType(Integer), False))
        Params.Add(New clsSQLParam("@AssignmentID", myUtils.cValTN(myRow("AssessAssignmentID")), GetType(Integer), False))
        Params.Add(New clsSQLParam("@StartType", "'" & StartType & "'", GetType(String), False))
        Select Case myRow("contenttype").ToString.Trim.ToLower
            Case "assignment"
                Dim oRet As clsProcOutput = Me.GenerateParamsOutput("assessuser", Params)
                If oRet.Success Then
                    Dim f3 As New frmAssessAssignView
                    If f3.PrepForm(pView, EnumfrmMode.acEditM, oRet.ID) Then f3.ShowDialog()
                Else
                    MsgBox(oRet.Message, MsgBoxStyle.Information, myWinApp.Vars("appname"))
                End If
            Case Else
                Dim oRet As clsProcOutput = Me.GenerateParamsOutput("testquestion", Params)
                If oRet.Success Then
                    Dim strXML As String = $"<PARAMS ASSESSUSERID=""{oRet.IDList(0)}""/>"
                    Dim f3 As New frmTestQuestionView
                    If f3.PrepForm(pView, EnumfrmMode.acEditM, oRet.ID, strXML) Then f3.ShowDialog()
                Else
                    MsgBox(oRet.Message, MsgBoxStyle.Information, myWinApp.Vars("appname"))
                End If

        End Select

    End Sub
    Private Sub btnContPrev_Click(sender As Object, e As EventArgs) Handles btnContPrev.Click
        Me.StartAssessment("contprev")

    End Sub

    Private Sub btnStartNew_Click(sender As Object, e As EventArgs) Handles btnStartNew.Click
        Me.StartAssessment("startnew")

    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        Me.StartAssessment("start")

    End Sub

    Public Overrides Function VSave() As Boolean
        VSave = False
        If Me.ValidateData() Then
            cm.EndCurrentEdit()
            If Me.SaveModel() Then
                Return True
            End If
        Else
            Me.SetError()
        End If
        Me.Refresh()

    End Function

    Protected Friend Function GetNextContentUnitID(ExistingContentUnitID As Integer) As clsProcOutput
        Dim Params As New List(Of clsSQLParam)
        Params.Add(New clsSQLParam("@CourseID", myUtils.cValTN(myRow("CourseID")), GetType(Integer), False))
        Params.Add(New clsSQLParam("@ContentUnitID", myUtils.cValTN(myRow("ContentUnitID")), GetType(Integer), False))
        Dim oRet As clsProcOutput = Me.GenerateParamsOutput("contentunit", Params)
        Return oRet
    End Function

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Dim oRet = Me.GetNextContentUnitID(Me.frmIDX)
        If oRet.Success Then
            Me.PrepForm(pView, EnumfrmMode.acEditM, oRet.ID)
        Else
            MsgBox(oRet.Message, MsgBoxStyle.Information, myWinApp.Vars("appname"))
        End If
    End Sub

End Class