Imports System.Drawing
Imports System.IO
Imports Newtonsoft.Json
Imports risersoft.shared
Imports risersoft.shared.cloud

Public Class EMailTaskProvider
    Inherits clsTaskProviderBase
    Public Overrides ReadOnly Property IsApiTask As Boolean = True

    Public Sub New(controller As clsAppController)
        MyBase.New(controller)
    End Sub

    Public Overrides Async Function ExecuteServer(rTask As DataRow, input As clsProcOutput) As Task(Of clsProcOutput)
        Dim oRet As New clsProcOutput
        Dim Params = JsonConvert.DeserializeObject(Of Dictionary(Of String, String))(myUtils.cStrTN(rTask("infojson")))
        'Dim filepath = myFuncs.DownloadIfReqd(myContext, rTask, Params("path"))
        Dim dicResult As New clsCollecString(Of String)

        Dim service = New GoogleService()
        Dim lst = Await service.GetContentEmails(myContext)

        For Each msg In lst
            Try
                Dim strHTML = service.GetBody(msg.OrigMessage, "text/html")
                If Not myUtils.StartsWith(strHTML.Trim, "<html>") Then
                    strHTML = "<HTML><BODY>" & strHTML & "</BODY></HTML>"
                End If
                Dim course = If(msg.To.Contains(myContext.Controller.CalcAccountName), msg.To, msg.Cc).Replace("""", "").Split(";"c, ","c)(0).Split("+"c)(0)
                Dim dic As New clsCollecString(Of String)
                Dim strf1 = $"replace(coursecode,' ','-')='{course}' or replace(coursename,' ','-')='{course}'"
                dic.Add("course", $"select courseid from course where " & strf1)
                dic.Add("cu", $"select * from contentunit where messageid='{msg.MessageId}' and courseid in (select courseid from course where " & strf1 & ")")
                dic.Add("index", "select max(sortindex) as sortindex from contentunit where courseid in (select courseid from course where " & strf1 & ")")
                Dim ds = myContext.DataProvider.objSQLHelper.ExecuteDataset(CommandType.Text, dic)
                If ds.Tables(0).Rows.Count > 0 Then
                    Dim nr As DataRow
                    If ds.Tables("cu").Rows.Count > 0 Then
                        nr = ds.Tables("cu").Rows(0)
                    Else
                        nr = myContext.Tables.AddNewRow(ds.Tables("cu"))
                        nr("sortindex") = myUtils.MaxVal(ds.Tables("index"), "sortindex") + 1
                    End If
                    Dim str1 = System.IO.Path.Combine(myContext.App.objAppExtender.MapPath(".\App_Data\downloads"), myContext.Controller.CalcRLSId.ToString, msg.MessageId.ToString)
                    Dim lst2 = service.GetAttachments(msg.OrigMessage, "me", str1)
                    If lst2.Count = 0 Then
                        nr("contenttype") = "html"
                        nr("contenthtml") = strHTML
                        nr("contenttext") = service.GetBody(msg.OrigMessage, "text/plain")
                        nr("title") = msg.Subject
                    Else
                        Dim strFile As String, cont As Boolean = True
                        If lst2.Count > 1 Then
                            strFile = System.Guid.NewGuid.ToString & "-" & myContext.FTP.GetTempLocalFileWithSameName(msg.MessageId & ".pdf")
                            strFile = myContext.App.objAppExtender.MapPath("app_data/payload/" & System.IO.Path.GetFileNameWithoutExtension(strFile) & ".pdf")
                            cont = myPDFConverter.ConvertImagesToPDF(myContext, lst2, strFile)
                        Else
                            strFile = lst2(0)
                        End If
                        If cont Then
                            Dim docType = myEduFuncs.DocTypeFromFileExt(System.IO.Path.GetExtension(strFile))
                            If Not String.IsNullOrEmpty(docType) Then
                                Dim imgFileName As String = myContext.Controller.CalcRLSId.ToString & $"-Document-process-" & Replace(Now.ToLongTimeString, ":", "").Replace(" ", "") & ".png"
                                Dim oRet2 = Await myEduFuncs.ProcessFileAsync(myContext, strFile, imgFileName, docType)
                                If oRet2.Success Then
                                    nr("contenttype") = "upload"
                                    nr("doctype") = docType
                                    nr("title") = msg.Subject
                                    Dim client = myContext.App.objAppExtender.FileProviderClient(myContext, myPathUtils.GetContainerName(myContext))
                                    Dim BlobName = client.Upload(strFile, System.IO.Path.GetFileName(strFile), "")
                                    nr("contentfilepath") = BlobName
                                    If oRet2.DictData.ContainsKey("pdf") Then nr("contentpdfpath") = oRet2.DictData("pdf")
                                    If oRet2.DictData.ContainsKey("img") Then nr("contentimagepath") = oRet2.DictData("img")
                                    For Each kvp In oRet2.DictData
                                        If nr.Table.Columns.Contains(kvp.Key) Then nr(kvp.Key) = kvp.Value
                                    Next
                                    nr("noteshtml") = strHTML
                                    nr("notestext") = service.GetBody(msg.OrigMessage, "text/plain")
                                Else
                                    oRet.AddError(oRet2.Message & vbCrLf & oRet2.StackTrace)
                                End If
                            End If
                        End If
                    End If
                    If myUtils.cStrTN(nr("title")).Trim.Length > 0 Then
                        nr("messageid") = msg.MessageId
                        nr("courseid") = ds.Tables(0).Rows(0)("courseid")
                        myContext.DataProvider.objSQLHelper.SaveResults(ds.Tables(1), dic(1))
                    Else
                        nr.Delete()
                    End If
                End If

                service.ModifyMessage("me", msg.MessageId, New List(Of String) From {myContext.Controller.CalcAccountName}, New List(Of String) From {"Inbox"})
            Catch ex As Exception

            End Try
        Next



        rTask("resultjson") = JsonConvert.SerializeObject(dicResult)

        Return oRet
    End Function


End Class

'https://stackoverflow.com/questions/38390197/how-to-create-a-instance-of-usercredential-if-i-already-have-the-value-of-access