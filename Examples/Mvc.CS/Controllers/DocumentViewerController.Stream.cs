using System.IO;
using System.Web.Mvc;
using GleamTech.DocumentUltimate.Web;

namespace GleamTech.DocumentUltimateExamples.Mvc.CS.Controllers
{
    public partial class DocumentViewerController
    {
        public ActionResult Stream()
        {
            var documentViewer = new DocumentViewer
            {
                Width = 800,
                Height = 600,
                Resizable = true
            };

            //For the simplicity of this example, we are getting a stream from a file on disk.
            //Otherwise the stream can come from network or a database or even a zip file.
            var fileInfo = new FileInfo(Server.MapPath("~/App_Data/DOCX Document.docx"));

            documentViewer.SetDocumentStream(
                () => fileInfo.Open(FileMode.Open),
                fileInfo.Name,
                fileInfo.Length,
                fileInfo.LastWriteTimeUtc
            );

            return View(documentViewer);
        }
    }
}