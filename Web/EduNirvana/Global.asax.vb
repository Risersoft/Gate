Imports System.Net
Imports System.Security.Claims
Imports System.Web.Helpers
Imports System.Web.Hosting
Imports System.Web.Http
Imports System.Web.Optimization
Imports AutoMapper
Imports FluentScheduler
Imports risersoft.API.GSTN
Imports risersoft.app.mxform.gst
Imports risersoft.shared
Imports risersoft.shared.agent
Imports risersoft.shared.web
Imports risersoft.shared.web.mvc
Public Class MvcApplication
    Inherits System.Web.HttpApplication

    Protected Sub Application_Start()
        Dim oApp = New clsMvcWebApp(New clsExtendWebAppPrj)
        'myFuncs2.InitializeMapper()
        GlobalWeb.myWebApp = oApp
        HostingEnvironment.RegisterVirtualPathProvider(oApp.fncVirutalPathProvider())
        ControllerBuilder.Current.SetControllerFactory(GetType(MyControllerFactory))
        AreaRegistration.RegisterAllAreas()
        GlobalConfiguration.Configure(AddressOf WebApiConfig.Register)
        FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters)
        RouteConfig.RegisterRoutes(RouteTable.Routes)
        BundleConfig.RegisterBundles(BundleTable.Bundles)
        AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.NameIdentifier
        Dim razorEngine = ViewEngines.Engines.OfType(Of RazorViewEngine)().FirstOrDefault()
        razorEngine.ViewLocationFormats = razorEngine.ViewLocationFormats.Concat(New String() {"~/Views/Forms/{0}.cshtml", "~/Views/Forms/{0}.vbhtml"}).ToArray()
        razorEngine.PartialViewLocationFormats = razorEngine.PartialViewLocationFormats.Concat(New String() {"~/Views/Forms/{0}.cshtml", "~/Views/Forms/{0}.vbhtml"}).ToArray()


        Dim host = myUtils.cStrTN(System.Configuration.ConfigurationManager.AppSettings("TaskHostName"))

        If String.IsNullOrEmpty(host) OrElse (myUtils.IsInList(Environment.MachineName, host.Split(","))) Then
            Dim Registry = New Registry()
            Registry.Schedule(Of TimedServiceJob)().ToRunNow.AndEvery(5).Minutes()
            JobManager.Initialize(Registry)
        End If

    End Sub
End Class

Public Class TimedServiceJob
    Implements IJob, IRegisteredObject

    Private TimeSpan As New TimeSpan(0, 2, 0)
    Private ReadOnly LockObject As New Object
    Private IsShuttingDown As Boolean

    Public Sub New()
        HostingEnvironment.RegisterObject(Me)
    End Sub

    Public Async Sub Execute() Implements IJob.Execute
        Try
            Dim scheduler = New clsTaskScheduler(GlobalWeb.myWebApp, False) With {.ExecuteByAgent = True}
            Await (scheduler.RunServerApiTask("Email", "", "TalentDemo1,class6"))

        Catch ex As Exception
        Finally
            HostingEnvironment.UnregisterObject(Me)
        End Try
    End Sub

    Public Sub [Stop](immediate As Boolean) Implements IRegisteredObject.Stop
        SyncLock LockObject
            IsShuttingDown = True
        End SyncLock

        HostingEnvironment.UnregisterObject(Me)
    End Sub
End Class
