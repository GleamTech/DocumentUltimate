using System.Web.Mvc;
using GleamTech.DocumentUltimate.AspNet.UI;

namespace GleamTech.DocumentUltimateExamples.AspNetMvcCS.Controllers
{
    public partial class DocumentViewerController
    {
        public ActionResult UsingPartial()
        {
            var documentViewer = GetDocumentViewerModel();

            return View(documentViewer);
        }

        public ActionResult DocumentViewerPartialView()
        {
            var documentViewer = GetDocumentViewerModel();

            return PartialView(documentViewer);
        }

        private DocumentViewer GetDocumentViewerModel()
        {
            var documentViewer = new DocumentViewer
            {
                Width = 960,
                Height = 720,
                Resizable = true,
                Document = "~/App_Data/ExampleFiles/Default.pdf"
            };

            return documentViewer;
        }
    }
}