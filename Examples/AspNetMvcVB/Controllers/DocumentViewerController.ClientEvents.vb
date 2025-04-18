Imports GleamTech.DocumentUltimate.AspNet.UI
Imports GleamTech.Examples

Namespace Controllers
    Partial Public Class  DocumentViewerController
        Inherits Controller

        <AcceptVerbs(HttpVerbs.Get Or HttpVerbs.Post)>
        Public Function ClientEvents(fileSelector As String) As ActionResult
            Dim exampleFileSelector = New ExampleFileSelector() With {
                .Id = "exampleFileSelector",
                .InitialFile = "Default.pdf"
            }
            ViewBag.ExampleFileSelector = exampleFileSelector

            Dim documentViewer = New DocumentViewer() With {
                .Width = 960,
                .Height = 720,
                .Resizable = True,
                .Document = exampleFileSelector.SelectedFile.ToString(),
                .ClientEvents = New DocumentViewerClientEvents() With {
                    .Loaded = "documentViewerLoaded",
                    .Failed = "documentViewerFailed",
                    .DocumentLoaded = "documentViewerDocumentLoaded",
                    .PageChanged = "documentViewerPageChanged",
                    .PageRendered = "documentViewerPageRendered",
                    .RotationChanged = "documentViewerRotationChanged",
                    .Downloading = "documentViewerDownloading",
                    .Printing = "documentViewerPrinting",
                    .Printed = "documentViewerPrinted",
                    .TextSelected = "documentViewerTextSelected",
                    .TextCopied = "documentViewerTextCopied"
                }
            }

            Return View(documentViewer)
        End Function

    End Class
End Namespace
