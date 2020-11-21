Imports risersoft.shared
Imports risersoft.app.mxent
Imports Infragistics.Win
Imports System.Runtime.Serialization
Imports risersoft.shared.cloud
Imports risersoft.app.mxengg

<DataContract>
Public Class frmCourseContentModel
    Inherits clsFormDataModel
    Dim myVueFile As clsViewModel

    Protected Overrides Sub InitViews()
        myView = Me.GetViewModel("Content")
        myVueFile = Me.GetViewModel("File")
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

        sql = "Select ContentUnitID, SortIndex,CreatedOn, CreatedBy, LastUpdated, ModifiedBy,  ParentUnitID, AssessTestID, AssessSurveyID, AssessAssignmentID, CourseID, DocType, ContentType, Title, IsVisibleLearners from ContentUnit where Courseid = " & frmIDX & " order by sortindex"
        myView.MainGrid.QuickConf(sql, True, "1-1-3", True)
        str1 = "<BAND INDEX=""0"" TABLE=""ContentUnit"" IDFIELD=""ContentUnitID"" ><COL KEY=""SortIndex,CourseID,ContentType,Title,ParentUnitID,IsVisibleLearners,CreatedOn, CreatedBy, LastUpdated, ModifiedBy""/></BAND>"
        myView.MainGrid.PrepEdit(str1, EnumEditType.acCommandOnly)

        sql = "Select CourseFileID, CourseID, FileName, FileURL, FileSizeKB, FileType from CourseFile where Courseid = " & frmIDX
        myVueFile.MainGrid.QuickConf(sql, True, "1-1-1-1", True)
        str1 = "<BAND INDEX=""0"" TABLE=""CourseFile"" IDFIELD=""CourseFileID"" ><COL KEY=""CourseID""/></BAND> "
        myVueFile.MainGrid.PrepEdit(str1, EnumEditType.acCommandOnly)

        Dim dic2 As New clsCollecString(Of String)
        dic2.Add("cu", "Select top 1 * from CourseUser where CourseID = " & frmIDX & " And UserID = '" & myContext.Police.UniqueUserID & "'")
        Dim ds = Me.AddDataSet("info", dic2)
        Me.ModelParams.Add(New clsSQLParam("IsAdmin", myContext.Police.IsAdmin(False).ToString, GetType(Boolean), False))
        Me.FormPrepared = True

        Return Me.FormPrepared
    End Function

    Public Overrides Function Validate() As Boolean
        Me.InitError()
        For Each r1 In myView.MainGrid.myDS.Tables(0).Select("", "", DataViewRowState.Deleted)
            'If myContext.Police.IsAdmin(False) AndAlso DateDiff(DateInterval.Day, r1("createdon", DataRowVersion.Original), TaskProviderFactory.FindLocalTime) > 30 Then Me.AddError("coursename", "Cannot delete content after 1 month")
            If (Not myContext.Police.IsAdmin(False)) AndAlso (DateDiff(DateInterval.Day, r1("createdon", DataRowVersion.Original), TaskProviderFactory.FindLocalTime) > 30) Then Me.AddError("coursename", "Cannot delete content after 1 month")
        Next

        'If Me.myRow("Title").Trim.Length = 0 Then Me.AddError("Title", "Enter Title")
        Return Me.CanSave
    End Function

    Public Overrides Function VSave() As Boolean
        VSave = False

        If Me.Validate Then
            Dim CourseDescrip As String = "Course: " & myRow("CourseName").ToString
            Try
                myContext.Provider.dbConn.BeginTransaction(myContext, Me.Name, Me.frmMode.ToString, "CourseID", frmIDX)
                'myContext.Provider.objSQLHelper.SaveResults(myRow.Row.Table, Me.sqlForm)
                frmIDX = myRow("CourseID")

                myView.MainGrid.SaveChanges(, "CourseID=" & frmIDX)
                myVueFile.MainGrid.SaveChanges(, "CourseID=" & frmIDX)

                Dim ParentUnitID As Integer?
                For Each r1 As DataRow In myView.MainGrid.myDS.Tables(0).Select("", "sortindex")
                    If myUtils.IsInList(myUtils.cStrTN(r1("contenttype")), "section") Then
                        ParentUnitID = r1("contentunitid")
                    Else
                        r1("parentunitid") = myUtils.MakeDBN(ParentUnitID)
                    End If
                Next
                myView.MainGrid.SaveChanges(, "CourseID=" & frmIDX) 'save parentunitid

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


    Public Overrides Function DeleteEntity(EntityKey As String, ID As Integer, AcceptWarning As Boolean) As clsProcOutput
        Dim oRet As New clsProcOutput
        Try
            If AcceptWarning Then
                Select Case EntityKey.Trim.ToLower
                    Case "contentunit"
                        Dim sql As String = "Select * from ContentUnit Where ContentUnitID =" & ID
                        Dim dt As DataTable = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql).Tables(0)

                        If dt.Rows.Count > 0 Then
                            Dim sql1 As String = "delete from ContentUnit where ContentUnitID =" & ID
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

    Public Sub ReorderSortindexAsPerID()
        Dim sortindex As Integer = 0
        For Each r1 As DataRow In myView.MainGrid.myDS.Tables(0).Select("", "contentunitid")
            sortindex = sortindex + 1
            r1("sortindex") = sortindex
        Next

    End Sub

    Public Overrides Function GenerateParamsOutput(dataKey As String, Params As List(Of clsSQLParam)) As clsProcOutput
        Dim oRet As New clsProcOutput
        oRet = myEduFuncs.GenerateCommonOutput(myContext, dataKey, Params, "courseid")
        Return oRet
    End Function
End Class


