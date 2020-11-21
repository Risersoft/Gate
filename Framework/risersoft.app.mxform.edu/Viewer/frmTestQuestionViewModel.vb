Imports risersoft.shared
Imports risersoft.app.mxent
Imports Infragistics.Win
Imports System.Runtime.Serialization
Imports risersoft.shared.cloud
Imports risersoft.app.mxengg

<DataContract>
Public Class frmTestQuestionViewModel
    Inherits clsFormDataModel

    Protected Overrides Sub InitViews()
        myView = Me.GetViewModel("Answers")
    End Sub

    Public Sub New(context As IProviderContext)
        MyBase.New(context)
        Me.InitViews()
        Me.InitForm()
    End Sub

    Private Sub InitForm()
        Dim sql As String = "Select CourseCatID, CategoryName from CourseCat order by CategoryName"
        Me.AddLookupField("CourseCatID", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql), "Category").TableName)

        sql = "select codeword, descripshort from codewords where codetype='QuestionType' order by codeword"
        Me.AddLookupField("Questiontype", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql), "Questiontype").TableName)

        Me.IgnorefRow = True
    End Sub

    Public Overrides Function PrepForm(oView As clsViewModel, ByVal prepMode As EnumfrmMode, ByVal prepIDX As String, Optional ByVal strXML As String = "") As Boolean
        Dim sql, str1 As String, dic As New clsCollecString(Of String)

        Me.FormPrepared = False
        If prepMode = EnumfrmMode.acEditM Then
            sql = "Select * from TestQuestion where TestQuestionID = " & prepIDX
            Me.InitData(sql, "AssessUserID", oView, prepMode, prepIDX, strXML)

            'If Not myUtils.NullNot(myRow("QuestionType")) Then
            Dim strEdit As String = ""
            If myRow("QuestionType") = "MCQ" Then
                sql = "Select TestAnswerID, TestQuestionID, sortindex, AnswerText1 from Testanswer where TestQuestionID = " & frmIDX & " order by newid()"
                myView.Mode = EnumViewMode.acSelectM : myView.MultiSelect = True
                myView.MainGrid.QuickConf(sql, True, "1", True)
                myView.MainGrid.MainConf("FORMATXML") = "<COL KEY=""AnswerText1"" CAPTION=""Answers""/>"
                strEdit = "<BAND INDEX=""0"" ><COL KEY=""TestQuestionID, sortindex, AnswerText1""/></BAND> "
            ElseIf myRow("QuestionType") = "FTG" Then
                Dim dt As New DataTable("List")
                myRow("questionhtml") = Me.Fillups(myRow("questionhtml"), dt)
                myView.MainGrid.BindGridData(myUtils.MakeDSfromTable(dt, False))
                myView.MainGrid.QuickConf("", True, "1-4-0", True)
                strEdit = "<BAND INDEX=""0"" ><COL KEY=""Answer""/></BAND> "
            ElseIf myRow("QuestionType") = "FTB" Then
                Dim dt As New DataTable("List")
                myRow("questionhtml") = Me.Fillups(myRow("questionhtml"), dt)
                dt.Columns.Remove("List")
                myView.MainGrid.BindGridData(myUtils.MakeDSfromTable(dt, False))
                myView.MainGrid.QuickConf("", True, "1-4-0", True)
                strEdit = "<BAND INDEX=""0"" ><COL KEY=""Answer""/></BAND> "
            ElseIf myRow("QuestionType") = "ODR" Then
                sql = "Select TestAnswerID, TestQuestionID, sortindex, AnswerText1 from Testanswer where TestQuestionID = " & frmIDX & " ORDER BY NEWID()"
                myView.MainGrid.QuickConf(sql, True, "1", True)
                myView.MainGrid.MainConf("FORMATXML") = "<COL KEY=""AnswerText1"" CAPTION=""Sentence""/>"
                strEdit = "<BAND INDEX=""0"" ><COL KEY=""TestQuestionID, AnswerText1, AnswerText2""/></BAND> "
            ElseIf myRow("QuestionType") = "PAIR" Then
                sql = "Select TestAnswerID, TestQuestionID, sortindex, AnswerText1, AnswerText2 from Testanswer where TestQuestionID = " & frmIDX & " order by testanswerid"
                myView.MainGrid.QuickConf(sql, True, "1-1", True)
                Dim lst2 = myView.MainGrid.myDS.Tables(0).Select.Select(Function(r1) New KeyValuePair(Of Integer, String)(r1("testanswerid"), r1("answertext2"))).ToList
                Dim shuffled = myEduFuncs.ShuffleList(lst2), i As Integer = 0
                For Each r1 As DataRow In myView.MainGrid.myDS.Tables(0).Select
                    r1("testanswerid") = shuffled(i).Key
                    r1("answertext2") = shuffled(i).Value
                    i = i + 1
                Next
                myView.MainGrid.MainConf("FORMATXML") = $"<COL KEY=""AnswerText1"" CAPTION=""Pair A"" NOEDIT=""True""/><COL KEY=""AnswerText2"" CAPTION=""Pair B""/>"
                strEdit = "<BAND INDEX=""0"" ><COL KEY=""TestQuestionID, AnswerText1, AnswerText2""/></BAND> "
            End If
            myView.MainGrid.PrepEdit(strEdit, EnumEditType.acEditOnly)
            'End If

            Dim dic2 As New clsCollecString(Of String)
            dic2.Add("qu", "Select * from TestQuestionUser where TestQuestionID = " & frmIDX & " And UserID = '" & myContext.Police.UniqueUserID & "' and AssessuserID = " & myUtils.cValTN(Me.vBag("AssessUserID")))
            dic2.Add("au", "Select * from nlmslistAssessUser() where AssessuserID = " & myUtils.cValTN(Me.vBag("AssessUserID")))
            dic2.Add("qc", $"Select count(TestQuestionID) from TestQuestionUser where  TestQuestionID <> {frmIDX} And AssessUserID={myUtils.cValTN(Me.vBag("AssessUserID"))}")
            Dim ds = Me.AddDataSet("tu", dic2)

            Dim nr As DataRow
            If ds.Tables(0).Rows.Count > 0 Then
                'get first row
                nr = ds.Tables(0).Rows(0)
            Else
                nr = myContext.Tables.AddNewRow(ds.Tables(0))
                nr("TestQuestionID") = myRow("TestQuestionID")
                nr("UserID") = myContext.Police.UniqueUserID
                nr("questionnum") = myUtils.cValTN(ds.Tables("qc").Rows(0)(0)) + 1
            End If
            nr("AssessUserID") = myUtils.cValTN(Me.vBag("assessuserid"))
            ds.Tables("au").Rows(0)("lastquestionid") = frmIDX
            myContext.Provider.objSQLHelper.SaveResults(ds.Tables("qu"), dic2("qu"))
            myContext.Provider.objSQLHelper.SaveResults(ds.Tables("au"), "select assessuserid, lastquestionid from assessuser where 0=1")

            myView.myCMain.SkipFormulaInj = True
            Me.FormPrepared = True
        End If

        Return Me.FormPrepared
    End Function

    Public Function Fillups(str1 As String, dt As DataTable) As String
        Dim lst2 As New List(Of String), str2 As String
        Dim cnt As Integer = 0
        lst2 = XMLUtils.PrepSubstList(str1, "[", "]")
        dt.Columns.Clear()
        dt.Columns.Add("SNum", GetType(Integer))
        dt.Columns.Add("Answer", GetType(String))
        dt.Columns.Add("List", GetType(String))

        For Each str2 In lst2
            cnt = cnt + 1
            Dim nr As DataRow = dt.NewRow
            str1 = Replace(str1, str2, cnt)
            nr("snum") = cnt

            Dim shuffled = myEduFuncs.ShuffleList(Split(str2, "|").ToList)
            nr("list") = myUtils.MakeCSV(shuffled, "|")

            dt.Rows.Add(nr)
        Next
        Return str1

    End Function

    Public Overrides Function Validate() As Boolean
        Me.InitError()
        If Me.myRow("QuestionType").Trim.Length = 0 Then Me.AddError("QuestionType", "Enter Question Type")

        Return Me.CanSave
    End Function

    Public Overrides Function VSave() As Boolean
        Dim dic As New clsCollecString(Of String)
        VSave = False
        Dim AnswerIDCSV As String
        Dim ds As DataSet = Me.DatasetCollection("tu")
        ds.AcceptChanges()
        Dim rUserAns As DataRow = ds.Tables("qu").Rows(0)
        If myUtils.cValTN(rUserAns("testquestionuserid")) > 0 Then rUserAns.SetModified() Else rUserAns.SetAdded()
        rUserAns("timestamp") = Now

        Dim strf = myContext.SQL.GenerateSQLWhere(ds.Tables("au").Rows(0), "assesstestid", "AssessSurveyID")
        dic.Add("item", $"Select * from TestQuestionItem where " & myUtils.CombineWhere(False, $"TestQuestionID = {frmIDX}", strf))
        dic.Add("ans", $"Select * from TestAnswer where TestQuestionID = {frmIDX}")
        dic.Add("ques", "Select * from TestQuestion where TestQuestionID = " & frmIDX)
        Dim ds2 = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, dic)
        Dim rAssQues = ds2.Tables("item").Rows(0)
        Dim rQues = ds2.Tables("ques").Rows(0)

        If rQues("QuestionType") = "MCQ" Then
            AnswerIDCSV = myUtils.MakeCSV(ds2.Tables("ans").Select("iscorrect = 1", "TestAnswerID"), "TestAnswerID")
            Dim UserAnswerIDCSV = myUtils.MakeCSV(myUtils.cStrTN(rUserAns("TestAnswerIDCSV")).Split(",").OrderBy(Function(x) myUtils.cValTN(x)).ToList, ",")
            If AnswerIDCSV = UserAnswerIDCSV Then
                rUserAns("IsCorrect") = True
                If rUserAns("IsCorrect") = True Then
                    If (Not rAssQues Is Nothing) Then
                        rUserAns("score") = rAssQues("Weight")
                    End If
                Else
                    rUserAns("score") = 0
                End If
            End If
        ElseIf rQues("QuestionType") = "ODR" Then
            AnswerIDCSV = myUtils.MakeCSV(ds2.Tables("ans").Select("", "sortindex"), "TestAnswerID")
            If AnswerIDCSV = rUserAns("TestAnswerIDCSV") Then
                rUserAns("IsCorrect") = True
                If rUserAns("IsCorrect") = True Then
                    If (Not rAssQues Is Nothing) Then
                        rUserAns("score") = rAssQues("Weight")
                    End If
                Else
                    rUserAns("score") = 0
                End If
            End If
        ElseIf rQues("QuestionType") = "PAIR" Then
            AnswerIDCSV = myUtils.MakeCSV(ds2.Tables("ans").Select("", "TestAnswerID"), "TestAnswerID")
            If AnswerIDCSV = rUserAns("TestAnswerIDCSV") Then
                rUserAns("IsCorrect") = True
                If rUserAns("IsCorrect") = True Then
                    If (Not rAssQues Is Nothing) Then
                        rUserAns("score") = rAssQues("Weight")
                    End If
                Else
                    rUserAns("score") = 0
                End If
            End If
        ElseIf rQues("QuestionType") = "FTG" Then
            Dim lst2 = XMLUtils.PrepSubstList(rQues("QuestionText"), "[", "]")
            Dim AnsIDCSV() As String = Split(rUserAns("TestAnswerIDCSV"), "~")
            Dim numcorrect As Integer = 0

            For i As Integer = 0 To lst2.Count - 1
                Dim AnswerList() As String = Split(lst2(i), "|")
                If myUtils.IsInList(AnsIDCSV(i), AnswerList(0)) Then
                    numcorrect = numcorrect + 1
                End If
            Next

            If numcorrect = lst2.Count Then rUserAns("IsCorrect") = True
            If myUtils.cBoolTN(rUserAns("iscorrect")) Then rUserAns("score") = numcorrect / lst2.Count * rAssQues("Weight")
        ElseIf rQues("QuestionType") = "FTB" Then
            Dim lst2 = XMLUtils.PrepSubstList(rQues("QuestionText"), "[", "]")
            Dim AnsIDCSV() As String = Split(rUserAns("TestAnswerIDCSV"), ",")
            Dim numcorrect As Integer = 0

            For i As Integer = 0 To lst2.Count - 1
                Dim AnswerList() As String = Split(lst2(i), "|")
                If myUtils.IsInList(AnsIDCSV(i), AnswerList) Then
                    numcorrect = numcorrect + 1
                End If
            Next

            If numcorrect = lst2.Count Then rUserAns("IsCorrect") = True
            If myUtils.cBoolTN(rUserAns("iscorrect")) Then rUserAns("score") = numcorrect / lst2.Count * rAssQues("Weight")
        ElseIf rQues("QuestionType") = "TXT" Then
            Dim Score As Integer = 0, TotalScore As Integer = 0

            rUserAns("TestAnswerHTML") = myFuncs.DecodeNormalizeHTML(myUtils.cStrTN(rUserAns("TestAnswerHTML")))
            rUserAns("TestAnswerText") = BucketUtility.TryBase64Decode(myUtils.cStrTN(rUserAns("TestAnswerText")))

            For Each r2 As DataRow In ds2.Tables("ans").Select()
                If myUtils.cBoolTN(r2("iscontained")) AndAlso myUtils.InStrList(rUserAns("TestAnswerText"), r2("AnswerText1")) Then
                    Score = r2("numpoints")
                ElseIf (Not myUtils.cBoolTN(r2("iscontained"))) AndAlso (Not myUtils.InStrList(rUserAns("TestAnswerText"), r2("AnswerText1"))) Then
                    Score = r2("numpoints")
                End If
                TotalScore = TotalScore + Score
            Next
            If TotalScore >= rQues("Minpoints") Then
                rUserAns("IsCorrect") = True
                rUserAns("score") = rAssQues("Weight")
            End If

        End If

        If Me.Validate Then
            Dim QuestionDescrip As String = "Type: " & myRow("QuestionType").ToString
            Try
                myContext.Provider.dbConn.BeginTransaction(myContext, Me.Name, Me.frmMode.ToString, "TestQuestionID", frmIDX)

                myContext.Provider.objSQLHelper.SaveResults(Me.DatasetCollection("tu").Tables(0), "Select * from TestQuestionUser where TestQuestionID = " & frmIDX)

                frmIDX = myRow("TestQuestionID")
                'myView.MainGrid.SaveChanges(, "TestQuestionID=" & frmIDX)
                frmMode = EnumfrmMode.acEditM
                myContext.Provider.dbConn.CommitTransaction(QuestionDescrip, frmIDX)
                VSave = True
            Catch ex As Exception
                myContext.Provider.dbConn.RollBackTransaction(QuestionDescrip, ex.Message)
                Me.AddError("", ex.Message)
            End Try
        End If

        Return VSave
    End Function
    Public Overrides Function GenerateParamsOutput(dataKey As String, Params As List(Of clsSQLParam)) As clsProcOutput
        Dim oRet As clsProcOutput = myContext.SQL.ValidateSQLParams(Params)
        Dim TestID As Integer = myUtils.cValTN(myContext.SQL.ParamValue("@TestID", Params))
        Dim SurveyID As Integer = myUtils.cValTN(myContext.SQL.ParamValue("@SurveyID", Params))
        Dim TestQuestionID As Integer = myUtils.cValTN(myContext.SQL.ParamValue("@TestQuestionID", Params))
        Dim AssessUserID As Integer = myUtils.cValTN(myContext.SQL.ParamValue("@AssessUserID", Params))

        If oRet.Success Then
            Select Case dataKey.Trim.ToLower
                Case "testquestion"
                    oRet.ID = myEduFuncs.GetNextQuestionID(myContext, AssessUserID, TestID, SurveyID, TestQuestionID)
            End Select
        End If
        Return oRet
    End Function

End Class

