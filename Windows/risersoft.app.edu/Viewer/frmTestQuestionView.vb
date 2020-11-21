Imports risersoft.app.mxform.talent
Imports Infragistics.Win.UltraWinTabControl
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class frmTestQuestionView
    Inherits frmMax
    Dim oSort As clsWinSort

    Private Sub InitForm()
        myView.SetGrid(Me.UltraGridAnswers)
        Me.UltraTabControl1.Style = UltraTabControlStyle.Wizard
        oSort = New clsWinSort(myView, btnMoveUp, btnMoveDown, Nothing, "SortIndex")

    End Sub

    Public Overrides Function PrepForm(oView As clsWinView, ByVal prepMode As EnumfrmMode, ByVal prepIdx As String, Optional ByVal strXML As String = "") As Boolean
        Me.FormPrepared = False
        Dim objModel As frmTestQuestionViewModel = Me.InitData("frmTestQuestionViewModel", oView, prepMode, prepIdx, strXML)
        If Me.BindModel(objModel, oView) Then

            Me.CtlRTFQuestion.EditEnabled = False
            Me.CtlRTFQuestion.HTMLText = myUtils.cStrTN(myRow("QuestionHTML"))

            Dim dt As DataTable = Me.Model.DatasetCollection("tu").Tables(0)
            Me.CtlRTFText.HTMLText = myUtils.cStrTN(dt.Rows(0)("TestAnswerText"))

            If myRow("QuestionType") = "TXT" Then
                UltraTabControl1.Tabs("free").Selected = True
            Else
                UltraTabControl1.Tabs("ans").Selected = True
            End If

            If myRow("QuestionType") = "FTG" Then
                Me.FillUpsList()
            End If

            If myRow("QuestionType") = "ODR" Then
                UltraPanel4.Visible = True
                oSort.renumber()
            Else
                UltraPanel4.Visible = False
            End If

            Me.FormPrepared = True

        End If
        Return Me.FormPrepared
    End Function

    Friend Sub FillUpsList()
        Dim mGrid As UltraGrid = myView.mainGrid.myGrid

        For Each gRow1 As UltraGridRow In mGrid.Rows
            Dim str1 = myUtils.cStrTN(gRow1.Cells("list").Value).Trim
            If str1.Length > 0 Then
                Dim lst = New List(Of String)(Split(str1, "|"))
                Dim vlist = myWinUtils.PerCellVlist(myView.mainGrid, gRow1.Cells("Answer"), lst)
            End If

        Next
    End Sub

    Public Overrides Function BindModel(NewModel As clsFormDataModel, oView As clsView) As Boolean
        If MyBase.BindModel(NewModel, oView) Then
            myView.PrepEdit(Me.Model.GridViews("Answers"))
            Return True
        End If
        Return False
    End Function

    Public Overrides Function VSave() As Boolean
        VSave = False
        If Me.ValidateData() Then
            cm.EndCurrentEdit()

            Dim ds As DataSet = Me.Model.DatasetCollection("tu")
            Dim nr = ds.Tables("qu").Rows(0)
            If myRow("QuestionType") = "MCQ" Then
                nr("TestAnswerIDCSV") = myUtils.MakeCSV(myView.mainGrid.myDS.Tables(0).Select("sysincl = 1", "TestAnswerID"), "TestAnswerID")
            ElseIf myRow("QuestionType") = "ODR" Then
                nr("TestAnswerIDCSV") = myUtils.MakeCSV(myView.mainGrid.myDS.Tables(0).Select("", "sortindex"), "TestAnswerID")
            ElseIf myRow("QuestionType") = "PAIR" Then
                nr("TestAnswerIDCSV") = myUtils.MakeCSV(myView.mainGrid.myDS.Tables(0).Select("", "TestAnswerID"), "TestAnswerID")
            ElseIf myRow("QuestionType") = "FTG" Then
                nr("TestAnswerIDCSV") = myUtils.MakeCSV(myView.mainGrid.myDS.Tables(0).Select("", "snum"), "Answer")
            ElseIf myRow("QuestionType") = "TXT" Then
                nr("TestAnswerHTML") = Me.CtlRTFText.HTMLText
                nr("TestAnswerText") = Me.CtlRTFText.PlainText
            End If

            If Me.SaveModel() Then
                Return True
            End If
        Else
            Me.SetError()
        End If
        Me.Refresh()

    End Function

End Class
