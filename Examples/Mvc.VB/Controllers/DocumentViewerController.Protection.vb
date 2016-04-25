Imports GleamTech.DocumentUltimate.Web

Namespace Controllers
    Partial Public Class  DocumentViewerController
        Inherits Controller

	    Public Function Protection() As ActionResult
		    Dim documentViewer = New DocumentViewer() With {
			    .Width = 800,
			    .Height = 600,
			    .Resizable = True,
			    .DocumentPath = "~/App_Data/PDF Document.pdf",
			    .DisableDownload = True,
			    .DisablePrint = True,
			    .DisableTextSelection = True
		    }

		    Return View(documentViewer)
	    End Function

    End Class
End Namespace
