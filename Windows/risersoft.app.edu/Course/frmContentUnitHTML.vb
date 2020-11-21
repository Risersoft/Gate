Imports risersoft.app.mxform.talent

Public Class frmContentUnitHTML
    Inherits frmMax
    Friend fMat As frmCourseContent

    Private Sub InitForm()
        WinFormUtils.SetButtonConf(Me.btnOk, Me.btnCancel, Me.btnSave)
    End Sub

    Public Overrides Function PrepForm(oView As clsWinView, ByVal prepMode As EnumfrmMode, ByVal prepIdx As String, Optional ByVal strXML As String = "") As Boolean
        Me.FormPrepared = False

        Dim objModel As frmContentUnitHTMLModel = Me.InitData("frmContentUnitHTMLModel", oView, prepMode, prepIDX, strXML)
        If Me.BindModel(objModel, oView) Then

            Dim dt As DataTable = Me.Model.DatasetCollection("Course").Tables("Course")
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                txt_CourseCode.Text = myUtils.cStrTN(dt.Rows(0)("CourseCode"))
                txt_CourseName.Text = myUtils.cStrTN(dt.Rows(0)("CourseName"))
                txt_Level.Text = myUtils.cStrTN(dt.Rows(0)("Level"))
                txt_TimeLimit.Text = myUtils.cStrTN(dt.Rows(0)("TimeLimit"))

            End If

            'Me.CtlRTFContent.EditEnabled = False
            Me.CtlRTFContent.HTMLText = myUtils.cStrTN(myRow("ContentHTML"))

            Me.FormPrepared = True

        End If
        Return Me.FormPrepared
    End Function

    Public Overrides Function BindModel(NewModel As clsFormDataModel, oView As clsView) As Boolean
        If MyBase.BindModel(NewModel, oView) Then
            'myView.PrepEdit(Me.Model.GridViews("Skill"),, btn_DeleteSkill)
            'myWinSQL.AssignCmb(Me.dsCombo, "Category", "", Me.cmb_CourseCatID)
            Return True
        End If
        Return False
    End Function

    Public Overrides Function VSave() As Boolean
        VSave = False
        If Me.ValidateData() Then
            cm.EndCurrentEdit()
            myRow("ContentHTML") = Me.CtlRTFContent.HTMLText
            myRow("ContentText") = Me.CtlRTFContent.PlainText
            If Me.SaveModel() Then
                Return True
            End If
        Else
            Me.SetError()
        End If
        Me.Refresh()

    End Function

End Class