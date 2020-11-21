Imports System.Windows.Forms
Imports risersoft.app.mxform.talent

Public Class frmCourseView
    Inherits frmMax
    Dim f As New frmContentUnitView
    Friend fMat As frmCourseContent

    Private Sub InitForm()
        myView.SetGrid(Me.UltraGridList)
    End Sub

    Public Overrides Function PrepForm(oView As clsWinView, ByVal prepMode As EnumfrmMode, ByVal prepIdx As String, Optional ByVal strXML As String = "") As Boolean
        Me.FormPrepared = False

        Dim objModel As frmCourseViewModel = Me.InitData("frmCourseViewModel", oView, prepMode, prepIdx, strXML)
        If Me.BindModel(objModel, oView) Then

            txt_CourseCode.Text = myUtils.cStrTN(myRow("CourseCode"))
            txt_CourseName.Text = myUtils.cStrTN(myRow("CourseName"))
            txt_Level.Text = myUtils.cStrTN(myRow("Level"))
            txt_TimeLimit.Text = myUtils.cStrTN(myRow("TimeLimit"))

            Me.FormPrepared = True

        End If
        Return Me.FormPrepared
    End Function

    Public Overrides Function BindModel(NewModel As clsFormDataModel, oView As clsView) As Boolean
        If MyBase.BindModel(NewModel, oView) Then
            myView.PrepEdit(Me.Model.GridViews("ContentList"))

            Return True
        End If
        Return False
    End Function

    Public Overrides Function VSave() As Boolean
        VSave = False
        If Me.ValidateData() Then
            cm.EndCurrentEdit()
            f.VSave()
            If Me.SaveModel() Then
                Return True
            End If
        Else
            Me.SetError()
        End If
        Me.Refresh()

    End Function

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        Dim f As New frmContentUnitView
        f.fMat = Me
        Dim rUnit = myView.mainGrid.myDS.Tables(0).Select("", "sortindex")(0)
        If f.PrepForm(Me.myView, EnumfrmMode.acEditM, rUnit("ContentUnitID")) Then
            Me.Close()
            WinFormUtils.CentreForm(f)
        End If
    End Sub

    Private Sub btnContinue_Click(sender As Object, e As EventArgs) Handles btnContinue.Click
        Dim f As New frmContentUnitView
        f.fMat = Me
        Dim ContentUnitID As Integer
        If Not myUtils.NullNot(myRow("LastContentUnitID")) Then
            If myRow("LastContentUnitID") > 0 Then ContentUnitID = myRow("LastContentUnitID")
        Else
            Dim rUnit = myView.mainGrid.myDS.Tables(0).Select("", "sortindex")(0)
            ContentUnitID = rUnit("ContentUnitID")
        End If
        If f.PrepForm(Me.myView, EnumfrmMode.acEditM, ContentUnitID) Then
            Me.Close()
            WinFormUtils.CentreForm(f)
        End If
    End Sub

    Private Sub btnViewSelected_Click(sender As Object, e As EventArgs) Handles btnViewSelected.Click
        Dim f As New frmContentUnitView
        f.fMat = Me
        If Not IsNothing(myView.mainGrid.ActiveRow) Then
            Dim nr As DataRow = myUtils.DataRowFromGridRow(myView.mainGrid.ActiveRow)
            If f.PrepForm(Me.myView, EnumfrmMode.acEditM, nr("ContentUnitID")) Then
                Me.Close()
                WinFormUtils.CentreForm(f)
            End If
        End If
    End Sub



End Class



'Imports System.Windows.Forms
'Imports risersoft.app.mxform.talent

'Public Class frmCourseView
'    Inherits frmMax
'    Dim f As New frmContentUnitView
'    Friend fMat As frmCourseContent

'    Private Sub InitForm()
'        f.AddToPanel(Me.Panel2, True, DockStyle.Fill)
'        WinFormUtils.SetButtonConf(Me.btnOk, Me.btnCancel, Me.btnSave)

'    End Sub

'    Public Overrides Function PrepForm(oView As clsWinView, ByVal prepMode As EnumfrmMode, ByVal prepIdx As String, Optional ByVal strXML As String = "") As Boolean
'        Me.FormPrepared = False

'        Dim objModel As frmCourseViewModel = Me.InitData("frmCourseViewModel", oView, prepMode, prepIdx, strXML)
'        If Me.BindModel(objModel, oView) Then

'            Dim ContentUnitID = Me.GetNextContentUnitID(0).ID
'            f.PrepForm(oView, EnumfrmMode.acEditM, ContentUnitID)

'            txt_CourseCode.Text = myUtils.cStrTN(myRow("CourseCode"))
'            txt_CourseName.Text = myUtils.cStrTN(myRow("CourseName"))
'            txt_Level.Text = myUtils.cStrTN(myRow("Level"))
'            txt_TimeLimit.Text = myUtils.cStrTN(myRow("TimeLimit"))

'            Me.FormPrepared = True

'            End If
'            Return Me.FormPrepared
'    End Function

'    Public Overrides Function BindModel(NewModel As clsFormDataModel, oView As clsView) As Boolean
'        If MyBase.BindModel(NewModel, oView) Then
'            Return True
'        End If
'        Return False
'    End Function

'    Public Overrides Function VSave() As Boolean
'        VSave = False
'        If Me.ValidateData() Then
'            cm.EndCurrentEdit()
'            f.VSave()
'            If Me.SaveModel() Then
'                Return True
'            End If
'        Else
'            Me.SetError()
'        End If
'        Me.Refresh()

'    End Function

'    Protected Friend Function GetNextContentUnitID(ExistingContentUnitID As Integer) As clsProcOutput
'        Dim Params As New List(Of clsSQLParam)
'        Params.Add(New clsSQLParam("@CourseID", myUtils.cValTN(myRow("CourseID")), GetType(Integer), True))
'        Params.Add(New clsSQLParam("@ContentUnitID", ExistingContentUnitID, GetType(Integer), True))
'        Dim oRet As clsProcOutput = Me.GenerateParamsOutput("contentunit", Params)
'        Return oRet
'    End Function

'    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
'        Dim oRet = Me.GetNextContentUnitID(f.frmIDX)
'        If oRet.Success Then
'            f.PrepForm(pView, EnumfrmMode.acEditM, oRet.ID)
'        Else
'            MsgBox(oRet.Message, MsgBoxStyle.Information, myWinApp.Vars("appname"))
'        End If
'    End Sub

'End Class
