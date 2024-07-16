using GleamTech.DocumentUltimate.AspNet.UI;
using Microsoft.AspNetCore.Mvc;

namespace GleamTech.DocumentUltimateExamples.AspNetCoreOnNetFullCS.Controllers
{
    public partial class DocumentViewerController
    {
        public IActionResult UsingLayout()
        {
            var documentViewer = new DocumentViewer
            {
                Width = 800,
                Height = 600,
                Resizable = true,
                Document = "~/App_Data/ExampleFiles/Default.pdf"
            };

            return View(documentViewer);
        }
    }
}
