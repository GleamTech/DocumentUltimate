using System;
using System.Web.UI;

namespace GleamTech.DocumentUltimateExamples.WebForms.CS.DocumentViewer
{
    public partial class HighlightPage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            documentViewer.HighlightedKeywords = new[] {"ancient", "ship"};
            //You can also split your whole search term into keywords like this:
            //documentViewer.HighlightedKeywords = "ancient ship".Split(new [] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
        }
    }
}