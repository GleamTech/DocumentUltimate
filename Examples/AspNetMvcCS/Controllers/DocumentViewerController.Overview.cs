﻿using System.Linq;
using System.Web.Mvc;
using GleamTech.DocumentUltimate.AspNet;
using GleamTech.DocumentUltimate.AspNet.UI;
using GleamTech.Examples;

namespace GleamTech.DocumentUltimateExamples.AspNetMvcCS.Controllers
{
    public partial class DocumentViewerController
    {
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Overview()
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
            var selectedLanguage = Request["languageSelector"];

            if (selectedLanguage != null)
                documentViewer.DisplayLanguage = selectedLanguage;
            else
                selectedLanguage = documentViewer.DisplayLanguage;

            PopulateLanguageSelector(selectedLanguage);
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
    }
}