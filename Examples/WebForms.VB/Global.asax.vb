Imports System.IO
Imports GleamTech.AspNet
Imports GleamTech.DocumentUltimate

Public Class Global_asax
    Inherits HttpApplication

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
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