Imports risersoft.shared
Imports risersoft.app.mxent
Imports Infragistics.Win
Imports System.Runtime.Serialization
Imports risersoft.shared.cloud
Imports risersoft.app.mxengg

<DataContract>
Public Class frmContentUnitViewModel
    Inherits clsFormDataModel

    Protected Overrides Sub InitViews()
    End Sub

    Public Sub New(context As IProviderContext)
        MyBase.New(context)
        Me.InitViews()
        Me.InitForm()
    End Sub

    Private Sub InitForm()
        Me.IgnorefRow = True
    End Sub

    Public Overrides Function PrepForm(oView As clsViewModel, ByVal prepMode As EnumfrmMode, ByVal prepIDX As String, Optional ByVal strXML As String = "") As Boolean
        Dim sql, str1 As String, dic As New clsCollecString(Of String)

        Me.FormPrepared = False
        If prepMode = EnumfrmMode.acEditM Then
            sql = "Select * from ContentUnit where ContentUnitID = " & prepIDX
            Me.InitData(sql, "", oView, prepMode, prepIDX, strXML)

            Dim nr = myEduFuncs.GetContentUnitUser(myContext, frmIDX)
            dic.Add("uu", "Select * from nlmsListContentUnitUser() where ContentUnitid = " & frmIDX & " and UserID = '" & myContext.Police.UniqueUserID & "'")
            dic.Add("Course", "Select * from Course where CourseID=" & myUtils.cValTN(myRow("CourseID")))
            dic.Add("cu", "Select * from CourseUser where Courseid = " & myUtils.cValTN(myRow("courseid")) & " and UserID = '" & myContext.Police.UniqueUserID & "'")

            If myUtils.IsInList(myUtils.cStrTN(myRow("contenttype")), "test", "Assignment", "survey") Then
                'These objects and fields are expected by the mobile app
                dic.Add("test", "Select TotalCount, TotalWeight, Duration, Complete_Show_Score as ShowScore, EnableOn, DisableOn from nlmsListContentUnitUser() where ContentUnitid = " & frmIDX & " and UserID = '" & myContext.Police.UniqueUserID & "'")
                dic.Add("au", "Select AssessNum, StartedOn, CompletedOn,TotalScore,TotalWeight,IsPassed,MessagePassed,MessageFailed from nlmsListAssessUser() where AssessUserID = " & myUtils.cValTN(nr("lastassessuserid")) & " and UserID = '" & myContext.Police.UniqueUserID & "'")
            End If

            Me.AddDataSet("info", dic)

            Dim nr2 As DataRow
            If Me.DatasetCollection("info").Tables("cu").Rows.Count > 0 Then
                nr2 = Me.DatasetCollection("info").Tables("cu").Rows(0)
                nr2("lastcontentunitid") = frmIDX
                If myUtils.NullNot(nr2("startedon")) Then nr2("startedon") = TaskProviderFactory.FindLocalTime

                myContext.Provider.objSQLHelper.SaveResults(Me.DatasetCollection("info").Tables("cU"), dic("cu"))
            End If


            Me.FormPrepared = True
        End If

        Return Me.FormPrepared
    End Function


    Public Overrides Function GenerateParamsOutput(dataKey As String, Params As List(Of clsSQLParam)) As clsProcOutput
        Dim oRet As clsProcOutput = myContext.SQL.ValidateSQLParams(Params)

        Dim rr() As DataRow
        If oRet.Success Then
            Dim CourseID As Integer = myUtils.cValTN(myContext.SQL.ParamValue("@CourseID", Params))
            Select Case dataKey.Trim.ToLower
                Case "assessuser", "testquestion"
                    Dim StartType As String = myUtils.cStrTN(myContext.SQL.ParamValue("@StartType", Params))
                    Dim TestID As Integer = myUtils.cValTN(myContext.SQL.ParamValue("@TestID", Params))
                    Dim SurveyID As Integer = myUtils.cValTN(myContext.SQL.ParamValue("@SurveyID", Params))
                    Dim AssignmentID As Integer = myUtils.cValTN(myContext.SQL.ParamValue("@AssignmentID", Params))
                    oRet = myEduFuncs.GetAssessUser(myContext, StartType, CourseID, TestID, SurveyID, AssignmentID)
                    If oRet.Success Then
                        Dim nr = oRet.GetCalcRows("assess")(0)
                        oRet.CalcList.Clear()
                        If myUtils.IsInList(dataKey, "testquestion") Then
                            oRet.IDList.Add(nr("assessuserid"))
                            Dim TestQuestionID = myEduFuncs.GetNextQuestionID(myContext, nr("assessuserid"), TestID, SurveyID, myUtils.cValTN(nr("lastquestionid")))
                            oRet.ID = TestQuestionID
                        Else
                            oRet.ID = nr("assessuserid")
                        End If

                    End If

                Case "contentunit"
                    Dim ContentUnitID As Integer = myUtils.cValTN(myContext.SQL.ParamValue("@ContentUnitID", Params))
                    oRet.ID = GiveNextContentUnitID(CourseID, ContentUnitID)
                Case "download"
                    Dim serverPath As String = BucketUtility.TryBase64Decode(myContext.SQL.ParamValue("@serverPath", Params))
                    Dim provider As New clsBlobFileProvider(myContext)
                    Dim container = myPathUtils.GetContainerName(myContext)
                    Dim oRet2 = provider.GetDownloadUri(container, serverPath)
                    If oRet2.Success Then
                        oRet.JsonData = New clsProcTextInfo With {.status = 200, .success = oRet.Success, .message = oRet.Message, .Data = oRet2.Result.Uri.ToString}
                    Else
                        oRet.JsonData = New clsProcTextInfo With {.status = 200, .success = oRet.Success, .message = oRet.Message} '"Unable to upload file."
                    End If
            End Select

        End If
        Return oRet
    End Function

    Public Function GiveNextContentUnitID(CourseID As Integer, ExistingContentUnitID As Integer) As Integer
        Dim ContentUnitID As Integer = 0


        Dim strf1 = myUtils.CombineWhere(False, "CourseID = " & CourseID, $"isnull(IsVisibleLearners, 0)=1")
        Dim dic As New clsCollecString(Of String)
        dic.Add("uu", "Select * from ContentUnitUser where ContentUnitid = " & ExistingContentUnitID & " and UserID = '" & myContext.Police.UniqueUserID & "'")
        dic.Add("unit", $"Select sortindex,contentunitid from ContentUnit where " & strf1 & " order by sortindex")

        Dim ds = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, dic)
        Dim rr() As DataRow = ds.Tables("unit").Select("contentunitid=" & ExistingContentUnitID)
        If rr.Length > 0 Then
            rr = ds.Tables("unit").Select("sortindex>" & myUtils.cValTN(rr(0)("sortindex")), "sortindex")
        Else
            rr = ds.Tables("unit").Select("", "sortindex")
        End If
        If rr.Length > 0 Then ContentUnitID = rr(0)("ContentUnitID")

        If ds.Tables("uu").Rows.Count > 0 Then
            'ContentUnitUser of old content unit
            If myUtils.NullNot(ds.Tables("uu").Rows(0)("startedon")) Then ds.Tables("uu").Rows(0)("startedon") = TaskProviderFactory.FindLocalTime
            ds.Tables("uu").Rows(0)("completedon") = TaskProviderFactory.FindLocalTime
            ds.Tables("uu").Rows(0)("timespend") = myUtils.cValTN(ds.Tables("uu").Rows(0)("timespend")) +
                DateDiff(DateInterval.Second, ds.Tables("uu").Rows(0)("startedon"), ds.Tables("uu").Rows(0)("completedon")) / 60
            myContext.Provider.objSQLHelper.SaveResults(ds.Tables("uu"), dic("uu"))
        End If

        'get unit data again to refresh time data
        dic.Clear()
        dic.Add("uu", "Select * from nlmsListContentUnitUser() where " & strf1 & " and UserID = '" & myContext.Police.UniqueUserID & "'")
        dic.Add("cu", "Select * from CourseUser where Courseid = " & CourseID & " and UserID = '" & myContext.Police.UniqueUserID & "'")
        ds = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, dic)
        If ds.Tables("cu").Rows.Count > 0 Then
            'CourseUser
            ds.Tables("cu").Rows(0)("totaltimespend") = myContext.Tables.GetColSum(ds.Tables("uu").Select, "timespend")
            If ds.Tables("uu").Select("completedon is null").Length = 0 AndAlso myUtils.NullNot(ds.Tables("cu").Rows(0)("completedon")) Then ds.Tables("cu").Rows(0)("completedon") = TaskProviderFactory.FindLocalTime
            ds.Tables("cu").Rows(0)("perprogress") = Math.Round(ds.Tables("uu").Select("completedon is not null").Length / ds.Tables("uu").Select.Length * 100, 2)
            myContext.Provider.objSQLHelper.SaveResults(ds.Tables("cu"), dic("cu"))
        End If


        Return ContentUnitID
    End Function


End Class

