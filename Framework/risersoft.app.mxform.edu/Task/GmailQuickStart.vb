Imports Google.Apis.Auth.OAuth2
Imports Google.Apis.Gmail.v1
Imports Google.Apis.Gmail.v1.Data
Imports Google.Apis.Services
Imports Google.Apis.Util.Store
Imports risersoft.shared
Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Reflection
Imports System.Text
Imports System.Threading
Imports System.Threading.Tasks

Public Class GmailQuickStart
    Shared Scopes As String() = {GmailService.Scope.MailGoogleCom, GmailService.Scope.GmailLabels}
    Shared ApplicationName As String = "Gmail API .NET Quickstart"

    Public Shared Sub Test()
        Dim credential As UserCredential

        Using stream = myAssy.GetStream(Assembly.GetExecutingAssembly.GetName.Name, "credentials.json")
            Dim credPath As String = "token.json"
            credential = GoogleWebAuthorizationBroker.AuthorizeAsync(GoogleClientSecrets.Load(stream).Secrets, Scopes, "user", CancellationToken.None, New FileDataStore(credPath, True)).Result
            Console.WriteLine("Credential file saved to: " & credPath)
        End Using

        Dim service = New GmailService(New BaseClientService.Initializer() With {
            .HttpClientInitializer = credential,
            .ApplicationName = ApplicationName
        })
        Dim request As UsersResource.LabelsResource.ListRequest = service.Users.Labels.List("me")
        Dim labels As IList(Of Label) = request.Execute().Labels
        Console.WriteLine("Labels:")

        If labels IsNot Nothing AndAlso labels.Count > 0 Then

            For Each labelItem In labels
                Console.WriteLine("{0}", labelItem.Name)
            Next
        Else
            Console.WriteLine("No labels found.")
        End If

        Console.Read()
    End Sub
End Class
