Imports risersoft.shared
Imports risersoft.app.mxent
Imports System.Runtime.Serialization

<DataContract>
Public Class frmCourseUserModel
    Inherits clsFormDataModel

    Protected Overrides Sub InitViews()
        myView = Me.GetViewModel("Users")
    End Sub

    Public Sub New(context As IProviderContext)
        MyBase.New(context)
        Me.InitViews()
        Me.InitForm()
    End Sub

    Private Sub InitForm()
    End Sub

    Public Overrides Function PrepForm(oView As clsViewModel, ByVal prepMode As EnumfrmMode, ByVal prepIDX As String, Optional ByVal strXML As String = "") As Boolean
        Dim sql, str1 As String
        Me.FormPrepared = False
        If prepMode = EnumfrmMode.acAddM Then prepIDX = 0
        sql = "select * from Course where CourseID = " & prepIDX
        Me.InitData(sql, "", oView, prepMode, prepIDX, strXML)

        sql = "Select CourseUserID, CourseID, UserID, UserName, RoleCode, PerProgress, TotalTimeSpend, StartedOn, CompletedOn from nlmsListCourseUser() where CourseID = " & frmIDX & ""
        myView.MainGrid.MainConf("FORMATXML") = "<COL KEY=""RoleCode"" CAPTION=""Role""/>"
        myView.MainGrid.QuickConf(sql, True, "1.5-1-1-1-1-1", True)
        str1 = "<BAND INDEX=""0"" TABLE=""CourseUser"" IDFIELD=""CourseUserID""><COL KEY=""CourseID, UserID, PerProgress, TotalTimeSpend, StartedOn, CompletedOn""/><COL KEY=""RoleCode"" LOOKUPSQL=""" & myFuncsBase.CodeWordSQL("CourseRole", "Role", "") & """/></BAND>"
        myView.MainGrid.PrepEdit(str1, EnumEditType.acCommandAndEdit)

        Me.FormPrepared = True
        'End If
        Return Me.FormPrepared
    End Function

    Public Overrides Function Validate() As Boolean
        Me.InitError()
        myView.MainGrid.CheckValid("userid,rolecode")
        Return Me.CanSave
    End Function

    Public Overrides Function VSave() As Boolean
        VSave = False
        If Me.Validate Then

            If Me.CanSave Then
                Dim Descrip As String = " User for: " & myUtils.cStrTN(myRow("CourseName"))
                Try
                    myContext.Provider.dbConn.BeginTransaction(myContext, Me.Name, Me.frmMode.ToString, "CourseID", frmIDX)
                    'myContext.Provider.objSQLHelper.SaveResults(myRow.Row.Table, Me.sqlForm)

                    myView.MainGrid.SaveChanges(, "CourseID=" & frmIDX)
                    myContext.Provider.dbConn.CommitTransaction(Descrip, frmIDX)
                    VSave = True
                Catch ex As Exception
                    myContext.Provider.dbConn.RollBackTransaction(Descrip, ex.Message)
                    Me.AddError("", ex.Message)
                End Try
            End If
        End If
    End Function

    Public Overrides Function GenerateParamsModel(vwState As clsViewState, SelectionKey As String, Params As List(Of clsSQLParam)) As clsViewModel
        Dim Model As clsViewModel = Nothing
        Dim oRet As clsProcOutput = myContext.SQL.ValidateSQLParams(Params)
        If oRet.Success Then
            Select Case SelectionKey.Trim.ToLower
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
                    Case "courseuser"
                        Dim sql As String = "Select * from CourseUser Where CourseID =" & ID
                        Dim dt As DataTable = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql).Tables(0)

                        If dt.Rows.Count > 0 Then
                            Dim sql1 As String = "delete from CourseUser where CourseID =" & ID
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

