using GleamTech.DocumentUltimate.AspNet.UI;
using GleamTech.Examples;
using Microsoft.AspNetCore.Mvc;

namespace GleamTech.DocumentUltimateExamples.AspNetCore.CS.Controllers
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
                Width = 800,
                Height = 600,
                Resizable = true,
                Document = exampleFileSelector.SelectedFile,
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
                    PrintProgress = "documentViewerPrintProgress",
                    Printed = "documentViewerPrinted"
                }
            };

            return View(documentViewer);
        }
    }
}