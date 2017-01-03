using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using GleamTech.DocumentUltimate;

namespace GleamTech.DocumentUltimateExamples.WebForms.CS.DocumentConverter
{
    public partial class OverviewPage : Page
    {
        protected string InputFormat;

        protected void Page_Load(object sender, EventArgs e)
        {
            var inputDocument = exampleFileSelector.SelectedFile;

            var inputFormat = DocumentFormatInfo.Get(inputDocument);
            InputFormat = inputFormat != null ? inputFormat.Description : "(not supported)";

            PopulatePossibleConversions(inputDocument);
        }

        private void PopulatePossibleConversions(string inputDocument)
        {
            var targetData = new Dictionary<string, List<ListItem>>();

            foreach (var format in DocumentUltimate.DocumentConverter.EnumeratePossibleOutputFormats(inputDocument))
            {
                var formatInfo = DocumentFormatInfo.Get(format);

                List<ListItem> groupData;
                if (!targetData.TryGetValue(formatInfo.Group.Description, out groupData))
                {
                    groupData = new List<ListItem>();
                    targetData.Add(formatInfo.Group.Description, groupData);
                }
                groupData.Add(new ListItem(formatInfo.Description, formatInfo.Value.ToString()));
            }

            if (targetData.Count == 0)
                targetData.Add("(not supported)", new List<ListItem>());

            TargetFormats.DataSource = targetData;
            TargetFormats.DataBind();
        }
    }
}