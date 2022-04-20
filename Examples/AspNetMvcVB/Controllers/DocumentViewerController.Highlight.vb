Imports GleamTech.DocumentUltimate.AspNet.UI

Namespace Controllers
    Partial Public Class  DocumentViewerController
        Inherits Controller

    Public Function Highlight() As ActionResult
		Dim documentViewer = New DocumentViewer() With {
			.Width = 800,
			.Height = 600,
			.Resizable = True,
			.Document = "~/App_Data/ExampleFiles/Default.doc",
			.SearchOptions = New DocumentViewerSearchOptions With
		        {
		            .Term = "ancient mariner",
		            .MatchOptions = DocumentViewerMatchOptions.MatchAnyWord
		        }
		}

		Return View(documentViewer)
	End Function

    End Class
End Namespace
