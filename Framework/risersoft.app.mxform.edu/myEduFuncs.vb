Imports System.Drawing
Imports System.IO
Imports Newtonsoft.Json
Imports risersoft.shared
Imports risersoft.shared.cloud

Public Class myEduFuncs
    Public Shared Function DocTypeFromFileExt(fileType As String) As String
        Dim str1 As String
        Select Case fileType.Trim.ToLower
            Case ".doc", ".docx", ".rtf"
                str1 = "Document"
            Case ".mpg", ".mpeg", ".mp4", ".wmv"
                str1 = "Video"
            Case ".mp3", ".m4a", ".wav"
                str1 = "Audio"
            Case ".pdf"
                str1 = "pdf"
            Case ".pptx", ".ppt"
                str1 = "Presentation"
            Case ".xls", ".xlsx"
                str1 = "Excel"
        End Select
        Return str1
    End Function
    Public Shared Function GenerateCommonOutput(context As IProviderContext, DataKey As String, Params As List(Of clsSQLParam), IDField As String) As clsProcOutput
        Dim oRet As New clsProcOutput
        Dim serverPath As String = Uri.UnescapeDataString(context.SQL.ParamValue("@serverPath", Params))
        Dim Length As String = context.SQL.ParamValue("@Length", Params)

        Dim _NewFileName As String = myUtils.cStrTN(context.SQL.ParamValue("@filename", Params))

        Dim DocType As String = context.SQL.ParamValue("@DocType", Params)
        Dim queueName = context.Controller.CalcQueueName

        Select Case DataKey.Trim.ToLower
            Case "process"
                Dim filename As String = context.Controller.CalcRLSId.ToString & $"-Document-{DataKey}-" & Replace(Now.ToLongTimeString, ":", "").Replace(" ", "") & ".png"
                Dim dic As New Dictionary(Of String, String) From {{"path", serverPath}}
                Dim dicParams As New Dictionary(Of String, String) From {{"InfoJson", JsonConvert.SerializeObject(dic)}, {"filename", filename}}
                Dim rTask As DataRow = TaskProviderFactory.CreateApiTask(context.Provider, DataKey, DocType, 0, dicParams)
                oRet = TaskProviderFactory.Enqueue(context.Provider, rTask, queueName)
                If oRet.Success Then oRet.Description = rTask("apitaskid").ToString
                oRet.AddDataRow("task", rTask)

            Case "sas"
                Dim frmid As String = myUtils.cStrTN(context.SQL.ParamValue($"@{IDField}", Params))
                _NewFileName = Guid.NewGuid.ToString() + "_" + frmid + "" + Path.GetExtension(_NewFileName)

                Dim provider As New clsBlobFileProvider(context)
                Dim container = myPathUtils.GetContainerName(context)
                Dim oRet2 = provider.CreateUploadUri(container, _NewFileName, "")
                If oRet2.Success Then
                    oRet.JsonData = New With {.status = 200, .success = oRet.Success, .message = oRet.Message, .Data = oRet2.Result.Uri.ToString, .flName = _NewFileName}
                Else
                    oRet.JsonData = New With {.status = 200, .success = oRet.Success, .message = oRet.Message} '"Unable to upload file."
                End If

            Case "download"
                Dim provider As New clsBlobFileProvider(context)
                Dim container = myPathUtils.GetContainerName(context)
                Dim oRet2 = provider.GetDownloadUri(container, myUtils.Coalesce(serverPath, _NewFileName))
                If oRet2.Success Then
                    oRet.JsonData = New With {.status = 200, .success = oRet.Success, .message = oRet.Message, .Data = oRet2.Result.Uri.ToString}
                Else
                    oRet.JsonData = New With {.status = 200, .success = oRet.Success, .message = oRet.Message} '"Unable to upload file."
                End If
        End Select
        Return oRet
    End Function
    Public Shared Async Function ProcessFileAsync(context As IProviderContext, filePath As String, OutFile As String, DocType As String) As Task(Of clsProcOutput)
        Dim oRet As New clsProcOutput
        Dim dicResult = oRet.DictData
        Dim fInfo As New FileInfo(filePath)
        dicResult("contentsizemb") = Format(fInfo.Length / 2 ^ 10 / 2 ^ 10, "0.0##")

        Dim client = context.App.objAppExtender.FileProviderClient(context, myPathUtils.GetContainerName(context))
        Dim filePathImg = context.App.objAppExtender.MapPath("app_data/payload/" & OutFile)
        Dim filePathPdf = context.App.objAppExtender.MapPath("app_data/payload/" & System.IO.Path.GetFileNameWithoutExtension(filePathImg) & ".pdf")
        Dim img As Image
        Dim dir As String = System.IO.Path.GetDirectoryName(filePathPdf)
        client.EnsureLocalDirectory(dir)
        Select Case DocType.Trim.ToLower
            Case "document"
                oRet.Success = myPDFConverter.ConvertDocToPDF(context, filePath, filePathPdf)
                img = myPDFConverter.GetImage(context, filePathPdf, 0)
            Case "presentation"
                oRet.Success = myPDFConverter.ConvertPresToPDF(context, filePath, filePathPdf)
                img = myPDFConverter.GetImage(context, filePathPdf, 0)
            Case "excel"
                oRet.Success = myPDFConverter.ConvertXLSToPDF(context, filePath, filePathPdf)
                img = myPDFConverter.GetImage(context, filePathPdf, 0)
            Case "video"
                filePathPdf = ""
                img = myMedia.GetThumbnailImage(context, filePath)
                Dim span = myMedia.GetVideoInfo(context, filePath)
                dicResult("medialensecs") = span.TotalSeconds.ToString
            Case "audio"
                filePathPdf = ""
                img = myMedia.GetThumbnailImage(context, filePath)
                Dim span = myMedia.GetAudioInfo(context, filePath)
                dicResult("medialensecs") = span.TotalSeconds.ToString
            Case "pdf"
                filePathPdf = filePath
                img = myPDFConverter.GetImage(context, filePathPdf, 0)
        End Select

        If oRet.Success Then
            If Not String.IsNullOrEmpty(filePathPdf) Then
                'Gives invalid license key error
                'Dim newFilePathPdf = myPDFConverter.Linearize(filePathPdf)
                Dim newFilePathPdf = filePathPdf
                Dim BlobName = Await client.UpLoadAsync(newFilePathPdf, System.IO.Path.GetFileName(newFilePathPdf), "")
                dicResult.Add("pdf", System.IO.Path.GetFileName(newFilePathPdf))
            End If
            If Not img Is Nothing Then
                Using ms As System.IO.MemoryStream = New System.IO.MemoryStream
                    img.Save(ms, Imaging.ImageFormat.Png)
                    ms.Position = 0
                    Dim BlobName = Await client.UploadStreamAsync(ms, System.IO.Path.GetFileName(filePathImg), "")
                    dicResult.Add("img", System.IO.Path.GetFileName(filePathImg))
                End Using
            End If
        End If
        Return oRet

    End Function


    Public Shared Function GetNextQuestionID(context As IProviderContext, AssessUserID As Integer, TestID As Integer, SurveyID As Integer, ExistingTestQuestionID As Integer) As Integer
        Dim IDField As String = If(TestID > 0, "AssessTestID", "AssessSurveyID")
        Dim IDValue = If(TestID > 0, TestID, SurveyID)
        Dim TestQuestionID As Integer = 0, dic As New clsCollecString(Of String)
        dic.Add("ques", $"Select sortindex,TestQuestionID, weight from TestQuestionItem where {IDField}={IDValue} order by sortindex")
        dic.Add("au", $"Select * from AssessUser where AssessUserID={AssessUserID}")
        dic.Add("qu", $"Select TestQuestionID, score from TestQuestionUser where AssessUserID={AssessUserID}")
        dic.Add("test", $"Select enableon, disableon, duration, Random_Shuffle_Questions from AssessTest where AssessTestID={TestID}")
        Dim ds = context.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, dic)
        Dim dt = ds.Tables("ques")
        For Each r1 As DataRow In dt.Select("sortindex is null", "testquestionid")
            r1("sortindex") = myUtils.MaxVal(dt.Select, "sortindex") + 1
        Next
        Dim rr As DataRow(), MaxDuration, TestDuration As Decimal
        Dim FinishTime As DateTime = DateTime.Now.AddYears(1000)
        Dim Random_Shuffle_Questions As Boolean = False, SelectedIndex As Integer = 0
        If ds.Tables("test").Rows.Count > 0 Then
            MaxDuration = myUtils.cValTN(ds.Tables("test").Rows(0)("duration"))
            'TestDuration = DateDiff(DateInterval.Minute, ds.Tables("au").Rows(0)("startedon"), TaskProviderFactory.FindLocalTime)
            TestDuration = DateDiff(DateInterval.Second, myUtils.cDateTN(ds.Tables("au").Rows(0)("startedon"), TaskProviderFactory.FindLocalTime), TaskProviderFactory.FindLocalTime) / 60.0
            FinishTime = myUtils.cDateTN(ds.Tables("test").Rows(0)("disableon"), DateTime.Now.AddYears(1000))
            Random_Shuffle_Questions = myUtils.cBoolTN(ds.Tables("test").Rows(0)("Random_Shuffle_Questions"))
            If (Not myUtils.NullNot(ds.Tables("test").Rows(0)("enableon"))) AndAlso ds.Tables("test").Rows(0)("enableon") > TaskProviderFactory.FindLocalTime Then
                'test is not enabled yet
                Return 0
            End If
        End If
        If TaskProviderFactory.FindLocalTime > FinishTime Then
            'test is finished due to disabled on 
            rr = New DataRow() {}
        ElseIf ExistingTestQuestionID = 0 Then
            ds.Tables("au").Rows(0)("startedon") = TaskProviderFactory.FindLocalTime
            ds.Tables("au").Rows(0)("deadlineon") = myUtils.MinDate(TaskProviderFactory.FindLocalTime.AddMinutes(MaxDuration), FinishTime)
            rr = dt.Select("", "sortindex")
        ElseIf (MaxDuration > 0) AndAlso (TestDuration > MaxDuration) Then
            'test is finished due to duration
            rr = New DataRow() {}
        ElseIf Random_Shuffle_Questions Then
            Dim strf = "TestQuestionID not in (" & myUtils.MakeCSV(ds.Tables("qu").Select, "Testquestionid") & ")"
            rr = dt.Select(strf, "sortindex")
        Else
            rr = dt.Select("TestQuestionID=" & ExistingTestQuestionID)
            If rr.Length > 0 Then rr = dt.Select("sortindex>" & myUtils.cValTN(rr(0)("sortindex")), "sortindex")
        End If

        If rr.Length > 0 Then
            If Random_Shuffle_Questions Then SelectedIndex = myMath.Shuffle(0, rr.Length - 1)(0)
            TestQuestionID = rr(SelectedIndex)("TestQuestionID")
        Else
            'test has finished
            ds.Tables("au").Rows(0)("completedon") = TaskProviderFactory.FindLocalTime
            ds.Tables("au").Rows(0)("totalscore") = context.Tables.GetColSum(ds.Tables("qu").Select, "score")
        End If
        ds.Tables("au").Rows(0)("submitcount") = ds.Tables("qu").Select.Length
        ds.Tables("au").Rows(0)("lastsubmiton") = TaskProviderFactory.FindLocalTime

        context.Provider.objSQLHelper.SaveResults(ds.Tables("au"), dic("au"))
        Return TestQuestionID
    End Function
    Public Shared Function GetAssessUser(context As IProviderContext, StartType As String, CourseID As Integer, TestID As Integer, SurveyID As Integer, AssignID As Integer) As clsProcOutput
        Dim oRet As New clsProcOutput
        Dim IDField As String = If(TestID > 0, "AssessTestID", If(SurveyID > 0, "AssessSurveyID", "AssessAssignmentID"))
        Dim IDValue = If(TestID > 0, TestID, If(SurveyID > 0, SurveyID, AssignID))

        Dim strf1 = $"courseid={CourseID}"
        Dim strf2 = $"{IDField}={IDValue}"
        Dim strf3 = $"UserID= '{context.Police.UniqueUserID.ToString}'"

        Dim dic As New clsCollecString(Of String)
        dic.Add("au", $"Select * from AssessUser where " & myUtils.CombineWhere(False, strf2, strf3))
        dic.Add("cu", $"Select contentunitid from contentunit where " & myUtils.CombineWhere(False, strf1, strf2))
        dic.Add("uu", $"Select ContentUnitUserID, LastAssessUserID, NotifyMsg, ButtonType from nlmslistcontentunituser() where " &
                myUtils.CombineWhere(False, strf1, strf2, strf3))
        Dim ds = context.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, dic)
        Dim dt As DataTable = ds.Tables("au"), rr(), nr As DataRow
        rr = dt.Select("completedon is null", "AssessNum desc")
        If myUtils.IsInList(StartType, "contprev") Then
            StartType = "continue"  'for mobile app
        ElseIf myUtils.IsInList(StartType, "startnew") Then
            StartType = "start new"  'for mobile app
        End If

        If ds.Tables("uu").Rows.Count = 0 Then
            oRet.AddError("Course user Not found")
        ElseIf String.IsNullOrEmpty(myutils.cStrTN(ds.Tables("uu").Rows(0)("buttontype"))) Then
            oRet.AddError(myUtils.cStrTN(ds.Tables("uu").Rows(0)("notifymsg")))
        ElseIf Not myUtils.IsInList(myutils.cStrTN(ds.Tables("uu").Rows(0)("buttontype")), StartType) Then
            oRet.AddError("Selected operation not available")
        Else
            If myUtils.IsInList(StartType, "continue") AndAlso rr.Length > 0 Then
                For Each r1 As DataRow In rr
                    If nr Is Nothing Then
                        nr = r1
                    Else
                        'mark all old assessments as complete
                        r1("CompletedOn") = TaskProviderFactory.FindLocalTime
                    End If
                Next
            ElseIf myUtils.IsInList(StartType, "start", "start new") Then
                'start/startnew
                For Each r1 As DataRow In rr
                    r1("CompletedOn") = Now.Date
                Next
                nr = dt.NewRow
                nr("UserID") = context.Police.UniqueUserID
                nr("StartedOn") = TaskProviderFactory.FindLocalTime
                nr(IDField) = IDValue
                If ds.Tables("cu").Rows.Count > 0 Then nr("contentunitid") = ds.Tables("cu").Rows(0)("contentunitid")
                nr("assessnum") = myUtils.MaxVal(dt.Select, "assessnum") + 1
                dt.Rows.Add(nr)

            End If
        If nr Is Nothing Then
            oRet.AddError("Invalid operation")
        Else
            context.Provider.objSQLHelper.SaveResults(dt, dic("au"))
            ds.Tables("uu").Rows(0)("lastassessuserid") = nr("assessuserid")    'assumed that contentunituser would have 1 row.
            context.Provider.objSQLHelper.SaveResults(ds.Tables("uu"), "select ContentUnitUserID, LastAssessUserID from contentunituser where 0=1")
            oRet.AddDataRow("assess", nr)
        End If
        End If

        Return oRet
    End Function
    Public Shared Function GetAssessUser(context As IProviderContext, AssessUserID As Integer) As DataRow

        Dim dic As New clsCollecString(Of String)
        dic.Add("au", $"Select * from AssessUser where AssessUserID={AssessUserID}")
        Dim ds = context.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, dic)
        Dim dt As DataTable = ds.Tables("au")
        Dim nr = If(dt.Rows.Count > 0, dt.Rows(0), Nothing)
        Return nr
    End Function
    Public Shared Function UpdateSortIndex(context As IProviderContext, courseid As Integer) As Integer
        Dim sql = "select contentunitid, sortindex from contentunit where courseid = " & courseid
        Dim dt1 = context.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql).Tables(0)
        Dim cnt As Integer = myUtils.MaxVal(dt1, "sortindex")
        For Each r1 As DataRow In dt1.Select("sortindex is null", "contentunitid")
            cnt = cnt + 1
            r1("sortindex") = cnt
        Next
        Return cnt
    End Function
    Public Shared Function ShuffleList(Of T)(lst As List(Of T)) As List(Of T)
        Dim lst2 As New List(Of T)
        Dim lstRnd = myMath.Shuffle(0, lst.Count - 1)
        For i As Integer = 0 To lst.Count - 1
            lst2.Add(lst(lstRnd(i)))
        Next
        Return lst2
    End Function
    Public Shared Function GetContentUnitUser(context As IProviderContext, ContentUnitID As Integer) As DataRow
        Dim nr As DataRow
        Dim dic As New clsCollecString(Of String)
        dic.Add("uu", $"Select * from ContentUnitUser where ContentUnitid = " & ContentUnitID & " and UserID = '" & context.Police.UniqueUserID & "'")
        Dim ds = context.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, dic)
        If ds.Tables("uu").Rows.Count > 0 Then
            nr = ds.Tables("uu").Rows(0)
        Else
            nr = context.Tables.AddNewRow(ds.Tables("uu"))
            nr("ContentUnitID") = ContentUnitID
            nr("UserID") = context.Police.UniqueUserID
            nr("CreatedOn") = TaskProviderFactory.FindLocalTime
        End If
        nr("StartedOn") = TaskProviderFactory.FindLocalTime
        context.Provider.objSQLHelper.SaveResults(ds.Tables("UU"), dic("uu"))
        Return nr
    End Function
End Class
