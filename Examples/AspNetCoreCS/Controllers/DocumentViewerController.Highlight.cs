using GleamTech.DocumentUltimate.AspNet.UI;
using Microsoft.AspNetCore.Mvc;

namespace GleamTech.DocumentUltimateExamples.AspNetCoreCS.Controllers
{
    public partial class DocumentViewerController
    {
        public IActionResult Highlight()
        {
            var documentViewer = new DocumentViewer
            {
                Width = 960,
                Height = 720,
                Resizable = true,
                Document = "~/App_Data/ExampleFiles/Default.doc",
                SearchOptions =
                {
                    Term = "ancient mariner",
                    MatchOptions = DocumentViewerMatchOptions.MatchAnyWord
                }
            };

            return View(documentViewer);
        }
    }
}
