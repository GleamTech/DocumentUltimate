using GleamTech.DocumentUltimate.AspNet.UI;
using Microsoft.AspNetCore.Mvc;

namespace GleamTech.DocumentUltimateExamples.AspNetCoreCS.Controllers
{
    public partial class DocumentViewerController
    {
        public IActionResult Protection()
        {
            var documentViewer = new DocumentViewer
            {
                Width = 960,
                Height = 720,
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
