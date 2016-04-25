using System;
using System.IO;
using System.Web.UI;

namespace GleamTech.DocumentUltimateExamples.WebForms.CS.DocumentViewer
{
    public partial class StreamPage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //For the simplicity of this example, we are getting a stream from a file on disk.
            //Otherwise the stream can come from network or a database or even a zip file.
            var fileInfo = new FileInfo(Server.MapPath("~/App_Data/DOCX Document.docx"));

            documentViewer.SetDocumentStream(
                () => fileInfo.Open(FileMode.Open),
                fileInfo.Name,
                fileInfo.Length,
                fileInfo.LastWriteTimeUtc
            );
        }
    }
}