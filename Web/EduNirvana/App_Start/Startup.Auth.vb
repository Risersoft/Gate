Imports Microsoft.Owin
Imports Microsoft.Owin.Security
Imports Microsoft.Owin.Security.Cookies
Imports Microsoft.Owin.Security.Infrastructure
Imports Owin
Imports System.Collections.Concurrent
Imports System.Linq
Imports System.Security.Claims
Imports System.Security.Principal
Imports System.Threading.Tasks

Imports Microsoft.Owin.Infrastructure
Imports System.Collections.Generic
Imports risersoft.shared.web
Imports Microsoft.Owin.Security.DataProtection
Imports risersoft.shared.web.mvc
Imports risersoft.shared.web.common
Imports Microsoft.Owin.Security.OAuth
Imports risersoft.shared
Imports risersoft.shared.web.Util
Imports risersoft.shared.web.mvc.Util

Partial Public Class Startup

    Public Sub ConfigureAuth(app As IAppBuilder)
        ' Enable Application Sign In Cookie
        app.UseRSAuthClient()
        app.UseRSAuthBearerToken


        ServerDataSyncManager.Instance.Start()

        Dim properties = New BuilderProperties.AppProperties(app.Properties)
        Dim token = properties.OnAppDisposing
        If (token <> Threading.CancellationToken.None) Then

            token.Register(Sub()
                               ServerDataSyncManager.Instance.Stop()
                           End Sub)
        End If
    End Sub

End Class
