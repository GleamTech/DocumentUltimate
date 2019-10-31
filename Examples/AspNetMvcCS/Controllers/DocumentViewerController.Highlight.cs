using System.Web.Mvc;
using GleamTech.DocumentUltimate.AspNet.UI;

namespace GleamTech.DocumentUltimateExamples.AspNetMvcCS.Controllers
{
    public partial class DocumentViewerController
    {
        public ActionResult Highlight()
        {
            var documentViewer = new DocumentViewer
            {
                Width = 800,
                Height = 600,
                Resizable = true,
                Document = "~/App_Data/ExampleFiles/Default.doc",
                SearchOptions =
                {
                    Term = "ancient mariner",
                    MatchOptions = MatchOptions.MatchAnyWord
                }
            };

            return View(documentViewer);
        }
    }
}