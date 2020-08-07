using System.Linq;
using GleamTech.AspNet;
using GleamTech.DocumentUltimate.AspNet;
using GleamTech.DocumentUltimate.AspNet.UI;
using GleamTech.Examples;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GleamTech.DocumentUltimateExamples.AspNetCoreOnNetFullCS.Controllers
{
    public partial class DocumentViewerController
    {
        [HttpPost]
        [HttpGet]
        public IActionResult Overview()
        {
            var exampleFileSelector = ViewBag.ExampleFileSelector = new ExampleFileSelector
            {
                Id = "exampleFileSelector",
                InitialFile = "Default.pdf"
            };

            var documentViewer = new DocumentViewer
            {
                Width = 800,
                Height = 600,
                Resizable = true,
                Document = exampleFileSelector.SelectedFile
            };

            HandleLanguage(documentViewer);

            return View(documentViewer);
        }

        private void HandleLanguage(DocumentViewer documentViewer)
        {
            var context = Hosting.GetHttpContext();
            var selectedLanguage = context.Request["languageSelector"];

            if (selectedLanguage != null)
                documentViewer.DisplayLanguage = selectedLanguage;
            else
            {
                selectedLanguage = DocumentUltimateWebConfiguration.AvailableDisplayCultures.FirstOrDefault(
                    culture => documentViewer.DisplayLanguage == culture.Name ||
                               documentViewer.DisplayLanguage.Contains(culture.Name)
                )?.Name;
            }

            PopulateLanguageSelector(selectedLanguage);
        }

        private void PopulateLanguageSelector(string selectedLanguage)
        {
            ViewBag.LanguageList = new SelectList(
                DocumentUltimateWebConfiguration.AvailableDisplayCultures,
                "Name",
                "NativeName",
                selectedLanguage
            );
        }
    }
}