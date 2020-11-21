Imports risersoft.app.mxform.talent
Imports risersoft.shared.dotnetfx
Public Class frmAssessAssign
    Inherits frmMax
    Friend fMat As frmCourseContent
    Dim myVueUsers As New clsWinView

    Private Sub InitForm()
        WinFormUtils.SetButtonConf(Me.btnOk, Me.btnCancel, Me.btnSave)
        myVueUsers.SetGrid(Me.UltraGridUsers)
    End Sub

    Public Overrides Function PrepForm(oView As clsWinView, ByVal prepMode As EnumfrmMode, ByVal prepIdx As String, Optional ByVal strXML As String = "") As Boolean
        Me.FormPrepared = False

        Dim objModel As frmAssessAssignModel = Me.InitData("frmAssessAssignModel", oView, prepMode, prepIDX, strXML)
        If Me.BindModel(objModel, oView) Then

            If myUtils.cValTN(myRow("CourseID")) > 0 Then
                Me.cmb_CourseID.Visible = True
                LabelCourse.Visible = True
                Me.cmb_CourseID.Value = myUtils.cValTN(Me.vBag("CourseID"))
            Else
                Me.cmb_CourseID.Visible = False
                LabelCourse.Visible = False
            End If

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
            myWinSQL.AssignCmb(Me.dsCombo, "Course", "", Me.cmb_CourseID)
            Me.cmb_CompletionSubmit.ValueList = Me.Model.ValueLists("CompletionSubmit").ComboList
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