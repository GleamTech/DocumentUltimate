using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GleamTech.DocumentUltimate.Web;
using GleamTech.IO;

namespace GleamTech.DocumentUltimateExamples.Mvc.CS.Controllers
{
    public partial class DocumentViewerController
    {
        const string InitialFile = "PDF Document.pdf";
        const string DocumentsFolder = "~/App_Data";
        const string UploadsFolder = "~/App_Data/Uploads";
        const string UploadedPrefix = "Uploaded.";

        public ActionResult Overview(string fileSelector)
        {
            fileSelector = fileSelector ?? InitialFile;
            PopulateFileSelector(fileSelector);

            var currentDocumentPath = fileSelector.StartsWith(UploadedPrefix)
                ? new ForwardSlashPath(UploadsFolder).Append(Session.SessionID).Append(fileSelector.Substring(UploadedPrefix.Length))
                : new ForwardSlashPath(DocumentsFolder).Append(fileSelector);

            var documentViewer = new DocumentViewer
            {
                Width = 800,
                Height = 600,
                Resizable = true,
                DocumentPath = currentDocumentPath
            };

            return View(documentViewer);
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            string fileSelector = null;

            if (file != null && file.ContentLength > 0)
            {
                var folder = new BackSlashPath(Server.MapPath(UploadsFolder)).Append(Session.SessionID);
                Directory.CreateDirectory(folder);
                var fileName = new BackSlashPath(file.FileName).FileName;
                file.SaveAs(folder.Append(fileName));

                fileSelector = UploadedPrefix + fileName;
            }

            return RedirectToAction("Overview", new { fileSelector });
        }

        private void PopulateFileSelector(string fileSelector)
        {
            var listItems = from fileInfo in new DirectoryInfo(Server.MapPath(DocumentsFolder)).EnumerateFiles()
                            where fileInfo.Name != "License.dat"
                            select new SelectListItem
                            {
                                Text = fileInfo.Name,
                                Value = fileInfo.Name
                            };

            var folder = new BackSlashPath(Server.MapPath(UploadsFolder)).Append(Session.SessionID);
            if (Directory.Exists(folder))
                listItems = listItems.Concat(from fileInfo in new DirectoryInfo(folder).EnumerateFiles()
                                     select new SelectListItem
                                     {
                                         Text = fileInfo.Name,
                                         Value = UploadedPrefix + fileInfo.Name
                                     });

            ViewBag.FileList = new SelectList(
                listItems,
                "Value",
                "Text",
                fileSelector ?? InitialFile
            );
        }
    }
}