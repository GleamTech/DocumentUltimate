Imports System.IO
Imports GleamTech.DocumentUltimate

Public Class Global_asax
    Inherits HttpApplication

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        Dim licenseFile = Server.MapPath("~/App_Data/License.dat")
        If File.Exists(licenseFile) Then
	        DocumentUltimateConfiguration.Current.LicenseKey = File.ReadAllText(licenseFile)
        End If
    End Sub

End Class