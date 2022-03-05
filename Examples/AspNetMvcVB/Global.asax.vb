Imports System.Web.Mvc
Imports System.Web.Routing
Imports System.IO
Imports GleamTech.AspNet
Imports GleamTech.DocumentUltimate

Public Class MvcApplication
    Inherits System.Web.HttpApplication

    Protected Sub Application_Start()
        AreaRegistration.RegisterAllAreas()
        RouteConfig.RegisterRoutes(RouteTable.Routes)

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
