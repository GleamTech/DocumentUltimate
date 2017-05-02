Imports GleamTech.DocumentUltimate.Web
Imports GleamTech.ExamplesCore

Namespace Controllers
    Partial Public Class  DocumentViewerController
        Inherits Controller

        <AcceptVerbs(HttpVerbs.Get Or HttpVerbs.Post)>
	    Public Function Events(fileSelector As String) As ActionResult
            Dim exampleFileSelector =  new ExampleFileSelector() With {
                .ID = "exampleFileSelector",
                .InitialFile = "PDF Document.pdf"
            }
            ViewBag.ExampleFileSelector = exampleFileSelector

		    Dim documentViewer = New DocumentViewer() With { 
			    .Width = 800, 
			    .Height = 600,
                .Resizable = True,
			    .Document = exampleFileSelector.SelectedFile,
		        .ClientLoad = "documentViewerLoad",
		        .ClientError = "documentViewerError",
		        .ClientDocumentLoad = "documentViewerDocumentLoad",
		        .ClientPageChange = "documentViewerPageChange",
		        .ClientPageComplete = "documentViewerPageComplete",
		        .ClientPrint = "documentViewerPrint",
		        .ClientDownload = "documentViewerDownload",
		        .ClientDownloadAsPdf = "documentViewerDownloadAsPdf",
		        .ClientPrintStart = "documentViewerPrintStart",
		        .ClientPrintProgress = "documentViewerPrintProgress"
		    }

		    Return View(documentViewer)
	    End Function

    End Class
End Namespace
