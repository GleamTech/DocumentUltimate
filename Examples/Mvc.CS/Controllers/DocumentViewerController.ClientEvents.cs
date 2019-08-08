using System.Web.Mvc;
using GleamTech.DocumentUltimate.AspNet.UI;
using GleamTech.Examples;

namespace GleamTech.DocumentUltimateExamples.Mvc.CS.Controllers
{
    public partial class DocumentViewerController
    {
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult ClientEvents()
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
                ClientEvents = new DocumentViewerClientEvents {
                    Loaded = "documentViewerLoaded",
                    Failed = "documentViewerFailed",
                    DocumentLoaded = "documentViewerDocumentLoaded",
                    PageChanged = "documentViewerPageChanged",
                    PageRendered = "documentViewerPageRendered",
                    RotationChanged = "documentViewerRotationChanged",
                    Downloading = "documentViewerDownloading",
                    Printing = "documentViewerPrinting",
                    PrintProgress = "documentViewerPrintProgress",
                    Printed = "documentViewerPrinted",
                    TextSelected = "documentViewerTextSelected",
                    TextCopied = "documentViewerTextCopied"
                }
            };

            return View(documentViewer);
        }
    }
}