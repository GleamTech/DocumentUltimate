using System;
using System.IO;
using System.Web.UI;
using GleamTech.DocumentUltimate.Web;

namespace GleamTech.DocumentUltimateExamples.WebForms.CS.DocumentViewer
{
    public partial class StreamPage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var fileInfo = new FileInfo(Server.MapPath("~/App_Data/ExampleFiles/DOCX Document.docx"));

            documentViewer.Document = new DocumentSource(
                //Pass a method that returns a Stream or Byte[].
                //For the simplicity of this example, we are getting a stream from a file on disk.
                //Otherwise the stream can come from network or a database or even a zip file.
                //This parameter is implemented as callback so that it's only called when necessary
                //i.e. when the document is opened for the first time and it's not converted and cached yet.
                //For consecutive views, the document will be served from cache unless cached key is changed
                //as a result of changing any of the 3 parameters below.
                () => fileInfo.Open(FileMode.Open),

                //These 3 parameters are used for generating a unique cache key. If one of them (file extension,
                //file size, file modified date) changes, cache key changes so the source will be considered 
                //as another document file. This way DocumentViewer can know if your Stream or Byte[] source
                //is the same file or not without even calling your method and without reading whole Stream or Byte[]
                //every time this page is hit.
                //If you don't have file size or last modified date, you can pass 0 and DateTime.MinValue respectively.
                //However you should always pass a file name with correct file extension (e.g. MyFile.docx)
                //The extension is required for determining source format correctly, also only the extension
                //is used for cache key, file name before extension can be changed without causing a change 
                //in cache key.
                fileInfo.Name,
                fileInfo.Length,
                fileInfo.LastWriteTimeUtc
            );


            //Here is an example (commented out) for loading a document from database
            //GetDocumentFromDb loads the document with passed ID (176) from the database as byte array 
            //and returns a DocumentSource instance with all information filled in.
            //This sample only demonstrates raw db access with System.Data objects
            //but you can use any type of db access (e.g. Entity Framework), the idea is same.
            /*
            documentViewer.Document = GetDocumentFromDb(176);
            */
        }

        /*
        public DocumentSource GetDocumentFromDb(int fileId)
        {
            using (var connection = new SqlConnection("CONNECTION STRING"))
            {
                connection.Open();

                using (var command = new SqlCommand("SELECT FileBytes, FileName, FileDate, FROM FileTable WHERE FileId='" + fileId + "' ", connection))
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                        throw  new Exception("File not found");

                    var fileBytes = (byte[])reader.GetValue(0); // read the file data from the selected row (first column in above query)

                    return new DocumentSource(
                        () => fileBytes,
                        reader.GetValue(1),  // pass the file name here (second column in above query)
                        fileBytes.Length, // pass the file size here (we already know the size because we have a byte array)
                        reader.GetValue(2) // pass the file date here (third column in above query) or if you don't have a date just pass DateTime.MinValue
                    );
                }
            }
        }
        */
    }
}