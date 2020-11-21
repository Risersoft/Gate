Imports risersoft.app.mxform.talent

Public Class frmCourseUser
    Inherits frmMax

    Private Sub InitForm()
        myView.SetGrid(Me.UltraGridUsers)
        WinFormUtils.SetButtonConf(Me.btnOk, Me.btnCancel, Me.btnSave)
    End Sub

    Public Overrides Function PrepForm(oView As clsWinView, ByVal prepMode As EnumfrmMode, ByVal prepIdx As String, Optional ByVal strXML As String = "") As Boolean
        Me.FormPrepared = False
        Dim objModel As frmCourseUserModel = Me.InitData("frmCourseUserModel", oview, prepMode, prepIdx, strXML)
        If Me.BindModel(objModel, oview) Then

            txt_CourseCode.Text = myUtils.cStrTN(myRow("CourseCode"))
            txt_CourseName.Text = myUtils.cStrTN(myRow("CourseName"))
            txt_Level.Text = myUtils.cStrTN(myRow("Level"))
            txt_TimeLimit.Text = myUtils.cStrTN(myRow("TimeLimit"))

        End If
        Me.FormPrepared = True
        Return Me.FormPrepared

    End Function

    Public Overrides Function BindModel(NewModel As clsFormDataModel, oView As clsView) As Boolean
        If MyBase.BindModel(NewModel, oView) Then
            myView.PrepEdit(Me.Model.GridViews("Users"),, Me.btnDelUser)

            Return True
        End If
        Return False
    End Function

    Public Overrides Function VSave() As Boolean
        Me.InitError()
        VSave = False
        cm.EndCurrentEdit()
        If Me.ValidateData() Then
            If Me.CanSave() Then
                If Me.SaveModel() Then
                    Return True
                End If
            End If
        Else
            Me.SetError()
        End If
        Me.Refresh()
    End Function

    Private Sub btnAddUser_Click(sender As Object, e As EventArgs) Handles btnAddUser.Click
        Dim Params As New List(Of clsSQLParam)
        Dim str1 As String = myUtils.MakeCSV(myView.mainGrid.myDS.Tables(0).Select, "UserID", ",", "'00000000-0000-0000-0000-000000000000'", True)
        Params.Add(New clsSQLParam("@UserIDcsv", str1, GetType(Guid), True))
        Dim rr() As DataRow = Me.AdvancedSelect("user", Params)

        If Not IsNothing(rr) Then
            For Each r2 As DataRow In rr
                Dim r3 As DataRow = myUtils.CopyOneRow(r2, myView.mainGrid.myDS.Tables(0))
            Next
        End If
    End Sub

End Class
