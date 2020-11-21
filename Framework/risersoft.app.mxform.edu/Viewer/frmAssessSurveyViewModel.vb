Imports risersoft.shared
Imports risersoft.app.mxent
Imports Infragistics.Win
Imports System.Runtime.Serialization
Imports risersoft.shared.cloud

<DataContract>
Public Class frmAssessSurveyViewModel
    Inherits clsFormDataModel

    Protected Overrides Sub InitViews()
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
        Dim sql As String, dic As New clsCollecString(Of String)

        Me.FormPrepared = False
        If prepMode = EnumfrmMode.acAddM Then prepIDX = 0
        sql = "Select * from nlmslistAssessUser() where AssessUserID = " & prepIDX
        Me.InitData(sql, "AssessSurveyID,CourseID", oView, prepMode, prepIDX, strXML)

        Me.FormPrepared = True

        Return Me.FormPrepared
    End Function

    Public Overrides Function Validate() As Boolean
        Me.InitError()
        If Me.myRow("SurveyName").Trim.Length = 0 Then Me.AddError("SurveyName", "Enter Survey Name")

        Return Me.CanSave
    End Function

    Public Overrides Function VSave() As Boolean
        VSave = False

        If Me.Validate Then
            Dim SurveyDescrip As String = "Name: " & myRow("SurveyName").ToString
            Try
                myContext.Provider.dbConn.BeginTransaction(myContext, Me.Name, Me.frmMode.ToString, "AssessUserID", frmIDX)
                myContext.Provider.objSQLHelper.SaveResults(myRow.Row.Table, "Select * from AssessUser where AssessUserID = " & frmIDX)

                frmIDX = myRow("AssessUserID")
                frmMode = EnumfrmMode.acEditM
                myContext.Provider.dbConn.CommitTransaction(SurveyDescrip, frmIDX)
                VSave = True
            Catch ex As Exception
                myContext.Provider.dbConn.RollBackTransaction(SurveyDescrip, ex.Message)
                Me.AddError("", ex.Message)
            End Try
        End If

        Return VSave
    End Function

    Public Overrides Function GenerateParamsOutput(dataKey As String, Params As List(Of clsSQLParam)) As clsProcOutput
        Dim oRet As clsProcOutput = myContext.SQL.ValidateSQLParams(Params)

        If oRet.Success Then
            Select Case dataKey.Trim.ToLower
                Case "testquestion"
                    Dim StartType As String = myUtils.cStrTN(myContext.SQL.ParamValue("@StartType", Params))
                    Dim AssessUserID As Integer = myUtils.cValTN(myContext.SQL.ParamValue("@AssessUserID", Params))
                    Dim nr = myEduFuncs.GetAssessUser(myContext, AssessUserID)
                    Dim TestQuestionID = myEduFuncs.GetNextQuestionID(myContext, AssessUserID,
                                             myUtils.cValTN(nr("assessTestID")), myUtils.cValTN(nr("AssessSurveyID")),
                                             If(myUtils.IsInList(StartType, "contprev", "continue"), myUtils.cValTN(nr("lastquestionid")), 0))
                    oRet.ID = TestQuestionID

            End Select

        End If
        Return oRet
    End Function

End Class
