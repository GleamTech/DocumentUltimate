using GleamTech.DocumentUltimate.AspNet.UI;
using GleamTech.Examples;
using Microsoft.AspNetCore.Mvc;

namespace GleamTech.DocumentUltimateExamples.AspNetCore.CS.Controllers
{
    public partial class DocumentViewerController
    {
        [HttpPost]
        [HttpGet]
        public IActionResult Events()
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
                ClientLoad = "documentViewerLoad",
                ClientError = "documentViewerError",
                ClientDocumentLoad = "documentViewerDocumentLoad",
                ClientPageChange = "documentViewerPageChange",
                ClientPageComplete = "documentViewerPageComplete",
                ClientRotationChange = "documentViewerRotationChange",
                ClientPrint = "documentViewerPrint",
                ClientDownload = "documentViewerDownload",
                ClientDownloadAsPdf = "documentViewerDownloadAsPdf",
                ClientPrintStart = "documentViewerPrintStart",
                ClientPrintProgress = "documentViewerPrintProgress"
            };

            return View(documentViewer);
        }
    }
}