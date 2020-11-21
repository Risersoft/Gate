Imports risersoft.app.mxform.talent

Public Class frmTestQuestion
    Inherits frmMax
    Friend fMat As frmAssessTest
    Friend fMat1 As frmAssessSurvey
    Dim oSort As clsWinSort

    Private Sub InitForm()
        myView.SetGrid(Me.UltraGridAnswers)
        WinFormUtils.SetButtonConf(Me.btnOk, Me.btnCancel, Me.btnSave)
        oSort = New clsWinSort(myView, btnMoveUp, btnMoveDown, Nothing, "SortIndex")

    End Sub

    Public Overrides Function PrepForm(oView As clsWinView, ByVal prepMode As EnumfrmMode, ByVal prepIdx As String, Optional ByVal strXML As String = "") As Boolean
        Me.FormPrepared = False

        Dim objModel As frmTestQuestionModel = Me.InitData("frmTestQuestionModel", oView, prepMode, prepIDX, strXML)
        If Me.BindModel(objModel, oView) Then

            If myUtils.cValTN(Me.vBag("CourseID")) > 0 Then
                Me.cmb_CourseID.Visible = True
                Label9.Visible = True
                Me.cmb_CourseID.Value = myUtils.cValTN(Me.vBag("CourseID"))
            Else
                Me.cmb_CourseID.Visible = False
                Label9.Visible = False
            End If

            Me.CtlRTFQuestion.EditEnabled = False
            Me.CtlRTFQuestion.HTMLText = myUtils.cStrTN(myRow("QuestionHTML"))

            If Me.vBag("QuestionType") = "ODR" Then
                btnMoveUp.Visible = True
                btnMoveDown.Visible = True
                oSort.renumber()
            Else
                btnMoveUp.Visible = False
                btnMoveDown.Visible = False
            End If

            Me.FormPrepared = True

        End If
        Return Me.FormPrepared
    End Function

    Public Overrides Function BindModel(NewModel As clsFormDataModel, oView As clsView) As Boolean
        If MyBase.BindModel(NewModel, oView) Then
            myView.PrepEdit(Me.Model.GridViews("Answers"), btn_AddAnswer, btn_DeleteAnswer)
            myWinSQL.AssignCmb(Me.dsCombo, "Course", "", Me.cmb_CourseID)
            myWinSQL.AssignCmb(Me.dsCombo, "Questiontype", "", Me.cmb_QuestionType)

            Return True
        End If
        Return False
    End Function

    Public Overrides Function VSave() As Boolean
        VSave = False
        If Me.ValidateData() Then
            cm.EndCurrentEdit()
            myRow("QuestionHTML") = Me.CtlRTFQuestion.HTMLText
            myRow("QuestionText") = Me.CtlRTFQuestion.PlainText
            If Me.SaveModel() Then
                Return True
            End If
        Else
            Me.SetError()
        End If
        Me.Refresh()

    End Function

End Class