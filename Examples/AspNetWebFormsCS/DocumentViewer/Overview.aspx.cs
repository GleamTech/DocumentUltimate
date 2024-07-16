using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using GleamTech.DocumentUltimate.AspNet;

namespace GleamTech.DocumentUltimateExamples.AspNetWebFormsCS.DocumentViewer
{
    public partial class OverviewPage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            documentViewer.Document = exampleFileSelector.SelectedFile.ToString();

            if (IsPostBack)
            {
                documentViewer.DisplayLanguage = LanguageSelector.SelectedValue;
                documentViewer.Theme = ThemeSelector.SelectedValue;
            }
            else
            {
                PopulateLanguageSelector();
                PopulateThemeSelector();
            }
        }

        private void PopulateLanguageSelector()
        {
            foreach (var culture in DocumentUltimateWebConfiguration.AvailableDisplayCultures)
            {
                var listItem = new ListItem(culture.NativeName + $" ({culture.Name})", culture.Name);
                if (culture.Name == documentViewer.DisplayLanguage)
                    listItem.Selected = true;
                LanguageSelector.Items.Add(listItem);
            }
        }

        private void PopulateThemeSelector()
        {
            var themes = new Dictionary<string, string>
            {
                { "slate (Dark Mode: classic-dark)", "slate, classic-dark" },
                { "classic-light (Dark Mode: classic-dark)", "classic-light, classic-dark" },
                { "classic-dark", "classic-dark" }
            };

            foreach (var kvp in themes)
            {
                var listItem = new ListItem(kvp.Key, kvp.Value);
                if (kvp.Value == documentViewer.Theme)
                    listItem.Selected = true;
                ThemeSelector.Items.Add(listItem);
            }
        }
    }
}
