Imports GleamTech.DocumentUltimate.AspNet.UI

Namespace Controllers
    Partial Public Class  DocumentViewerController
        Inherits Controller

	    Public Function Protection() As ActionResult
		    Dim documentViewer = New DocumentViewer() With {
			    .Width = 800,
			    .Height = 600,
			    .Resizable = True,
			    .Document = "~/App_Data/ExampleFiles/Default.pdf",
                .DownloadEnabled = False,
                .DownloadAsPdfEnabled = False,
                .PrintEnabled = False,
                .TextSelectionEnabled = False
		    }

		    Return View(documentViewer)
	    End Function

    End Class
End Namespace
