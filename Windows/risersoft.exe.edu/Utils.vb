Imports risersoft.app.shared
Imports risersoft.shared.win
Imports risersoft.app.accounts
Imports risersoft.shared
Imports risersoft.app2.shared
Imports risersoft.shared.DotnetFx

Public Class Utils
    Public Shared Sub Main(ByVal args() As String)
        myApp = New clsRSWinCloudApp(New clsExtendAppProj)
        myWinApp.CheckInitConsole(args)
        Dim fMain As frmMax = AppStarter.StartWinFormApp(args)
        If Not fMain Is Nothing Then
            Application.Run(fMain)
        End If
    End Sub
End Class

'            TaskProviderFactory.ExecuteAgain(myApp.Controller, "5900c860-e605-4e6e-b8e0-4cf388e3be79", myApp.Controller.CalcQueueName)
