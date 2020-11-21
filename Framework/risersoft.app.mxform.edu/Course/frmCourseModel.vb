Imports risersoft.shared
Imports risersoft.app.mxent
Imports Infragistics.Win
Imports System.Runtime.Serialization
Imports risersoft.app.mxengg

<DataContract>
Public Class frmCourseModel
    Inherits clsFormDataModel
    Dim myVueUsers As New clsViewModel

    Protected Overrides Sub InitViews()
        myView = Me.GetViewModel("Skill")
        myVueUsers = Me.GetViewModel("Users")
    End Sub

    Public Sub New(context As IProviderContext)
        MyBase.New(context)
        Me.InitViews()
        Me.InitForm()
    End Sub

    Private Sub InitForm()
        Dim sql As String = "Select CourseCatID, CategoryName from CourseCat order by CategoryName"
        Me.AddLookupField("CourseCatID", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql), "Category").TableName)
    End Sub

    Public Overrides Function PrepForm(oView As clsViewModel, ByVal prepMode As EnumfrmMode, ByVal prepIDX As String, Optional ByVal strXML As String = "") As Boolean
        Dim sql, str1 As String

        Me.FormPrepared = False
        If prepMode = EnumfrmMode.acAddM Then prepIDX = 0
        sql = "Select * from Course where Courseid = " & prepIDX
        Me.InitData(sql, "", oView, prepMode, prepIDX, strXML)

        sql = "Select SkillID, SkillCode, SkillName from Skill where '(' + skillcode + ')' in (" & myUtils.Coalesce(myUtils.cStrTN(myRow("SkillCSV")), "''") & ")"
        myView.MainGrid.MainConf("FormatXML") = "<COL KEY=""SkillCode"" CAPTION=""Code""/><COL KEY=""SkillName"" CAPTION=""Name""/>"
        myView.MainGrid.QuickConf(sql, True, "1-1", True)
        str1 = "<BAND INDEX=""0""></BAND>"
        myView.MainGrid.PrepEdit(str1, EnumEditType.acCommandOnly)

        sql = "Select CourseUserID, CourseID, UserID, UserName, RoleCode, PerProgress, TotalTimeSpend, StartedOn, CompletedOn from nlmsListCourseUser() where CourseID = " & frmIDX & ""
        myVueUsers.MainGrid.MainConf("FORMATXML") = "<COL KEY=""RoleCode"" CAPTION=""Role""/>"
        myVueUsers.MainGrid.QuickConf(sql, True, "1.5-1-1-1-1-1", True)
        str1 = "<BAND INDEX=""0"" TABLE=""CourseUser"" IDFIELD=""CourseUserID""><COL KEY=""CourseID, UserID, PerProgress, TotalTimeSpend, StartedOn, CompletedOn""/><COL KEY=""RoleCode"" LOOKUPSQL=""" & myFuncsBase.CodeWordSQL("CourseRole", "Role", "") & """/></BAND>"
        myVueUsers.MainGrid.PrepEdit(str1, EnumEditType.acCommandAndEdit)

        Me.FormPrepared = True

        Return Me.FormPrepared
    End Function

    Public Overrides Function Validate() As Boolean
        Me.InitError()
        If myUtils.cStrTN(myRow("CourseName")).Trim.Length = 0 Then Me.AddError("CourseName", "Enter Course Name")
        If myUtils.cStrTN(myRow("CourseCode")).Trim.Length = 0 Then Me.AddError("CourseCode", "Enter Course Code")
        Return Me.CanSave
    End Function

    Public Overrides Function VSave() As Boolean
        VSave = False
        Dim lst As New List(Of String)
        For Each r1 As DataRow In myView.MainGrid.myDS.Tables(0).Select()
            lst.Add("(" & myUtils.cStrTN(r1("skillcode")) & ")")
        Next

        myRow("skillcsv") = myUtils.MakeCSV2(",", "", True, lst.ToArray)
        myRow("DescriptionHTML") = myFuncs.DecodeNormalizeHTML(myUtils.cStrTN(myRow("DescriptionHTML")))
        myRow("DescriptionText") = BucketUtility.TryBase64Decode(myUtils.cStrTN(myRow("DescriptionText")))

        If Me.Validate Then
            Dim CourseDescrip As String = "Course: " & myRow("CourseName").ToString
            Try
                myContext.Provider.dbConn.BeginTransaction(myContext, Me.Name, Me.frmMode.ToString, "CourseID", frmIDX)
                myContext.Provider.objSQLHelper.SaveResults(myRow.Row.Table, Me.sqlForm)
                frmIDX = myRow("CourseID")

                myVueUsers.MainGrid.SaveChanges(, "CourseID=" & frmIDX)
                frmMode = EnumfrmMode.acEditM
                myContext.Provider.dbConn.CommitTransaction(CourseDescrip, frmIDX)
                VSave = True
            Catch ex As Exception
                myContext.Provider.dbConn.RollBackTransaction(CourseDescrip, ex.Message)
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
                Case "skill"
                    Dim sql As String = myContext.SQL.PopulateSQLParams("select SkillID, SkillCode, SkillName from skill where SkillCode not in (@skillcsv)", Params)
                    Model = New clsViewModel(vwState, myContext)
                    Model.Mode = EnumViewMode.acSelectM : Model.MultiSelect = True
                    Model.MainGrid.QuickConf(sql, True, "1-1", , "")
                    Dim str1 As String = "<BAND INDEX=""0"">/></BAND>"
                    Model.MainGrid.PrepEdit(str1, EnumEditType.acEditOnly)

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
            If Not myContext.Police.IsAdmin(False) Then
                oRet.AddError("Delete operation is not allowed")
            End If
            If oRet.Success AndAlso AcceptWarning Then
                Select Case EntityKey.Trim.ToLower
                    Case "course"
                        Dim sql As String = "Select * from Course Where CourseID =" & ID
                        Dim dt As DataTable = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql).Tables(0)

                        If dt.Rows.Count > 0 Then
                            Dim sql1 As String = "delete from CourseUser where CourseID =" & ID
                            myContext.Provider.objSQLHelper.ExecuteNonQuery(CommandType.Text, sql1)

                            Dim sql2 As String = "delete from CourseFile where CourseID =" & ID
                            myContext.Provider.objSQLHelper.ExecuteNonQuery(CommandType.Text, sql2)

                            Dim sql3 As String = "delete From ContentUnit Where CourseID =" & ID
                            myContext.Provider.objSQLHelper.ExecuteNonQuery(CommandType.Text, sql3)

                            Dim sql4 As String = "delete from Course where CourseID =" & ID
                            myContext.Provider.objSQLHelper.ExecuteNonQuery(CommandType.Text, sql4)
                        End If
                End Select
            ElseIf oRet.WarningCount = 0 AndAlso oRet.ErrorCount = 0 Then
                oRet.AddWarning("Are you sure ?")
            End If
        Catch ex As Exception
            oRet.AddException(ex)
        End Try
        Return oRet
    End Function

End Class

