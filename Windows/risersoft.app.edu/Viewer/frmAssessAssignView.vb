Imports System.Windows.Forms
Imports risersoft.app.mxform.talent

Public Class frmAssessAssignView
    Inherits frmMax
    Dim f As New frmTestQuestionView

    Private Sub InitForm()
        f.AddToPanel(Me.Panel2, True, DockStyle.Fill)
        WinFormUtils.SetButtonConf(Me.btnOk, Me.btnCancel, Me.btnSave)

    End Sub

    Public Overrides Function PrepForm(oView As clsWinView, ByVal prepMode As EnumfrmMode, ByVal prepIdx As String, Optional ByVal strXML As String = "") As Boolean
        Me.FormPrepared = False

        Dim objModel As frmAssessAssignViewModel = Me.InitData("frmAssessAssignViewModel", oView, prepMode, prepIDX, strXML)
        If Me.BindModel(objModel, oView) Then

            Dim dt As DataTable = Me.Model.DatasetCollection("Assign").Tables(0)
            If dt.Rows.Count > 0 Then Me.CtlRTFQuestion.HTMLText = myUtils.cStrTN(dt.Rows(0)("QuestionHTML"))

            Me.CtlRTFAnswer.HTMLText = myUtils.cStrTN(myRow("AssignmentHTML"))

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

    Public Overrides Function VSave() As Boolean
        VSave = False
        If Me.ValidateData() Then
            cm.EndCurrentEdit()
            myRow("AssignmentHTML") = Me.CtlRTFAnswer.HTMLText
            myRow("AssignmentText") = Me.CtlRTFAnswer.PlainText
            If Me.SaveModel() Then
                Return True
            End If
        Else
            Me.SetError()
        End If
        Me.Refresh()

    End Function

End Class