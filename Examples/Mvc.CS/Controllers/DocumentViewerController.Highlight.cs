using System.Web.Mvc;
using GleamTech.DocumentUltimate.Web;

namespace GleamTech.DocumentUltimateExamples.Mvc.CS.Controllers
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
                Document = "~/App_Data/ExampleFiles/DOC Document.doc",
                HighlightedKeywords = new []{ "ancient", "ship"}
                //You can also split your whole search term into keywords like this:
                //HighlightedKeywords = "ancient ship".Split(new [] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            };

            return View(documentViewer);
        }
    }
}