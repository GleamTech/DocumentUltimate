Imports GleamTech.DocumentUltimate.Web
Imports GleamTech.ExamplesCore

Namespace Controllers
    Partial Public Class  DocumentViewerController
        Inherits Controller

        <AcceptVerbs(HttpVerbs.Get Or HttpVerbs.Post)>
	    Public Function Overview(fileSelector As String) As ActionResult
            Dim exampleFileSelector =  new ExampleFileSelector() With {
                .ID = "exampleFileSelector",
                .InitialFile = "PDF Document.pdf"
            }
            ViewBag.ExampleFileSelector = exampleFileSelector

		    Dim documentViewer = New DocumentViewer() With { 
			    .Width = 800, 
			    .Height = 600, 
			    .Document = exampleFileSelector.SelectedFile
		    }

		    Return View(documentViewer)
	    End Function

    End Class
End Namespace
