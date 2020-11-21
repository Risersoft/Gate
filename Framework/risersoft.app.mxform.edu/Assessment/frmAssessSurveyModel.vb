Imports risersoft.shared
Imports risersoft.app.mxent
Imports Infragistics.Win
Imports System.Runtime.Serialization
Imports risersoft.shared.cloud
Imports risersoft.app.mxengg

<DataContract>
Public Class frmAssessSurveyModel
    Inherits clsFormDataModel
    Dim myVueUsers As New clsViewModel

    Protected Overrides Sub InitViews()
        myView = Me.GetViewModel("Question")
        myVueUsers = Me.GetViewModel("Users")
    End Sub

    Public Sub New(context As IProviderContext)
        MyBase.New(context)
        Me.InitViews()
        Me.InitForm()
    End Sub

    Private Sub InitForm()
        Dim Sql As String = "select CourseID, CourseName from Course order by CourseName"
        Me.AddLookupField("CourseID", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, Sql), "Course").TableName)

    End Sub

    Public Overrides Function PrepForm(oView As clsViewModel, ByVal prepMode As EnumfrmMode, ByVal prepIDX As String, Optional ByVal strXML As String = "") As Boolean
        Dim sql, str1 As String

        Me.FormPrepared = False
        If prepMode = EnumfrmMode.acAddM Then prepIDX = 0
        sql = "Select * from AssessSurvey where AssessSurveyID = " & prepIDX
        Me.InitData(sql, "CourseID", oView, prepMode, prepIDX, strXML)

        sql = "Select TestQuestionItemID, TestQuestionID, AssessSurveyID, sortindex, QuestionType, QuestionText, isused from nlmsListTestQuestionItem() where AssessSurveyID = " & frmIDX
        myView.MainGrid.QuickConf(sql, True, "1-1-1", True)
        str1 = "<BAND INDEX=""0"" TABLE=""TestQuestionItem"" IDFIELD=""TestQuestionItemID"" ><COL KEY=""TestQuestionID, AssessSurveyID, sortindex""/><COL KEY=""IsUsed"" CAPTION=""Used"" VLIST=""False;Unused|True;Used""/></BAND>"
        myView.MainGrid.PrepEdit(str1, EnumEditType.acCommandAndEdit)

        sql = "Select AssessUserID, AssessSurveyID, UserID, UserName, RoleCode, StartedOn, CompletedOn from nlmslistAssessUser() where AssessSurveyID = " & frmIDX & ""
        myVueUsers.MainGrid.MainConf("FORMATXML") = "<COL KEY=""RoleCode"" CAPTION=""Role""/>"
        myVueUsers.MainGrid.QuickConf(sql, True, "1.5-1-1-1", True)
        str1 = "<BAND INDEX=""0"" TABLE=""AssessUser"" IDFIELD=""AssessUserID""><COL KEY=""AssessSurveyID, UserID, StartedOn, CompletedOn""/><COL KEY=""RoleCode"" LOOKUPSQL=""" & myFuncsBase.CodeWordSQL("CourseRole", "Role", "") & """/></BAND>"
        myVueUsers.MainGrid.PrepEdit(str1, EnumEditType.acCommandAndEdit)

        Me.FormPrepared = True

        Return Me.FormPrepared
    End Function

    Public Overrides Function Validate() As Boolean
        Me.InitError()
        If myUtils.cStrTN(myRow("SurveyName")).Trim.Length = 0 Then Me.AddError("SurveyName", "Enter Survey Name")
        If myUtils.cValTN(myRow("courseid")) = 0 Then myVueUsers.MainGrid.CheckValid("userid,rolecode")
        Return Me.CanSave
    End Function

    Public Overrides Function VSave() As Boolean
        VSave = False

        myRow("DescriptionHTML") = myFuncs.DecodeNormalizeHTML(myUtils.cStrTN(myRow("DescriptionHTML")))
        myRow("DescriptionText") = BucketUtility.TryBase64Decode(myUtils.cStrTN(myRow("DescriptionText")))
        myRow("totalcount") = myView.MainGrid.myDS.Tables(0).Select.Length

        If Me.Validate Then
            Dim AssessTestDescrip As String = "Name: " & myRow("SurveyName").ToString
            Try
                myContext.Provider.dbConn.BeginTransaction(myContext, Me.Name, Me.frmMode.ToString, "AssessSurveyID", frmIDX)
                myContext.Provider.objSQLHelper.SaveResults(myRow.Row.Table, Me.sqlForm)
                frmIDX = myRow("AssessSurveyID")

                myView.MainGrid.SaveChanges(, "AssessSurveyID=" & frmIDX)
                myVueUsers.MainGrid.SaveChanges(, "AssessSurveyID=" & frmIDX)

                frmMode = EnumfrmMode.acEditM
                If myUtils.cValTN(myRow("courseid")) > 0 Then
                    Dim Sql2 = $"select * from contentunit where courseid = {myUtils.cValTN(myRow("CourseID"))} and assessSurveyid={frmIDX}"
                    Dim dt2 = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, Sql2).Tables(0), nr As DataRow
                    If dt2.Rows.Count = 0 Then nr = myContext.Tables.AddNewRow(dt2) Else nr = dt2.Rows(0)
                    nr("courseid") = myRow("courseid")
                    nr("assessSurveyid") = frmIDX
                    nr("contenttype") = "Survey"
                    nr("title") = myRow("surveyname")
                    myContext.Provider.objSQLHelper.SaveResults(dt2, Sql2)
                    myEduFuncs.UpdateSortIndex(myContext, myRow("courseid"))

                End If

                myContext.Provider.dbConn.CommitTransaction(AssessTestDescrip, frmIDX)
                VSave = True
            Catch ex As Exception
                myContext.Provider.dbConn.RollBackTransaction(AssessTestDescrip, ex.Message)
                Me.AddError("", ex.Message)
            End Try
        End If

        Return VSave
    End Function

    Public Overrides Function GenerateParamsModel(vwState As clsViewState, SelectionKey As String, Params As List(Of clsSQLParam)) As clsViewModel
        Dim Model As clsViewModel = Nothing
        Dim oRet As clsProcOutput = myContext.SQL.ValidateSQLParams(Params)
        If oRet.Success Then
            Select Case SelectionKey.Trim.ToLower
                Case "question"
                    Dim Sql As String = myContext.SQL.PopulateSQLParams("TestQuestionID not in (@QuestionIDCSV) and IsForSurvey=1", Params)
                    'Model = myContext.Provider.GenerateSelectionModel(vwState, "<SYS ID=""TestQuestionID""/>", True, , "<MODROW><SQLWHERE2>" & Sql & "</SQLWHERE2></MODROW>")
                    Dim CourseID = myUtils.cValTN(myContext.SQL.ParamValue("@courseid", Params))
                    Dim str1 = "<MODROW><SQLWHERE2>" & Sql & "</SQLWHERE2></MODROW>"
                    If CourseID > 0 Then str1 = str1 & $"<FILTER KEY=""Course""><VALUE VALUE1 =""{CourseID}"" /><VALUE OPERTYPE=""isnull""/></FILTER>" Else str1 = str1 & $"<FILTER KEY=""Course""><VALUE OPERTYPE=""isnull""/></FILTER>"
                    Model = myContext.Provider.GenerateSelectionModel(vwState, "<SYS ID=""TestQuestionID""/>", True, , str1)

                Case "user"
                    Dim str1 As String = myContext.SQL.PopulateSQLParams("UserID not in (@UserIDcsv)", Params)
                    Model = myContext.Provider.GenerateSelectionModel(vwState, "<SYS ID=""UserID""/>", True,, "<MODROW><SQLWHERE2>" & str1 & "</SQLWHERE2></MODROW>")

            End Select
        End If
        Return Model
    End Function

    Public Overrides Function DeleteEntity(EntityKey As String, ID As Integer, AcceptWarning As Boolean) As clsProcOutput
        Dim oRet As New clsProcOutput
        Try
            If AcceptWarning Then
                Select Case EntityKey.Trim.ToLower
                    Case "assesssurvey"
                        Dim sql As String = "Select * from AssessSurvey Where AssessSurveyID =" & ID
                        Dim dt As DataTable = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql).Tables(0)

                        If dt.Rows.Count > 0 Then
                            Dim sql1 As String = "delete from AssessSurvey where AssessSurveyID =" & ID
                            myContext.Provider.objSQLHelper.ExecuteNonQuery(CommandType.Text, sql1)

                            Dim sql2 As String = "delete from contentunit where AssessSurveyID =" & ID
                            myContext.Provider.objSQLHelper.ExecuteNonQuery(CommandType.Text, sql2)

                            Dim sql3 As String = "delete from assessuser where AssessSurveyID =" & ID
                            myContext.Provider.objSQLHelper.ExecuteNonQuery(CommandType.Text, sql3)

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
