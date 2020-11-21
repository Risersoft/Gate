Imports System.Windows.Forms
Imports risersoft.app.mxform.talent

Public Class frmAssessSurveyView
    Inherits frmMax
    Dim f As New frmTestQuestionView

    Private Sub InitForm()
        f.AddToPanel(Me.Panel2, True, DockStyle.Fill)
        WinFormUtils.SetButtonConf(Me.btnOk, Me.btnCancel, Me.btnSave)

    End Sub

    Public Overrides Function PrepForm(oView As clsWinView, ByVal prepMode As EnumfrmMode, ByVal prepIdx As String, Optional ByVal strXML As String = "") As Boolean
        Me.FormPrepared = False

        Dim objModel As frmAssessSurveyViewModel = Me.InitData("frmAssessSurveyViewModel", oView, prepMode, prepIDX, strXML)
        If Me.BindModel(objModel, oView) Then

            Dim TestQuestionID = Me.GetNextTestQuestionID(0).ID
            f.PrepForm(oView, EnumfrmMode.acEditM, TestQuestionID, "<PARAMS AssessUserID= """ & myUtils.cValTN(myRow("AssessUserID")) & """/>")

            If myUtils.NullNot(f.myRow("QuestionType")) Then
                btnSubmit.Visible = False
            Else
                btnSubmit.Visible = True
            End If

            If myUtils.cValTN(myRow("CourseID")) > 0 Then
                Me.cmb_CourseID.Visible = True
                UltraLabel4.Visible = True
                Me.cmb_CourseID.Value = myUtils.cValTN(Me.vBag("CourseID"))
            Else
                Me.cmb_CourseID.Visible = False
                UltraLabel4.Visible = False
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

    Protected Friend Function GetNextTestQuestionID(ExistingTestQuestionID As Integer) As clsProcOutput
        Dim Params As New List(Of clsSQLParam)
        Params.Add(New clsSQLParam("@AssessSurveyID", myUtils.cValTN(myRow("AssessSurveyID")), GetType(Integer), True))
        Params.Add(New clsSQLParam("@TestQuestionID", ExistingTestQuestionID, GetType(Integer), True))
        Dim oRet As clsProcOutput = Me.GenerateParamsOutput("testquestion", Params)
        Return oRet
    End Function

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim oRet = Me.GetNextTestQuestionID(f.frmIDX)
        If oRet.Success Then
            f.VSave()
            f.PrepForm(pView, EnumfrmMode.acEditM, oRet.ID)
        Else
            MsgBox(oRet.Message, MsgBoxStyle.Information, myWinApp.Vars("appname"))
        End If
    End Sub

End Class