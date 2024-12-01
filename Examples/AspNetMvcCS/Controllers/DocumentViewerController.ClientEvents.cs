using System.Web.Mvc;
using GleamTech.DocumentUltimate.AspNet.UI;
using GleamTech.Examples;

namespace GleamTech.DocumentUltimateExamples.AspNetMvcCS.Controllers
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
                Width = 960,
                Height = 720,
                Resizable = true,
                Document = exampleFileSelector.SelectedFile.ToString(),
                ClientEvents = new DocumentViewerClientEvents {
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
