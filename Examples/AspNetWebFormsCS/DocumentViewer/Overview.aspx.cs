using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using GleamTech.DocumentUltimate.AspNet;

namespace GleamTech.DocumentUltimateExamples.AspNetWebFormsCS.DocumentViewer
{
    public partial class OverviewPage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            documentViewer.Document = exampleFileSelector.SelectedFile;

            if (IsPostBack)
                documentViewer.DisplayLanguage = LanguageSelector.SelectedValue;
            else
                PopulateLanguageSelector();
        }

        private void PopulateLanguageSelector()
        {
            foreach (var culture in DocumentUltimateWebConfiguration.AvailableDisplayCultures)
            {
                var listItem = new ListItem(culture.NativeName, culture.Name);
                if (culture.Name == documentViewer.DisplayLanguage)
                    listItem.Selected = true;
                LanguageSelector.Items.Add(listItem);
            }
        }
    }
}