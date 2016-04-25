Namespace DocumentViewer
    Public Class HighlightPage
        Inherits Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            documentViewer.HighlightedKeywords = new String(){"ancient", "ship"}
            'You can also split your whole search term into keywords like this:
            'documentViewer.HighlightedKeywords = "ancient ship".Split(new String() { " " }, StringSplitOptions.RemoveEmptyEntries)
        End Sub

    End Class
End NameSpace