Imports risersoft.shared
Imports risersoft.app.mxent
Imports Infragistics.Win
Imports System.Runtime.Serialization
Imports risersoft.shared.cloud
Imports risersoft.app.mxengg

<DataContract>
Public Class frmAssessAssignModel
    Inherits clsFormDataModel
    Dim myVueUsers As New clsViewModel

    Protected Overrides Sub InitViews()
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

        Dim vlist As New clsValueList
        vlist.Add(False, "When instructor accepts the answer")
        vlist.Add(True, "When uploading an answer")
        Me.ValueLists.Add("CompletionSubmit", vlist)
        Me.AddLookupField("CompletionSubmit", "CompletionSubmit")

    End Sub

    Public Overrides Function PrepForm(oView As clsViewModel, ByVal prepMode As EnumfrmMode, ByVal prepIDX As String, Optional ByVal strXML As String = "") As Boolean
        Dim sql, str1 As String

        Me.FormPrepared = False
        If prepMode = EnumfrmMode.acAddM Then prepIDX = 0
        sql = "Select * from AssessAssignment where AssessAssignmentID = " & prepIDX
        Me.InitData(sql, "CourseID", oView, prepMode, prepIDX, strXML)

        sql = "Select AssessUserID, AssessAssignmentID, UserID, UserName, RoleCode, StartedOn, CompletedOn from nlmslistAssessUser() where AssessAssignmentID = " & frmIDX & ""
        myVueUsers.MainGrid.MainConf("FORMATXML") = "<COL KEY=""RoleCode"" CAPTION=""Role""/>"
        myVueUsers.MainGrid.QuickConf(sql, True, "1.5-1-1-1", True)
        str1 = "<BAND INDEX=""0"" TABLE=""AssessUser"" IDFIELD=""AssessUserID""><COL KEY=""AssessAssignmentID, UserID, StartedOn, CompletedOn""/><COL KEY=""RoleCode"" LOOKUPSQL=""" & myFuncsBase.CodeWordSQL("CourseRole", "Role", "") & """/></BAND>"
        myVueUsers.MainGrid.PrepEdit(str1, EnumEditType.acCommandAndEdit)

        Me.FormPrepared = True

        Return Me.FormPrepared
    End Function

    Public Overrides Function Validate() As Boolean
        Me.InitError()
        If myUtils.cStrTN(myRow("AssignmentName")).Trim.Length = 0 Then Me.AddError("AssignmentName", "Enter Assignment Name")
        If myUtils.cValTN(myRow("courseid")) = 0 Then myVueUsers.MainGrid.CheckValid("userid,rolecode")
        Return Me.CanSave
    End Function

    Public Overrides Function VSave() As Boolean
        VSave = False

        myRow("DescriptionHTML") = myFuncs.DecodeNormalizeHTML(myUtils.cStrTN(myRow("DescriptionHTML")))
        myRow("DescriptionText") = BucketUtility.TryBase64Decode(myUtils.cStrTN(myRow("DescriptionText")))

        If Me.Validate Then
            Dim AssignmentDescrip As String = "Name: " & myRow("AssignmentName").ToString
            Try
                myContext.Provider.dbConn.BeginTransaction(myContext, Me.Name, Me.frmMode.ToString, "AssessAssignmentID", frmIDX)
                myContext.Provider.objSQLHelper.SaveResults(myRow.Row.Table, Me.sqlForm)
                frmIDX = myRow("AssessAssignmentID")

                myVueUsers.MainGrid.SaveChanges(, "AssessAssignmentID=" & frmIDX)

                frmMode = EnumfrmMode.acEditM
                If myUtils.cValTN(myRow("courseid")) > 0 Then
                    Dim Sql2 = $"select * from contentunit where courseid = {myUtils.cValTN(myRow("CourseID"))} and assessAssignmentid={frmIDX}"
                    Dim dt2 = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, Sql2).Tables(0), nr As DataRow
                    If dt2.Rows.Count = 0 Then nr = myContext.Tables.AddNewRow(dt2) Else nr = dt2.Rows(0)
                    nr("courseid") = myRow("courseid")
                    nr("assessAssignmentid") = frmIDX
                    nr("contenttype") = "Assignment"
                    nr("title") = myRow("assignmentname")
                    myContext.Provider.objSQLHelper.SaveResults(dt2, Sql2)
                    myEduFuncs.UpdateSortIndex(myContext, myRow("courseid"))

                End If

                myContext.Provider.dbConn.CommitTransaction(AssignmentDescrip, frmIDX)
                VSave = True
            Catch ex As Exception
                myContext.Provider.dbConn.RollBackTransaction(AssignmentDescrip, ex.Message)
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
                    Dim Sql As String = myContext.SQL.PopulateSQLParams("TestQuestionID not in (@QuestionIDCSV) and IsForSurvey=0", Params)
                    Model = myContext.Provider.GenerateSelectionModel(vwState, "<SYS ID=""TestQuestionID""/>", True, , "<MODROW><SQLWHERE2>" & Sql & "</SQLWHERE2></MODROW>")

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
                    Case "assessassignment"
                        Dim sql As String = "Select * from AssessAssignment Where AssessAssignmentID =" & ID
                        Dim dt As DataTable = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql).Tables(0)

                        If dt.Rows.Count > 0 Then
                            Dim sql1 As String = "delete from AssessAssignment where AssessAssignmentID =" & ID
                            myContext.Provider.objSQLHelper.ExecuteNonQuery(CommandType.Text, sql1)

                            Dim sql2 As String = "delete from contentunit where AssessAssignmentID =" & ID
                            myContext.Provider.objSQLHelper.ExecuteNonQuery(CommandType.Text, sql2)

                            Dim sql3 As String = "delete from assessuser where AssessAssignmentID =" & ID
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

    Public Overrides Function GenerateParamsOutput(dataKey As String, Params As List(Of clsSQLParam)) As clsProcOutput
        Dim oRet As New clsProcOutput
        oRet = myEduFuncs.GenerateCommonOutput(myContext, dataKey, Params, "courseid")
        Return oRet
    End Function

End Class
