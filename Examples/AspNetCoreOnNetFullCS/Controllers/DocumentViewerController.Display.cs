using GleamTech.AspNet.UI;
using GleamTech.DocumentUltimate.AspNet.UI;
using Microsoft.AspNetCore.Mvc;

namespace GleamTech.DocumentUltimateExamples.AspNetCoreOnNetFullCS.Controllers
{
    public partial class DocumentViewerController
    {
        [HttpPost]
        [HttpGet]
        public IActionResult Display()
        {
            var documentViewer1 = new DocumentViewer
            {
                Id = "documentViewer1",
                Width = 960,
                Height = 720,
                Resizable = true,
                Document = "~/App_Data/ExampleFiles/Default.pdf",
                Hidden = true
            };

            var documentViewer2 = new DocumentViewer
            {
                Id = "documentViewer2",
                Width = 960,
                Height = 720,
                Resizable = true,
                Document = "~/App_Data/ExampleFiles/Default.pdf",
                Hidden = true,
                DisplayMode = DisplayMode.Window,
                WindowOptions =
                {
                    Title = "DocumentViewer as a modal dialog",
                    Modal = true,
                    Maximizable = true,
                    Minimizable = true
                }
            };

            var documentViewer3 = new DocumentViewer
            {
                Id = "documentViewer3",
                Width = 960,
                Height = 720,
                Resizable = true,
                Document = "~/App_Data/ExampleFiles/Default.pdf",
                Hidden = true,
                DisplayMode = DisplayMode.Panel,
                PanelOptions =
                {
                    Title = "DocumentViewer as a panel",
                    Collapsible = true
                }
            };

            return View(new[] {documentViewer1, documentViewer2, documentViewer3});
        }
    }
}
