' Note: For instructions on enabling IIS6 or IIS7 classic mode, 
' visit http://go.microsoft.com/?LinkId=9394802
Imports System.IO
Imports GleamTech.AspNet
Imports GleamTech.DocumentUltimate

Public Class MvcApplication
    Inherits System.Web.HttpApplication

    Shared Sub RegisterRoutes(ByVal routes As RouteCollection)
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}")

        ' MapRoute takes the following parameters, in order:
        ' (1) Route name
        ' (2) URL with parameters
        ' (3) Parameter defaults
        routes.MapRoute(
            "Default",
            "{controller}/{action}/{id}",
            New With {.controller = "Home", .action = "Index", .id = UrlParameter.Optional}
        )

    End Sub

    Sub Application_Start()
        AreaRegistration.RegisterAllAreas()

        RegisterRoutes(RouteTable.Routes)

        Dim gleamTechConfig = Hosting.ResolvePhysicalPath("~/App_Data/GleamTech.config")
        If File.Exists(gleamTechConfig) Then
            GleamTechConfiguration.Current.Load(gleamTechConfig)
        End If

        Dim documentUltimateConfig = Hosting.ResolvePhysicalPath("~/App_Data/DocumentUltimate.config")
        If File.Exists(documentUltimateConfig) Then
            DocumentUltimateConfiguration.Current.Load(documentUltimateConfig)
        End If
    End Sub
End Class
