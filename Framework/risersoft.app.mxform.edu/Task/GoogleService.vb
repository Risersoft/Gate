Imports Google.Apis.Gmail.v1
Imports Google.Apis.Services
Imports risersoft.shared.cloud
Imports risersoft.shared
Imports Google.Apis.Gmail.v1.Data
Imports System.IO
Imports System.Text

Public Class GoogleService
    Inherits GoogleServiceBase
    Dim gmailService As GmailService = Nothing
    Protected Friend Function CheckService() As Boolean
        If gmailService Is Nothing Then
            Try
                Dim cred = GetAuthResult()

                If cred IsNot Nothing Then
                    gmailService = New GmailService(New BaseClientService.Initializer() With {
                    .HttpClientInitializer = cred,
                    .ApplicationName = GlobalCore.myCoreApp.objAppExtender.ProgramName
                })
                End If
            Catch ex As Exception
                Dim exMsg = ex
            End Try
        End If
        Return (gmailService IsNot Nothing)

    End Function
    Public Overridable Async Function GetContentEmails(context As IProviderContext) As Task(Of List(Of GmailMessage))
        Dim emails As New List(Of GmailMessage)
        Try
            If Me.CheckService Then
                Dim AccountName = context.Controller.CalcAccountName
                Dim query = "in:inbox"
                For Each msg In Me.ListMessages("me", query)
                    Dim request = gmailService.Users.Messages.Get("me", msg.Id)
                    Dim response = Await request.ExecuteAsync()
                    Dim msg2 = Me.ConvertMessage(response)
                    emails.Add(msg2)
                Next
                emails = emails.Where(Function(x) myUtils.InStrList(x.To, "+" & AccountName & "@") OrElse
                                          myUtils.InStrList(x.cc, "+" & AccountName & "@")).
                OrderByDescending(Function(s) s.ProcessedDateTime).ToList()

            End If
        Catch ex As Exception
            Dim exMsg = ex
        End Try

        Return emails
    End Function
    Public Function ListMessages(ByVal userId As String, ByVal query As String) As List(Of Message)
        Dim result As List(Of Message) = New List(Of Message)()
        If Me.CheckService Then
            Dim request As UsersResource.MessagesResource.ListRequest = gmailService.Users.Messages.List(userId)
            request.Q = query

            Do
                Try
                    Dim response As ListMessagesResponse = request.Execute()
                    result.AddRange(response.Messages)
                    request.PageToken = response.NextPageToken
                Catch e As Exception
                    Console.WriteLine("An error occurred: " & e.Message)
                End Try
            Loop While Not String.IsNullOrEmpty(request.PageToken)
        End If
        Return result
    End Function

    Public Function ListLabels(ByVal userId As String) As clsCollecString(Of String)
        Dim dic As New clsCollecString(Of String)
        Try
            If Me.CheckService Then
                Dim response As ListLabelsResponse = gmailService.Users.Labels.List(userId).Execute()

                For Each label As Label In response.Labels
                    Console.WriteLine(label.Id & " - " + label.Name)
                    dic.Add(label.Name, label.Id)
                Next

            End If

        Catch e As Exception
            Console.WriteLine("An error occurred: " & e.Message)
        End Try
        Return dic
    End Function

    Public Function ModifyMessage(ByVal userId As String, ByVal messageId As String, ByVal labelsToAdd As List(Of String), ByVal labelsToRemove As List(Of String)) As Message
        Dim mods As ModifyMessageRequest = New ModifyMessageRequest()

        Dim dic = Me.ListLabels(userId)
        For Each lbl In labelsToAdd
            If Not dic.Exists(lbl) Then
                Dim newLbl = New Label() With {.Name = lbl}
                Dim result = gmailService.Users.Labels.Create(newLbl, userId).Execute
                dic.Add(result.Name, result.Id)
            End If
        Next
        mods.AddLabelIds = labelsToAdd.Select(Function(x) dic(x)).ToList
        mods.RemoveLabelIds = labelsToRemove.Where(Function(x) dic.Exists(x)).Select(Function(x) dic(x)).ToList

        Try
            If Me.CheckService Then
                Return gmailService.Users.Messages.Modify(mods, userId, messageId).Execute()
            End If
        Catch e As Exception
            Console.WriteLine("An error occurred: " & e.Message)
        End Try

        Return Nothing
    End Function
    Public Function GetBody(msg As Message, ByVal mimetype As String) As String
        Dim result As String = ""
        'https://stackoverflow.com/questions/28527711/can-i-read-messages-from-gmail-using-gmail-api-and-c
        Try
            Console.WriteLine(msg.InternalDate)

            If msg.Payload.MimeType = mimetype Then
                Dim data As Byte() = FromBase64ForUrlString(msg.Payload.Body.Data)
                result = Encoding.UTF8.GetString(data)
            Else
                Dim parts As IList(Of MessagePart) = msg.Payload.Parts

                If parts IsNot Nothing AndAlso parts.Count > 0 Then

                    For Each part As MessagePart In parts

                        If part.MimeType = mimetype Then
                            Dim data As Byte() = FromBase64ForUrlString(part.Body.Data)
                            result = Encoding.UTF8.GetString(data)
                        End If
                    Next
                End If
            End If

            Console.WriteLine("----")

        Catch e As Exception
            Console.WriteLine("An error occurred: " & e.Message)
        End Try
        Return result
    End Function
    Public Function GetAttachments(msg As Message, userid As String, ByVal outputDir As String) As List(Of String)
        Dim lst = New List(Of String)
        Try
            Dim parts As IList(Of MessagePart) = msg.Payload.Parts
            My.Computer.FileSystem.CreateDirectory(outputDir)
            For Each part As MessagePart In parts
                If Not String.IsNullOrEmpty(part.Filename) Then
                    Dim attId As String = part.Body.AttachmentId
                    Dim attachPart As MessagePartBody = gmailService.Users.Messages.Attachments.[Get](userid, msg.Id, attId).Execute()
                    Dim attachData As String = attachPart.Data.Replace("-"c, "+"c)
                    attachData = attachData.Replace("_"c, "/"c)
                    Dim data As Byte() = Convert.FromBase64String(attachData)
                    Dim str1 = Path.Combine(outputDir, part.Filename)
                    My.Computer.FileSystem.WriteAllBytes(str1, data, False)
                    lst.Add(str1)
                End If
            Next

        Catch e As Exception
            Console.WriteLine("An error occurred: " & e.Message)
        End Try

        Return lst
    End Function
End Class
