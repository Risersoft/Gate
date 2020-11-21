Imports risersoft.app.mxform.talent

Public Class frmCourseContent
    Inherits frmMax
    Dim myVueFile As New clsWinView
    Dim oSort As clsWinSort

    Private Sub InitForm()
        myView.SetGrid(Me.UltraGridSkill)
        myVueFile.SetGrid(Me.UltraGridFile)
        WinFormUtils.SetButtonConf(Me.btnOk, Me.btnCancel, Me.btnSave)
        oSort = New clsWinSort(myView, Me.btn_MoveUp, Me.btn_MoveDown, Nothing, "sortindex")

    End Sub

    Public Overrides Function PrepForm(oView As clsWinView, ByVal prepMode As EnumfrmMode, ByVal prepIdx As String, Optional ByVal strXML As String = "") As Boolean
        Me.FormPrepared = False

        Dim objModel As frmCourseContentModel = Me.InitData("frmCourseContentModel", oView, prepMode, prepIDX, strXML)
        If Me.BindModel(objModel, oView) Then
            txt_CourseCode.Text = myUtils.cStrTN(myRow("CourseCode"))
            txt_CourseName.Text = myUtils.cStrTN(myRow("CourseName"))
            txt_Level.Text = myUtils.cStrTN(myRow("Level"))
            txt_TimeLimit.Text = myUtils.cStrTN(myRow("TimeLimit"))

            oSort.renumber()
            Me.FormPrepared = True

        End If
        Return Me.FormPrepared
    End Function

    Public Overrides Function BindModel(NewModel As clsFormDataModel, oView As clsView) As Boolean
        If MyBase.BindModel(NewModel, oView) Then
            myView.PrepEdit(Me.Model.GridViews("Content"),, btn_DelContent)
            myVueFile.PrepEdit(Me.Model.GridViews("File"))

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

    Private Sub ContentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ContentToolStripMenuItem.Click
        Dim f As New frmContentUnitHTML
        f.fMat = Me
        Dim strXML = $"<PARAMS ContentType=""HTML"" CourseID=""{frmIDX}""/>"
        If f.PrepForm(Me.myView, EnumfrmMode.acAddM, frmIDX, strXML) Then f.ShowDialog()
    End Sub

    Private Sub DocumentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DocumentToolStripMenuItem.Click
        Dim f As New frmContentUnitUpload
        f.fMat = Me
        Dim strXML = $"<PARAMS ContentType=""Upload"" DocType=""Document"" CourseID=""{frmIDX}""/>"
        If f.PrepForm(Me.myView, EnumfrmMode.acAddM, frmIDX, strXML) Then f.ShowDialog()
    End Sub

    Private Sub VideoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VideoToolStripMenuItem.Click
        Dim f As New frmContentUnitUpload
        f.fMat = Me
        Dim strXML = $"<PARAMS ContentType=""Upload"" DocType=""Video"" CourseID=""{frmIDX}""/>"
        If f.PrepForm(Me.myView, EnumfrmMode.acAddM, frmIDX, strXML) Then f.ShowDialog()
    End Sub

    Private Sub AudioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AudioToolStripMenuItem.Click
        Dim f As New frmContentUnitUpload
        f.fMat = Me
        Dim strXML = $"<PARAMS ContentType=""Upload"" DocType=""Audio"" CourseID=""{frmIDX}""/>"
        If f.PrepForm(Me.myView, EnumfrmMode.acAddM, frmIDX, strXML) Then f.ShowDialog()
    End Sub

    Private Sub PDFToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PDFToolStripMenuItem.Click
        Dim f As New frmContentUnitUpload
        f.fMat = Me
        Dim strXML = $"<PARAMS ContentType=""Upload"" DocType=""PDF"" CourseID=""{frmIDX}""/>"
        If f.PrepForm(Me.myView, EnumfrmMode.acAddM, frmIDX, strXML) Then f.ShowDialog()
    End Sub

    Private Sub PPTXToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PPTXToolStripMenuItem.Click
        Dim f As New frmContentUnitUpload
        f.fMat = Me
        Dim strXML = $"<PARAMS ContentType=""Upload"" DocType=""Presentation"" CourseID=""{frmIDX}""/>"
        If f.PrepForm(Me.myView, EnumfrmMode.acAddM, frmIDX, strXML) Then f.ShowDialog()
    End Sub

    Private Sub WebContentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WebContentToolStripMenuItem.Click
        Dim f As New frmContentUnitLink
        f.fMat = Me
        Dim strXML = $"<PARAMS ContentType=""Web"" DocType=""Content"" CourseID=""{frmIDX}""/>"
        If f.PrepForm(Me.myView, EnumfrmMode.acAddM, frmIDX, strXML) Then f.ShowDialog()
    End Sub

    Private Sub WebVideoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WebVideoToolStripMenuItem.Click
        Dim f As New frmContentUnitLink
        f.fMat = Me
        Dim strXML = $"<PARAMS ContentType=""Web"" DocType=""Video"" CourseID=""{frmIDX}""/>"
        If f.PrepForm(Me.myView, EnumfrmMode.acAddM, frmIDX, strXML) Then f.ShowDialog()
    End Sub

    Private Sub IFrameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IFrameToolStripMenuItem.Click
        Dim f As New frmContentUnitLink
        f.fMat = Me
        Dim strXML = $"<PARAMS ContentType=""Web"" DocType=""iFrame"" CourseID=""{frmIDX}""/>"
        If f.PrepForm(Me.myView, EnumfrmMode.acAddM, frmIDX, strXML) Then f.ShowDialog()
    End Sub

    Private Sub TestToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TestToolStripMenuItem.Click
        Dim f As New frmAssessTest
        f.fMat = Me
        Dim strXML = $"<PARAMS ContentType=""Test"" CourseID=""{frmIDX}""/>"
        If f.PrepForm(Me.myView, EnumfrmMode.acAddM, frmIDX, strXML) Then f.ShowDialog()
    End Sub

    Private Sub SurveyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SurveyToolStripMenuItem.Click
        Dim f As New frmAssessSurvey
        f.fMat = Me
        Dim strXML = $"<PARAMS ContentType=""Survey"" CourseID=""{frmIDX}""/>"
        If f.PrepForm(Me.myView, EnumfrmMode.acAddM, frmIDX, strXML) Then f.ShowDialog()
    End Sub

    Private Sub AssignmentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AssignmentToolStripMenuItem.Click
        Dim f As New frmAssessAssign
        f.fMat = Me
        Dim strXML = $"<PARAMS ContentType=""Assignment"" CourseID=""{frmIDX}""/>"
        If f.PrepForm(Me.myView, EnumfrmMode.acAddM, frmIDX, strXML) Then f.ShowDialog()
    End Sub

    Private Sub EditCourseInfoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditCourseInfoToolStripMenuItem.Click
        Dim f As New frmCourse
        f.fMat = Me
        If f.PrepForm(Me.myView, EnumfrmMode.acEditM, frmIDX) Then f.ShowDialog()
    End Sub

    Private Sub ViewAsLearnerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewAsLearnerToolStripMenuItem.Click
        Dim f As New frmCourseView
        f.fMat = Me
        If f.PrepForm(Me.myView, EnumfrmMode.acEditM, frmIDX) Then f.ShowDialog()
    End Sub

    Private Sub btn_AddFile_Click(sender As Object, e As EventArgs) Handles btn_AddFile.Click
        Dim f As New frmCourseFile
        f.fMat = Me
        If f.PrepForm(myVueFile, EnumfrmMode.acAddM, "", "") Then f.ShowDialog()
    End Sub

    Private Sub btn_EditFile_Click(sender As Object, e As EventArgs) Handles btn_EditFile.Click
        Dim f As New frmCourseFile
        myVueFile.ContextRow = myVueFile.mainGrid.ActiveRow
        f.fMat = Me
        If f.PrepForm(Me.myVueFile, EnumfrmMode.acEditM, myUtils.cValTN(myWinUtils.DataRowFromGridRow(myVueFile.mainGrid.ActiveRow.Row)("CourseFileID"))) Then f.ShowDialog()
        Me.Refresh()

    End Sub

    Private Sub btn_EditContent_Click(sender As Object, e As EventArgs) Handles btn_EditContent.Click
        myView.ContextRow = myView.mainGrid.ActiveRow
        Dim r1 As DataRow = myWinUtils.DataRowFromGridRow(myView.mainGrid.myGrid.ActiveRow)
        If r1("ContentType") = "HTML" Then
            Dim f As New frmContentUnitHTML
            f.fMat = Me
            If f.PrepForm(Me.myView, EnumfrmMode.acEditM, myUtils.cValTN(r1("ContentUnitID"))) Then f.ShowDialog()
        ElseIf r1("ContentType") = "Upload" Then
                Dim f As New frmContentUnitUpload
                f.fMat = Me
            If f.PrepForm(Me.myView, EnumfrmMode.acEditM, myUtils.cValTN(r1("ContentUnitID"))) Then f.ShowDialog()
        ElseIf r1("ContentType") = "Web" Then
                Dim f As New frmContentUnitLink
                f.fMat = Me
            If f.PrepForm(Me.myView, EnumfrmMode.acEditM, myUtils.cValTN(r1("ContentUnitID"))) Then f.ShowDialog()
        End If

    End Sub

End Class