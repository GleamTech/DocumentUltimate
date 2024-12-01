Imports GleamTech.DocumentUltimate.AspNet.UI

Namespace Controllers
    Partial Public Class  DocumentViewerController
        Inherits Controller

        Public Function UsingLayout() As ActionResult
            Dim documentViewer = New DocumentViewer() With {
                    .Width = 960,
                    .Height = 720,
                    .Resizable = True,
                    .Document = "~/App_Data/ExampleFiles/Default.pdf"
                    }

            Return View(documentViewer)
        End Function

    End Class
End Namespace
