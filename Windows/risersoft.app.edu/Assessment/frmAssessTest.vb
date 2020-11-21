Imports risersoft.app.mxform.talent

Public Class frmAssessTest
    Inherits frmMax
    Friend fMat As frmCourseContent
    Dim oSort As clsWinSort
    Dim myVueUsers As New clsWinView

    Private Sub InitForm()
        myView.SetGrid(Me.UltraGridQuestion)
        myVueUsers.SetGrid(Me.UltraGridUsers)

        WinFormUtils.SetButtonConf(Me.btnOk, Me.btnCancel, Me.btnSave)
        oSort = New clsWinSort(myView, Me.btnMoveUp, Me.btnMoveDown, Nothing, "sortindex")

    End Sub

    Public Overrides Function PrepForm(oView As clsWinView, ByVal prepMode As EnumfrmMode, ByVal prepIdx As String, Optional ByVal strXML As String = "") As Boolean
        Me.FormPrepared = False

        Dim objModel As frmAssessTestModel = Me.InitData("frmAssessTestModel", oView, prepMode, prepIDX, strXML)
        If Me.BindModel(objModel, oView) Then

            If myUtils.cValTN(myRow("CourseID")) > 0 Then
                Me.cmb_CourseID.Visible = True
                Label9.Visible = True
                Me.cmb_CourseID.Value = myUtils.cValTN(Me.vBag("CourseID"))
            Else
                Me.cmb_CourseID.Visible = False
                Label9.Visible = False
            End If

            txt_MaxAttempts.Visible = False
            oSort.renumber()

            Me.CtlRTFDescrip.HTMLText = myUtils.cStrTN(myRow("DescriptionHTML"))

            Me.UltraTabControl1.Tabs("Assign").Visible = False

            If Me.frmMode = EnumfrmMode.acAddM Then
                Me.UltraTabControl1.Tabs("Assign").Visible = True
            End If

            Me.FormPrepared = True

            End If
            Return Me.FormPrepared
    End Function

    Public Overrides Function BindModel(NewModel As clsFormDataModel, oView As clsView) As Boolean
        If MyBase.BindModel(NewModel, oView) Then
            myView.PrepEdit(Me.Model.GridViews("Question"),, btnDelete)
            myWinSQL.AssignCmb(Me.dsCombo, "Course", "", Me.cmb_CourseID)
            myVueUsers.PrepEdit(Me.Model.GridViews("Users"),, Me.btnDelUser)

            Return True
        End If
        Return False
    End Function

    Public Overrides Function VSave() As Boolean
        VSave = False
        If Me.ValidateData() Then
            cm.EndCurrentEdit()
            myRow("DescriptionHTML") = Me.CtlRTFDescrip.HTMLText
            myRow("DescriptionText") = Me.CtlRTFDescrip.PlainText
            If Me.SaveModel() Then
                Return True
            End If
        Else
            Me.SetError()
        End If
        Me.Refresh()

    End Function

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim Params As New List(Of clsSQLParam)
        Params.Add(New clsSQLParam("@QuestionIDcsv", myUtils.MakeCSV(Me.myView.mainGrid.myDS.Tables(0).Select, "TestQuestionID"), GetType(Integer), True))
        Dim rr() As DataRow = Me.AdvancedSelect("question", Params)
        If (rr IsNot Nothing) AndAlso (rr.Length > 0) Then
            Me.Controller.Data.CopySelectedRows(myView.mainGrid.myDS.Tables(0), rr, "TestQuestionID", False)
            oSort.renumber()
        End If

    End Sub

    Private Sub MultipleChoiceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MultipleChoiceToolStripMenuItem.Click
        If Me.frmMode = EnumfrmMode.acEditM Then
            Dim f As New frmTestQuestion
            f.fMat = Me
            Dim strXML = $"<PARAMS QuestionType=""MCQ"" AssessTestID=""{frmIDX}"" CourseID=""{myUtils.cValTN(myRow("CourseID"))}""/>"
            If f.PrepForm(Me.myView, EnumfrmMode.acAddM, frmIDX, strXML) Then
                If f.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Me.AddQuestion(f.myRow.Row)
                End If
            End If
        Else
            MsgBox("You need to save first before proceeding ..", MsgBoxStyle.Information, myWinApp.Vars("AppName"))
        End If
    End Sub

    Private Sub FillTheGapToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FillTheGapToolStripMenuItem.Click
        If Me.frmMode = EnumfrmMode.acEditM Then
            Dim f As New frmTestQuestion
            f.fMat = Me
            Dim strXML = $"<PARAMS QuestionType=""FTG"" AssessTestID=""{frmIDX}"" CourseID=""{myUtils.cValTN(myRow("CourseID"))}""/>"
            If f.PrepForm(Me.myView, EnumfrmMode.acAddM, frmIDX, strXML) Then
                If f.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Me.AddQuestion(f.myRow.Row)
                End If
            End If
        Else
            MsgBox("You need to save first before proceeding ..", MsgBoxStyle.Information, myWinApp.Vars("AppName"))
        End If
    End Sub

    Private Sub OrderingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OrderingToolStripMenuItem.Click
        If Me.frmMode = EnumfrmMode.acEditM Then
            Dim f As New frmTestQuestion
            f.fMat = Me
            Dim strXML = $"<PARAMS QuestionType=""ODR"" AssessTestID=""{frmIDX}"" CourseID=""{myUtils.cValTN(myRow("CourseID"))}""/>"
            If f.PrepForm(Me.myView, EnumfrmMode.acAddM, frmIDX, strXML) Then
                If f.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Me.AddQuestion(f.myRow.Row)
                End If
            End If
        Else
            MsgBox("You need to save first before proceeding ..", MsgBoxStyle.Information, myWinApp.Vars("AppName"))
        End If
    End Sub

    Private Sub PairingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PairingToolStripMenuItem.Click
        If Me.frmMode = EnumfrmMode.acEditM Then
            Dim f As New frmTestQuestion
            f.fMat = Me
            Dim strXML = $"<PARAMS QuestionType=""PAIR"" AssessTestID=""{frmIDX}"" CourseID=""{myUtils.cValTN(myRow("CourseID"))}""/>"
            If f.PrepForm(Me.myView, EnumfrmMode.acAddM, frmIDX, strXML) Then
                If f.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Me.AddQuestion(f.myRow.Row)
                End If
            End If
        Else
            MsgBox("You need to save first before proceeding ..", MsgBoxStyle.Information, myWinApp.Vars("AppName"))
        End If
    End Sub

    Private Sub FreeTextToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FreeTextToolStripMenuItem.Click
        If Me.frmMode = EnumfrmMode.acEditM Then
            Dim f As New frmTestQuestion
            f.fMat = Me
            Dim strXML = $"<PARAMS QuestionType=""TXT"" AssessTestID=""{frmIDX}"" CourseID=""{myUtils.cValTN(myRow("CourseID"))}""/>"
            If f.PrepForm(Me.myView, EnumfrmMode.acAddM, frmIDX, strXML) Then
                If f.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Me.AddQuestion(f.myRow.Row)
                End If
            End If
        Else
            MsgBox("You need to save first before proceeding ..", MsgBoxStyle.Information, myWinApp.Vars("AppName"))
        End If
    End Sub

    Private Sub chk_Repeat_Max_Attempts_CheckedChanged(sender As Object, e As EventArgs) Handles chk_Repeat_Max_Attempts.CheckedChanged
        If chk_Repeat_Max_Attempts.CheckState = 1 Then
            txt_MaxAttempts.Visible = True
        Else
            txt_MaxAttempts.Visible = False
        End If
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Dim f As New frmTestQuestion
        f.fMat = Me
        myView.ContextRow = myView.mainGrid.ActiveRow
        If Not myView.ContextRow Is Nothing Then
            Dim strXML = $"<PARAMS QuestionType= ""{Me.myView.mainGrid.myGrid.ActiveRow.Cells("QuestionType").Value}"" AssessSurveyID=""{frmIDX}"" CourseID=""{myUtils.cValTN(myRow("CourseID"))}""/>"
            If f.PrepForm(Me.myView, EnumfrmMode.acEditM, frmIDX, strXML) Then
                If f.ShowDialog = Windows.Forms.DialogResult.OK Then
                    myView.ContextRow.CellValue("QuestionHTML") = f.myRow("QuestionHTML")
                    myView.ContextRow.CellValue("QuestionText") = f.myRow("QuestionText")
                End If

            End If
        End If
    End Sub

    Private Sub AddQuestion(rQues As DataRow)

        Dim nr As DataRow = myView.mainGrid.myDS.Tables(0).NewRow
        'Add some data to it

        nr("TestQuestionID") = rQues("TestQuestionID")
        nr("AssessTestID") = frmIDX
        nr("QuestionType") = rQues("QuestionType")
        nr("QuestionText") = rQues("QuestionText")
        'Add New Row in DataTable
        myView.mainGrid.myDS.Tables(0).Rows.Add(nr)

    End Sub

    Private Sub btnAddUser_Click(sender As Object, e As EventArgs) Handles btnAddUser.Click
        Dim Params As New List(Of clsSQLParam)
        Dim str1 As String = myUtils.MakeCSV(myVueUsers.mainGrid.myDS.Tables(0).Select, "UserID", ",", "'00000000-0000-0000-0000-000000000000'", True)
        Params.Add(New clsSQLParam("@UserIDcsv", str1, GetType(Guid), True))
        Dim rr() As DataRow = Me.AdvancedSelect("user", Params)

        If Not IsNothing(rr) Then
            For Each r2 As DataRow In rr
                Dim r3 As DataRow = myUtils.CopyOneRow(r2, myVueUsers.mainGrid.myDS.Tables(0))
            Next
        End If
    End Sub

End Class