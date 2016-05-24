using System;
using System.IO;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using GleamTech.IO;

namespace GleamTech.DocumentUltimateExamples.WebForms.CS.DocumentViewer
{
    public partial class OverviewPage : Page
    {
        const string InitialFile = "PDF Document.pdf";
        const string DocumentsFolder = "~/App_Data";
        const string UploadsFolder = "~/App_Data/Uploads";
        const string UploadedPrefix = "Uploaded.";

        protected void Page_Load(object sender, EventArgs e)
        {
            var fileSelectorValue = Request["fileSelector"] ?? InitialFile;

            if (Page.IsPostBack)
                fileSelectorValue = Upload() ?? fileSelectorValue;

            PopulateFileSelector(fileSelectorValue);

            var currentDocumentPath = fileSelectorValue.StartsWith(UploadedPrefix)
                ? new ForwardSlashPath(UploadsFolder).Append(Session.SessionID).Append(fileSelectorValue.Substring(UploadedPrefix.Length))
                : new ForwardSlashPath(DocumentsFolder).Append(fileSelectorValue);

            documentViewer.DocumentPath = currentDocumentPath;
        }

        public string Upload()
        {
            string fileSelectorValue = null;

            if (file.HasFile && file.PostedFile.ContentLength > 0)
            {
                var folder = new BackSlashPath(Server.MapPath(UploadsFolder)).Append(Session.SessionID);
                Directory.CreateDirectory(folder);
                var fileName = new BackSlashPath(file.FileName).FileName;
                file.SaveAs(folder.Append(fileName));

                fileSelectorValue = UploadedPrefix + fileName;
            }

            return fileSelectorValue;
        }

        private void PopulateFileSelector(string fileSelectorValue)
        {
            var listItems = from fileInfo in new DirectoryInfo(Server.MapPath(DocumentsFolder)).EnumerateFiles()
                            where fileInfo.Name != "License.dat"
                            select new ListItem
                            {
                                Text = fileInfo.Name,
                                Value = fileInfo.Name
                            };

            var folder = new BackSlashPath(Server.MapPath(UploadsFolder)).Append(Session.SessionID);
            if (Directory.Exists(folder))
                listItems = listItems.Concat(from fileInfo in new DirectoryInfo(folder).EnumerateFiles()
                                     select new ListItem
                                     {
                                         Text = fileInfo.Name,
                                         Value = UploadedPrefix + fileInfo.Name
                                     });

            fileSelector.Items.AddRange(listItems.ToArray());
            fileSelector.SelectedValue = fileSelectorValue ?? InitialFile;
        }
    }
}