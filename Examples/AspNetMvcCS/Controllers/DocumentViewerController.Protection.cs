using System.Web.Mvc;
using GleamTech.DocumentUltimate.AspNet.UI;

namespace GleamTech.DocumentUltimateExamples.AspNetMvcCS.Controllers
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
                DeniedPermissions = DocumentViewerPermissions.Download 
                                    | DocumentViewerPermissions.DownloadAsPdf 
                                    | DocumentViewerPermissions.Print 
                                    | DocumentViewerPermissions.SelectText
            };

            return View(documentViewer);
        }
    }
}