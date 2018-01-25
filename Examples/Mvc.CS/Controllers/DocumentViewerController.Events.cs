using System.Web.Mvc;
using GleamTech.DocumentUltimate.AspNet.UI;
using GleamTech.Examples;

namespace GleamTech.DocumentUltimateExamples.Mvc.CS.Controllers
{
    public partial class DocumentViewerController
    {
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Events()
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