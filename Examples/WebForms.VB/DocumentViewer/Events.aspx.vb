
Namespace DocumentViewer
    Public Class EventsPage
        Inherits Page

        Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
            documentViewer.Document = exampleFileSelector.SelectedFile
        End Sub

    End Class
End NameSpace
