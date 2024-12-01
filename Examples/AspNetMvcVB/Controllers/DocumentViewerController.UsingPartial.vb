Imports GleamTech.DocumentUltimate.AspNet.UI

Namespace Controllers
    Partial Public Class  DocumentViewerController
        Inherits Controller

        Public Function UsingPartial() As ActionResult
            Dim documentViewer = GetDocumentViewerModel()

            Return View(documentViewer)
        End Function

        Public Function DocumentViewerPartialView() As ActionResult
            Dim documentViewer = GetDocumentViewerModel()

            Return PartialView(documentViewer)
        End Function

        Private Function GetDocumentViewerModel() As DocumentViewer
            Dim documentViewer = New DocumentViewer() With {
                .Width = 960,
                .Height = 720,
                .Resizable = True,
                .Document = "~/App_Data/ExampleFiles/Default.pdf"
            }

            Return documentViewer
        End Function
    End Class
End Namespace
