using System.Web.Mvc;
using GleamTech.DocumentUltimate.AspNet.UI;

namespace GleamTech.DocumentUltimateExamples.Mvc.CS.Controllers
{
    public partial class DocumentViewerController
    {
        public ActionResult Protection()
        {
            var documentViewer = new DocumentViewer
            {
                Width = 800,
                Height = 600,
                Resizable = true,
                Document = "~/App_Data/ExampleFiles/Default.pdf",
                DownloadEnabled = false,
                DownloadAsPdfEnabled = false,
                PrintEnabled = false,
                TextSelectionEnabled = false
            };

            return View(documentViewer);
        }
    }
}