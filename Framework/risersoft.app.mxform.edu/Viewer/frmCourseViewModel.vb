Imports risersoft.shared
Imports risersoft.app.mxent
Imports Infragistics.Win
Imports System.Runtime.Serialization
Imports risersoft.shared.cloud
Imports risersoft.app.mxengg

<DataContract>
Public Class frmCourseViewModel
    Inherits clsFormDataModel
    Dim myVueFile As clsViewModel

    Protected Overrides Sub InitViews()
        myView = Me.GetViewModel("ContentList")
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
        Dim sql, str1 As String,
            dic As New clsCollecString(Of String)

        Me.FormPrepared = False
        If prepMode = EnumfrmMode.acAddM Then prepIDX = 0
        sql = "Select * from nlmslistCourseUser() where CourseUserid = " & prepIDX
        Me.InitData(sql, "CourseID", oView, prepMode, prepIDX, strXML)
        sql = "Select ContentUnitID, CourseID, ParentUnitID, SortIndex, ContentType, DocType, Title, IsVisibleLearners from ContentUnit where " &
            myUtils.CombineWhere(False, "CourseID = " & myUtils.cValTN(myRow("courseid")), $"isnull(IsVisibleLearners,0)=1") &
            " order by sortindex"

        myView.MainGrid.QuickConf(sql, True, "1-1-1", True)
        myView.MainGrid.PrepEdit(str1, EnumEditType.acCommandOnly)

        sql = "Select CourseFileID, CourseID, FileName, FileURL, FileSizeKB, FileType from CourseFile where Courseid = " & myUtils.cValTN(myRow("courseid"))
        myVueFile.MainGrid.QuickConf(sql, True, "1-1-1-1", True)
        str1 = "<BAND INDEX=""0"" TABLE=""CourseFile"" IDFIELD=""CourseFileID"" ><COL KEY=""CourseID""/></BAND> "
        myVueFile.MainGrid.PrepEdit(str1, EnumEditType.acCommandOnly)

        Me.FormPrepared = True
        Return Me.FormPrepared
    End Function

    Public Overrides Function GenerateParamsOutput(dataKey As String, Params As List(Of clsSQLParam)) As clsProcOutput
        Dim oRet As New clsProcOutput
        oRet = myEduFuncs.GenerateCommonOutput(myContext, dataKey, Params, "courseid")
        Return oRet
    End Function

End Class


