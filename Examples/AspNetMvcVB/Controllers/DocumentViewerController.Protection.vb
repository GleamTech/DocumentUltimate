Imports GleamTech.DocumentUltimate.AspNet.UI

Namespace Controllers
    Partial Public Class  DocumentViewerController
        Inherits Controller

	    Public Function Protection() As ActionResult
		    Dim documentViewer = New DocumentViewer() With {
			    .Width = 960,
			    .Height = 720,
			    .Resizable = True,
			    .Document = "~/App_Data/ExampleFiles/Default.pdf",
                .DeniedPermissions = DocumentViewerPermissions.Download _
                                     Or DocumentViewerPermissions.DownloadAsPdf _
	                                 Or DocumentViewerPermissions.Print _
                                     Or DocumentViewerPermissions.SelectText
		    }

		    Return View(documentViewer)
	    End Function

    End Class
End Namespace
