using GleamTech.DocumentUltimate.AspNet.UI;
using Microsoft.AspNetCore.Mvc;

namespace GleamTech.DocumentUltimateExamples.AspNetCoreCS.Controllers
{
    public partial class DocumentViewerController
    {
        public IActionResult UsingPartial()
        {
            var documentViewer = GetDocumentViewerModel();

            return View(documentViewer);
        }

        public IActionResult DocumentViewerPartialView()
        {
            var documentViewer = GetDocumentViewerModel();

            return PartialView(documentViewer);
        }

        private DocumentViewer GetDocumentViewerModel()
        {
            var documentViewer = new DocumentViewer
            {
                Width = 800,
                Height = 600,
                Resizable = true,
                Document = "~/App_Data/ExampleFiles/Default.pdf"
            };

            return documentViewer;
        }
    }
}
