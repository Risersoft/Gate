Imports risersoft.shared
Imports risersoft.app.mxent
Imports Infragistics.Win
Imports System.Runtime.Serialization
Imports risersoft.app.mxengg

<DataContract>
Public Class frmContentUnitHTMLModel
    Inherits clsFormDataModel

    Protected Overrides Sub InitViews()
    End Sub

    Public Sub New(context As IProviderContext)
        MyBase.New(context)
        Me.InitViews()
        Me.InitForm()
    End Sub

    Private Sub InitForm()
    End Sub

    Public Overrides Function PrepForm(oView As clsViewModel, ByVal prepMode As EnumfrmMode, ByVal prepIDX As String, Optional ByVal strXML As String = "") As Boolean
        Dim sql, str1 As String, dic As New clsCollecString(Of String)

        Me.FormPrepared = False
        If prepMode = EnumfrmMode.acAddM Then prepIDX = 0
        sql = "Select * from ContentUnit where ContentUnitid = " & prepIDX
        Me.InitData(sql, "ContentType,CourseID", oView, prepMode, prepIDX, strXML)

        dic.Add("Course", "Select * from Course where CourseID=" & myUtils.cValTN(myRow("CourseID")))
        Me.AddDataSet("Course", dic)

        Me.FormPrepared = True

        Return Me.FormPrepared
    End Function

    Public Overrides Function Validate() As Boolean
        Me.InitError()
        If myUtils.cValTN(myRow("Courseid")) = 0 Then Me.AddError("Courseid", "Enter Course")
        If frmMode = EnumfrmMode.acEditM AndAlso (Not myContext.Police.IsAdmin(False)) AndAlso DateDiff(DateInterval.Day, myRow("createdon"), TaskProviderFactory.FindLocalTime) > 30 Then Me.AddError("title", "Cannot edit after 1 month")
        Return Me.CanSave
    End Function

    Public Overrides Function VSave() As Boolean
        VSave = False

        myRow("ContentHTML") = myFuncs.DecodeNormalizeHTML(myUtils.cStrTN(myRow("ContentHTML")))
        myRow("ContentText") = BucketUtility.TryBase64Decode(myUtils.cStrTN(myRow("ContentText")))

        myRow("NotesHTML") = myFuncs.DecodeNormalizeHTML(myUtils.cStrTN(myRow("NotesHTML")))
        myRow("NotesText") = BucketUtility.TryBase64Decode(myUtils.cStrTN(myRow("NotesText")))

        If Me.Validate Then
            Dim ContentDescrip As String = "ContentType: " & myRow("ContentType").ToString
            Try
                myContext.Provider.dbConn.BeginTransaction(myContext, Me.Name, Me.frmMode.ToString, "ContentUnitid", frmIDX)
                myContext.Provider.objSQLHelper.SaveResults(myRow.Row.Table, Me.sqlForm)
                frmIDX = myRow("ContentUnitid")
                myEduFuncs.UpdateSortIndex(myContext, myRow("courseid"))

                frmMode = EnumfrmMode.acEditM
                myContext.Provider.dbConn.CommitTransaction(ContentDescrip, frmIDX)
                VSave = True
            Catch ex As Exception
                myContext.Provider.dbConn.RollBackTransaction(ContentDescrip, ex.Message)
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
                    Case "contentunithtml"
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

    Public Overrides Function GenerateParamsOutput(dataKey As String, Params As List(Of clsSQLParam)) As clsProcOutput
        Dim oRet As New clsProcOutput
        oRet = myEduFuncs.GenerateCommonOutput(myContext, dataKey, Params, "courseid")
        Return oRet
    End Function

End Class


