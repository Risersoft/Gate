Imports System.Drawing
Imports System.IO
Imports Newtonsoft.Json
Imports risersoft.shared
Imports risersoft.shared.cloud

Public Class ProcessTaskProvider
    Inherits clsTaskProviderBase
    Public Overrides ReadOnly Property IsApiTask As Boolean = True

    Public Sub New(controller As clsAppController)
        MyBase.New(controller)
    End Sub

    Public Overrides Async Function ExecuteServer(rTask As DataRow, input As clsProcOutput) As Task(Of clsProcOutput)
        Dim oRet As New clsProcOutput
        Dim Params = JsonConvert.DeserializeObject(Of Dictionary(Of String, String))(myUtils.cStrTN(rTask("infojson")))
        Dim filepath = Await myFuncs.DownloadIfReqd(myContext, rTask, Params("path"))
        Dim mailer As New MailModuleBase(myContext), oRetMail As clsProcOutput

        oRet = Await myEduFuncs.ProcessFileAsync(myContext, filepath, myUtils.cStrTN(rTask("filename")), myUtils.cStrTN(rTask("actionsubtype")))
        rTask("resultjson") = JsonConvert.SerializeObject(oRet.DictData)

        If oRet.Success Then
            oRetMail = Await mailer.SendGenericMail(myUtils.cStrTN(rTask("username")), "File processing successful", oRet.Message)
        Else
            oRetMail = Await mailer.SendGenericMail(myUtils.cStrTN(rTask("username")), "File processing could not be done", oRet.Message)
        End If
        myFuncs.DeleteIfReqd(myContext, rTask, filepath)
        If Not oRetMail Is Nothing Then
            If oRetMail.Success Then
                oRet.AddMessage("Sent Message: " & oRetMail.Message)
            Else
                Dim mailerMessage = String.Format("Message from SendGenericMailMandrill Message='{0}' StackTrace='{1}'", oRetMail.Message, oRetMail.StackTrace)
                oRet.AddMessage(mailerMessage)
            End If
        End If
        Return oRet
    End Function


End Class

