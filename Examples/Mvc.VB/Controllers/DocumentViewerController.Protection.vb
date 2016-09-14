Imports GleamTech.DocumentUltimate.Web

Namespace Controllers
    Partial Public Class  DocumentViewerController
        Inherits Controller

	    Public Function Protection() As ActionResult
		    Dim documentViewer = New DocumentViewer() With {
			    .Width = 800,
			    .Height = 600,
			    .Resizable = True,
			    .Document = "~/App_Data/ExampleFiles/PDF Document.pdf",
                .DownloadEnabled = False,
                .DownloadAsPdfEnabled = False,
                .PrintEnabled = False,
                .TextSelectionEnabled = False
		    }

		    Return View(documentViewer)
	    End Function

    End Class
End Namespace
