Imports risersoft.app.mxform.talent

Public Class frmCourse
    Inherits frmMax
    Friend fMat As frmCourseContent
    Dim myVueUsers As New clsWinView

    Private Sub InitForm()
        WinFormUtils.SetButtonConf(Me.btnOk, Me.btnCancel, Me.btnSave)
        myView.SetGrid(Me.UltraGridSkill)
        myVueUsers.SetGrid(Me.UltraGridUsers)
    End Sub

    Public Overrides Function PrepForm(oView As clsWinView, ByVal prepMode As EnumfrmMode, ByVal prepIdx As String, Optional ByVal strXML As String = "") As Boolean
        Me.FormPrepared = False

        Dim objModel As frmCourseModel = Me.InitData("frmCourseModel", oView, prepMode, prepIDX, strXML)
        If Me.BindModel(objModel, oView) Then

            Me.CtlRTFDescrip.HTMLText = myUtils.cStrTN(myRow("DescriptionHTML"))

            Me.UltraTabControl2.Tabs("Assign").Visible = False
            If Me.frmMode = EnumfrmMode.acAddM Then
                Me.UltraTabControl2.Tabs("Assign").Visible = True
            End If

            Me.FormPrepared = True

        End If
        Return Me.FormPrepared
    End Function

    Public Overrides Function BindModel(NewModel As clsFormDataModel, oView As clsView) As Boolean
        If MyBase.BindModel(NewModel, oView) Then
            myView.PrepEdit(Me.Model.GridViews("Skill"),, btn_DeleteSkill)
            myWinSQL.AssignCmb(Me.dsCombo, "Category", "", Me.cmb_CourseCatID)
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

    Private Sub btn_AddSkill_Click(sender As Object, e As EventArgs) Handles btn_AddSkill.Click
        Dim Params As New List(Of clsSQLParam)
        Dim str1 As String = myUtils.MakeCSV(myView.mainGrid.myDS.Tables(0).Select, "Skillcode", ",", "''", True)
        Params.Add(New clsSQLParam("@SkillCSV", str1, GetType(String), True))

        Dim Model As clsViewModel = Me.GenerateParamsModel("skill", Params)
        Dim fG As New frmGrid
        fG.myView.PrepEdit(Model)
        If fG.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            Dim rr() As DataRow = fG.myView.mainGrid.myDS.Tables(0).Select("sysincl=1")
            Me.Controller.Data.CopySelectedRows(myView.mainGrid.myDS.Tables(0), rr, "Skillcode", True)
        End If

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