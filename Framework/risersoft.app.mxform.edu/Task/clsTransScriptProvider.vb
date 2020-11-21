Imports Newtonsoft.Json
Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Net
Imports System.Threading.Tasks
Imports System.Net.Http
Imports System.Net.Http.Formatting
Imports Microsoft.CognitiveServices.Speech
Imports Microsoft.CognitiveServices.Speech.Audio
'https://docs.microsoft.com/en-in/azure/cognitive-services/speech-service/quickstarts/speech-to-text-from-file?tabs=linux%2Cbrowser&pivots=programming-language-csharp
Public Class clsTransScriptProvider
    Const SubscriptionKey As String = "419380434a384d5089614b8386a3784b"
    Const Region As String = "centralindia"
    Const Port As Integer = 443
    Const Locale As String = "en-US"
    Const Name As String = "Simple transcription"
    Const Description As String = "Simple transcription description"
    Const SpeechToTextBasePath As String = "api/speechtotext/v2.0/"

    Public Async Function RecognizeSpeechAsync(fileName As String) As Task(Of String)
        Dim config = SpeechConfig.FromSubscription(SubscriptionKey, Region)
        Dim output As String = ""
        Using audioInput = AudioConfig.FromWavFileInput(fileName)

            Using recognizer = New SpeechRecognizer(config, audioInput)
                Console.WriteLine("Recognizing first result...")
                Dim result = Await recognizer.RecognizeOnceAsync()

                Select Case result.Reason
                    Case ResultReason.RecognizedSpeech
                        output = result.Text
                        Console.WriteLine($"We recognized: {result.Text}")
                    Case ResultReason.NoMatch
                        Console.WriteLine($"NOMATCH: Speech could not be recognized.")
                    Case ResultReason.Canceled
                        Dim cancellation = CancellationDetails.FromResult(result)
                        Console.WriteLine($"CANCELED: Reason={cancellation.Reason}")

                        If cancellation.Reason = CancellationReason.[Error] Then
                            Console.WriteLine($"CANCELED: ErrorCode={cancellation.ErrorCode}")
                            Console.WriteLine($"CANCELED: ErrorDetails={cancellation.ErrorDetails}")
                            Console.WriteLine($"CANCELED: Did you update the subscription info?")
                        End If
                End Select
            End Using
        End Using
        Return output
    End Function
    Private Shared Async Function TranscribeAsync(RecordingsBlobUri As String) As Task(Of String)
        Dim results As String = ""
        Console.WriteLine("Starting transcriptions client...")

        ' Create the client object And authenticate
        Dim client = New HttpClient With {
               .Timeout = TimeSpan.FromMinutes(25),
               .BaseAddress = New UriBuilder(Uri.UriSchemeHttps, $"{Region}.cris.ai", Port).Uri}
        client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", SubscriptionKey)

        Dim def = TranscriptionDefinition.Create(Name, Description, Locale, New Uri(RecordingsBlobUri))
        Dim res = JsonConvert.SerializeObject(def)
        Dim sc = New StringContent(res)
        sc.Headers.ContentType = JsonMediaTypeFormatter.DefaultMediaType
        Dim transcriptionLocation As Uri = Nothing

        Using response = Await client.PostAsync($"{SpeechToTextBasePath}Transcriptions/", sc)

            If Not response.IsSuccessStatusCode Then
                Console.WriteLine("Error {0} starting transcription.", response.StatusCode)
                Return ""
            End If

            transcriptionLocation = response.Headers.Location
        End Using

        Console.WriteLine($"Created transcription at location {transcriptionLocation}.")
        Console.WriteLine("Checking status.")
        Dim completed = False

        While Not completed
            Dim transcription As Transcription = Nothing

            Using response = Await client.GetAsync(transcriptionLocation.AbsolutePath)
                Dim contentType = response.Content.Headers.ContentType

                If response.IsSuccessStatusCode AndAlso String.Equals(contentType.MediaType, "application/json", StringComparison.OrdinalIgnoreCase) Then
                    transcription = Await response.Content.ReadAsAsync(Of Transcription)()
                Else
                    Console.WriteLine("Error with status {0} getting transcription result", response.StatusCode)
                    Continue While
                End If
            End Using

            Select Case transcription.Status
                Case "Failed"
                    completed = True
                    Console.WriteLine("Transcription failed. Status: {0}", transcription.StatusMessage)
                Case "Succeeded"
                    completed = True
                    Dim webClient = New WebClient()
                    Dim filename = Path.GetTempFileName()
                    webClient.DownloadFile(transcription.ResultsUrls("channel_0"), filename)
                    results = File.ReadAllText(filename)
                    Console.WriteLine($"Transcription succeeded. Results: {Environment.NewLine}{results}")
                    File.Delete(filename)
                Case "Running"
                    Console.WriteLine("Transcription is still running.")
                Case "NotStarted"
                    Console.WriteLine("Transcription has not started.")
            End Select

            Await Task.Delay(TimeSpan.FromSeconds(5))
        End While

        Console.WriteLine("Press any key...")
        Console.ReadKey()
        Return results
    End Function
End Class

Public Class ModelIdentity
    Private Sub New(ByVal id As Guid)
        Me.Id = id
    End Sub

    Public Property Id As Guid

    Public Shared Function Create(ByVal Id As Guid) As ModelIdentity
        Return New ModelIdentity(Id)
    End Function

End Class

Public Class Transcription
    <JsonConstructor>
    Private Sub New(ByVal id As Guid, ByVal name As String, ByVal description As String, ByVal locale As String, ByVal createdDateTime As DateTime, ByVal lastActionDateTime As DateTime, ByVal status As String, ByVal recordingsUrl As Uri, ByVal resultsUrls As IReadOnlyDictionary(Of String, String))
        id = id
        name = name
        description = description
        createdDateTime = createdDateTime
        lastActionDateTime = lastActionDateTime
        status = status
        locale = locale
        recordingsUrl = recordingsUrl
        resultsUrls = resultsUrls
    End Sub

    Public Property Name As String
    Public Property Description As String
    Public Property Locale As String
    Public Property RecordingsUrl As Uri
    Public Property ResultsUrls As IReadOnlyDictionary(Of String, String)
    Public Property Id As Guid
    Public Property CreatedDateTime As DateTime
    Public Property LastActionDateTime As DateTime
    Public Property Status As String
    Public Property StatusMessage As String


End Class

Public Class TranscriptionDefinition
    Private Sub New(ByVal name As String, ByVal description As String, ByVal locale As String, ByVal recordingsUrl As Uri, ByVal models As IEnumerable(Of ModelIdentity))
        name = name
        description = description
        recordingsUrl = recordingsUrl
        locale = locale
        models = models
        Properties = New Dictionary(Of String, String) From {
            {"PunctuationMode", "DictatedAndAutomatic"},
                {"ProfanityFilterMode", "Masked"},
                {"AddWordLevelTimestamps", "True"}}


    End Sub

    Public Property Name As String
    Public Property Description As String
    Public Property RecordingsUrl As Uri
    Public Property Locale As String
    Public Property Models As IEnumerable(Of ModelIdentity)
    Public Property Properties As IDictionary(Of String, String)

    Public Shared Function Create(ByVal name As String, ByVal description As String, ByVal locale As String, ByVal recordingsUrl As Uri) As TranscriptionDefinition
        Return New TranscriptionDefinition(name, description, locale, recordingsUrl, New ModelIdentity(-1) {})
    End Function
End Class
