Imports GleamTech.DocumentUltimate.Web

Namespace Controllers
    Partial Public Class  DocumentViewerController
        Inherits Controller

    Public Function Highlight() As ActionResult
		Dim documentViewer = New DocumentViewer() With {
			.Width = 800,
			.Height = 600,
			.Resizable = True,
			.Document = "~/App_Data/ExampleFiles/Default.doc",
			.HighlightedKeywords = New String () {"ancient", "ship"}
		}
        'You can also split your whole search term into keywords like this:
        '.HighlightedKeywords = "ancient ship".Split(new String() { " " }, StringSplitOptions.RemoveEmptyEntries)

		Return View(documentViewer)
	End Function

    End Class
End Namespace
