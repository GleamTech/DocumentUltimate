using System.Collections.Generic;
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
                InitialFile = "Default.pdf",
                FormWrapped = false
            };

            var documentViewer = new DocumentViewer
            {
                Width = 960,
                Height = 720,
                Resizable = true,
                Document = exampleFileSelector.SelectedFile.ToString()
            };

            HandleSelectors(documentViewer);

            return View(documentViewer);
        }

        private void HandleSelectors(DocumentViewer documentViewer)
        {
            var context = Hosting.GetHttpContext();

            var selectedLanguage = context.Request["languageSelector"];
            if (selectedLanguage != null)
                documentViewer.DisplayLanguage = selectedLanguage;
            else
                selectedLanguage = documentViewer.DisplayLanguage;
            PopulateLanguageSelector(selectedLanguage);

            var selectedTheme = context.Request["themeSelector"];
            if (selectedTheme != null)
                documentViewer.Theme = selectedTheme;
            else
                selectedTheme = documentViewer.Theme;
            PopulateThemeSelector(selectedTheme);
        }

        private void PopulateLanguageSelector(string selectedLanguage)
        {
            ViewBag.LanguageList = new SelectList(
                DocumentUltimateWebConfiguration.AvailableDisplayCultures.Select(culture => new
                {
                    Value = culture.Name,
                    Text = culture.NativeName + $" ({culture.Name})"
                }),
                "Value",
                "Text",
                selectedLanguage
            );
        }

        private void PopulateThemeSelector(string selectedTheme)
        {
            ViewBag.ThemeList = new SelectList(
                new Dictionary<string, string>
                {
                    { "slate (Dark Mode: classic-dark)", "slate, classic-dark" },
                    { "classic-light (Dark Mode: classic-dark)", "classic-light, classic-dark" },
                    { "classic-dark", "classic-dark" }
                },
                "Value",
                "Key",
                selectedTheme
            );
        }
    }
}
