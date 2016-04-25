using System.Web.Mvc;
using GleamTech.DocumentUltimate.Web;

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
                DocumentPath = "~/App_Data/PDF Document.pdf",
                DisableDownload = true,
                DisablePrint = true,
                DisableTextSelection = true
            };

            return View(documentViewer);
        }
    }
}