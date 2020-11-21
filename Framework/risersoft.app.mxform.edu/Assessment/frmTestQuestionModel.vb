Imports risersoft.shared
Imports risersoft.app.mxent
Imports Infragistics.Win
Imports System.Runtime.Serialization
Imports risersoft.shared.cloud
Imports risersoft.app.mxengg

<DataContract>
Public Class frmTestQuestionModel
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
        Dim Sql As String = "select CourseID, CourseName from Course order by CourseName"
        Me.AddLookupField("CourseID", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, Sql), "Course").TableName)

        Sql = "select codeword, descripshort from codewords where codetype='QuestionType' order by codeword"
        Me.AddLookupField("Questiontype", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, Sql), "Questiontype").TableName)

    End Sub

    Public Overrides Function PrepForm(oView As clsViewModel, ByVal prepMode As EnumfrmMode, ByVal prepIDX As String, Optional ByVal strXML As String = "") As Boolean
        Dim sql, str1 As String

        Me.FormPrepared = False
        If prepMode = EnumfrmMode.acAddM Then prepIDX = 0
        sql = "Select * from TestQuestion where TestQuestionID = " & prepIDX
        Me.InitData(sql, "QuestionType,AssessTestID,AssessSurveyID,CourseID", oView, prepMode, prepIDX, strXML)

        If prepMode = EnumfrmMode.acAddM AndAlso Me.vBag("AssessTestID") > 0 Then
            myRow("IsForSurvey") = False
        ElseIf prepMode = EnumfrmMode.acAddM AndAlso Me.vBag("AssessSurveyID") > 0 Then
            myRow("IsForSurvey") = True
        End If

        sql = "Select TestAnswerID, TestQuestionID, sortindex, AnswerText1, AnswerText2, IsCorrect, IsContained, NumPoints from Testanswer where TestQuestionID = " & frmIDX
        If Me.vBag("QuestionType") = "MCQ" Then
            myView.MainGrid.QuickConf(sql, True, "1-0-1-0-0", True)
            myView.MainGrid.MainConf("FORMATXML") = "<COL KEY=""AnswerText1"" CAPTION=""Answers""/><COL KEY=""IsCorrect"" CAPTION=""Correct"" VLIST=""True;Correct|False;Not Correct""/>"
        ElseIf myUtils.IsInList(Me.vbag("QuestionType"), "FTG", "FTB") Then
            myView.MainGrid.QuickConf(sql, True, "0-0-0-0-0", True)
        ElseIf Me.vBag("QuestionType") = "ODR" Then
            myView.MainGrid.QuickConf(sql, True, "1-0-0-0-0", True)
            myView.MainGrid.MainConf("FORMATXML") = "<COL KEY=""AnswerText1"" CAPTION=""Sentence""/>"
        ElseIf Me.vBag("QuestionType") = "PAIR" Then
            myView.MainGrid.QuickConf(sql, True, "1-1-0-0-0", True)
            myView.MainGrid.MainConf("FORMATXML") = "<COL KEY=""AnswerText1"" CAPTION=""Pair A""/><COL KEY=""AnswerText2"" CAPTION=""Pair B""/>"
        ElseIf Me.vBag("QuestionType") = "TXT" Then
            myView.MainGrid.QuickConf(sql, True, "1-0-0-1-1", True)
            myView.MainGrid.MainConf("FORMATXML") = "<COL KEY=""AnswerText1"" CAPTION=""The Word""/><COL KEY=""IsContained"" CAPTION=""When"" VLIST=""True;Contains|False;Not Contains""/><COL KEY=""NumPoints"" CAPTION=""Add Points""/>"
        End If
        str1 = "<BAND INDEX=""0"" TABLE=""TestAnswer"" IDFIELD=""TestAnswerID""><COL KEY=""TestQuestionID, sortindex, AnswerText1, AnswerText2, IsCorrect, IsContained, NumPoints""/></BAND> "
        myView.MainGrid.PrepEdit(str1, EnumEditType.acCommandAndEdit)

        myView.myCMain.SkipFormulaInj = True

        Me.FormPrepared = True

        Return Me.FormPrepared
    End Function

    Public Overrides Function Validate() As Boolean
        Me.InitError()
        myRow("QuestionHTML") = myFuncs.DecodeNormalizeHTML(myUtils.cStrTN(myRow("QuestionHTML")))
        myRow("QuestionText") = BucketUtility.TryBase64Decode(myUtils.cStrTN(myRow("QuestionText")))
        If myUtils.cStrTN(Me.myRow("QuestionHTML")).Trim.Length = 0 Then Me.AddError("QuestionHTML", "Enter Question")
        Select Case myUtils.cStrTN(myRow("QuestionType")).Trim.ToUpper
            Case "TXT"
                If myUtils.cValTN(Me.myRow("MinPoints")) = 0 Then Me.AddError("MinPoints", "Enter Minimum Point")
                myView.MainGrid.CheckValid("NumPoints", "AnswerText1")
            Case "MCQ"
                myView.MainGrid.CheckValid("AnswerText1")
                If (Not myUtils.cBoolTN(myRow("IsForSurvey"))) AndAlso myView.MainGrid.myDS.Tables(0).Select("iscorrect=1").Length = 0 Then Me.AddError("QuestionHTML", "At least one answer should be correct")
            Case "ODR"
                myView.MainGrid.CheckValid("AnswerText1")
            Case "PAIR"
                myView.MainGrid.CheckValid("AnswerText1,AnswerText2")
            Case "FTG", "FTB"
                If myUtils.InStrList(myRow("questiontext"), "~") Then Me.AddError("QuestionHTML", "~ character is not allowed")
        End Select
        Return Me.CanSave
    End Function

    Public Overrides Function VSave() As Boolean
        VSave = False
        If Me.Validate Then
            Dim TestQuestionDescrip As String = "Name: " & myRow("QuestionType").ToString
            Try
                myContext.Provider.dbConn.BeginTransaction(myContext, Me.Name, Me.frmMode.ToString, "TestQuestionID", frmIDX)
                myContext.Provider.objSQLHelper.SaveResults(myRow.Row.Table, Me.sqlForm)
                frmIDX = myRow("TestQuestionID")
                myView.MainGrid.SaveChanges(, "TestQuestionID=" & frmIDX)
                frmMode = EnumfrmMode.acEditM
                If myUtils.cValTN(Me.vBag("assesstestid")) > 0 OrElse myUtils.cValTN(Me.vBag("assesssurveyid")) > 0 Then
                    Dim strf1 = myUtils.CombineWhere(False, $"isnull(assesstestid,0)={myUtils.cValTN(Me.vBag("assesstestid"))}",
                                                    $"isnull(assesssurveyid,0)= {myUtils.cValTN(Me.vBag("assesssurveyID"))}")
                    Dim dic As New clsCollecString(Of String)
                    dic.Add("item", $"select * from testquestionitem where " & myUtils.CombineWhere(False, strf1, $"testquestionid={frmIDX}"))
                    dic.Add("index", $"select max(sortindex) as sortindex from testquestionitem where " & strf1)
                    Dim ds2 = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, dic)
                    Dim dt2 = ds2.Tables(0), nr As DataRow
                    If dt2.Rows.Count = 0 Then
                        nr = myContext.Tables.AddNewRow(dt2)
                        nr("sortindex") = myUtils.MaxVal(ds2.Tables(1), "sortindex") + 1
                    Else
                        nr = dt2.Rows(0)
                    End If
                    nr("assesstestid") = If(myUtils.cValTN(Me.vBag("assesstestid")) > 0, Me.vBag("assesstestid"), DBNull.Value)
                    nr("assesssurveyid") = If(myUtils.cValTN(Me.vBag("assesssurveyid")) > 0, Me.vBag("assesssurveyid"), DBNull.Value)
                    nr("testquestionid") = frmIDX
                    nr("isused") = True
                    myContext.Provider.objSQLHelper.SaveResults(dt2, dic(0))
                End If
                myContext.Provider.dbConn.CommitTransaction(TestQuestionDescrip, frmIDX)
                VSave = True
            Catch ex As Exception
                myContext.Provider.dbConn.RollBackTransaction(TestQuestionDescrip, ex.Message)
                Me.AddError("", ex.Message)
            End Try
        End If
        Return VSave
    End Function

    Public Overrides Function DeleteEntity(EntityKey As String, ID As Integer, AcceptWarning As Boolean) As clsProcOutput
        Dim oRet As New clsProcOutput
        Try
            If AcceptWarning Then
                Select Case EntityKey.Trim.ToLower
                    Case "testquestion"
                        Dim sql As String = "Select * from TestQuestion Where TestQuestionID =" & ID
                        Dim dt As DataTable = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql).Tables(0)

                        If dt.Rows.Count > 0 Then
                            Dim sql2 As String = "delete from testQuestionItem where testQuestionID =" & ID
                            myContext.Provider.objSQLHelper.ExecuteNonQuery(CommandType.Text, sql2)

                            Dim sql3 As String = "delete from testQuestionUser where testQuestionID =" & ID
                            myContext.Provider.objSQLHelper.ExecuteNonQuery(CommandType.Text, sql3)

                            Dim sql4 As String = "delete from testAnswer where testQuestionID =" & ID
                            myContext.Provider.objSQLHelper.ExecuteNonQuery(CommandType.Text, sql4)

                            Dim sql1 As String = "delete from TestQuestion where TestQuestionID =" & ID
                            myContext.Provider.objSQLHelper.ExecuteNonQuery(CommandType.Text, sql1)
                        End If

                End Select
            ElseIf oRet.WarningCount = 0 Then
                oRet.AddWarning("Are you sure ?")
            End If
        Catch ex As Exception
            oRet.AddException(ex)
        End Try
        Return oRet
    End Function

End Class

