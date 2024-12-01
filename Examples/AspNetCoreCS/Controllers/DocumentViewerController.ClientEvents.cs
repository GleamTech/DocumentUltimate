using GleamTech.DocumentUltimate.AspNet.UI;
using GleamTech.Examples;
using Microsoft.AspNetCore.Mvc;

namespace GleamTech.DocumentUltimateExamples.AspNetCoreCS.Controllers
{
    public partial class DocumentViewerController
    {
        [HttpPost]
        [HttpGet]
        public IActionResult ClientEvents()
        {
            var exampleFileSelector = ViewBag.ExampleFileSelector = new ExampleFileSelector
            {
                Id = "exampleFileSelector",
                InitialFile = "Default.pdf"
            };

            var documentViewer = new DocumentViewer
            {
                Width = 960,
                Height = 720,
                Resizable = true,
                Document = exampleFileSelector.SelectedFile.ToString(),
                ClientEvents = new DocumentViewerClientEvents
                {
                    Loaded = "documentViewerLoaded",
                    Failed = "documentViewerFailed",
                    DocumentLoaded = "documentViewerDocumentLoaded",
                    PageChanged = "documentViewerPageChanged",
                    PageRendered = "documentViewerPageRendered",
                    RotationChanged = "documentViewerRotationChanged",
                    Downloading = "documentViewerDownloading",
                    Printing = "documentViewerPrinting",
                    Printed = "documentViewerPrinted",
                    TextSelected = "documentViewerTextSelected",
                    TextCopied = "documentViewerTextCopied"
                }
            };

            return View(documentViewer);
        }
    }
}
