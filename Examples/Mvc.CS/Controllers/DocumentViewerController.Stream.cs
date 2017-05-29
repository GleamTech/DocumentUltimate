using System;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.Mvc;
using GleamTech.DocumentUltimate;
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

            // The document handler type which provides a custom way of loading the input files.
            // This class should implement IDocumentHandler interface and should have a parameterless
            // constructor so that it can be instantiated internally when necessary.
            // Value of Document property will be passed to this handler which should open 
            // and return a readable stream according to that file identifier.
            // See below for CustomDocumentHandler class which implements IDocumentHandler interface
            documentViewer.DocumentHandlerType = typeof(CustomDocumentHandler);

            // If a custom document handler is provided via DocumentHandlerType property, then
            // this value will be passed to that handler which should open and return a readable stream according 
            // to this file identifier. 
            // So it can be any string value that your IDocumentHandler implementation understands.
            documentViewer.Document = "~/App_Data/ExampleFiles/DOCX Document.docx";


            // Here is an example (commented out) for loading a document from database.
            // See below for CustomDocumentHandler2 class which implements IDocumentHandler interface.
            // This loads the document with passed ID (176) from the database
            /*
            documentViewer.DocumentHandlerType = typeof(CustomDocumentHandler2);
            documentViewer.Document = "176";
            */

            return View(documentViewer);
        }
    }

    // Implement IDocumentHandler interface to provide a custom way of loading the input files.
    // You can instruct DocumentViewer to use this handler by setting DocumentViewer.DocumentHandlerType
    // property to type of this class, i.e. typeof(CustomDocumentHandler)
    // For the simplicity of this example, we are getting a stream from a file on disk.
    // Otherwise the stream can come from network or a database or even a zip file.
    public class CustomDocumentHandler : IDocumentHandler
    {
        // Get the document information required for the current input file.
        // This is called before loading the document for determining the cache key and document format.
        //
        // inputFile parameter will be the value that was set in DocumentViewer.Document property, i.e.
        // the input file that was requested to be loaded in DocumentViewer
        //
        // Return a DocumentInfo instance initialized with required information from this method.
        public DocumentInfo GetInfo(string inputFile)
        {
            var physicalPath = HttpContext.Current.Server.MapPath(inputFile);
            var fileInfo = new FileInfo(physicalPath);

            return new DocumentInfo(
                // uniqueId parameter (required):
                // The unique identifier that will be used for generating the cache key for this document.
                // For instance, it can be an ID from your database table or a simple file name; 
                // you just need to make sure this ID varies for each different document so that they are cached correctly.
                // For example for files on disk,
                // we internally use a string combination of file extension, file size and file date for uniquely
                // identifying them, this way cache collisions do not occur and we can resuse the cached file
                // even if the file name before extension is changed (because it's still the same document).
                string.Concat(
                    fileInfo.Extension.ToLowerInvariant(),
                    fileInfo.Length,
                    fileInfo.LastWriteTimeUtc.Ticks),

                // fileName parameter (optional but recommended):
                // The file name which will be used for display purposes such as when downloading the document
                // within DocumentViewer> or for the subfolder name prefix in cache folder. 
                // It will also be used to determine the document format from extension if format 
                // parameter is not specified. If not specified or empty, uniqueId will be used 
                // as the file name.
                fileInfo.Name
            );
        }

        // Open a readable stream for the current input file.
        //
        // inputFile parameter will be the value that was set in DocumentViewer.Document property, i.e.
        // the input file that was requested to be loaded in DocumentViewer
        //
        // inputOptions parameter will be determined according to the input document format
        // Usually you will not need to check this parameter as inputFile parameter should be sufficient
        // for you to locate and open a corresponding stream.
        //
        // Return a StreamResult instance initialized with a readable System.IO.Stream object.
        public StreamResult OpenRead(string inputFile, InputOptions inputOptions)
        {
            var physicalPath = HttpContext.Current.Server.MapPath(inputFile);
            var stream = File.OpenRead(physicalPath);

            return new StreamResult(stream);
        }
    }

    // This sample demonstrates raw db access with System.Data objects
    // but you can use any type of db access (e.g. Entity Framework), the idea is same.
    public class CustomDocumentHandler2 : IDocumentHandler
    {
        public DocumentInfo GetInfo(string inputFile)
        {
            var fileId = inputFile;
            var sql = "SELECT FileName FROM FileTable WHERE FileId=" + fileId;

            using (var connection = new SqlConnection("CONNECTION STRING"))
            {
                connection.Open();

                using (var command = new SqlCommand(sql, connection))
                using (var reader = command.ExecuteReader())
                {
                    if (!reader.Read())
                        throw new Exception("File not found");

                    // read the file name from the selected row (first column in above query)
                    var fileName = reader.GetString(0);

                    return new DocumentInfo(
                        fileId,
                        fileName
                    );
                }
            }
        }

        public StreamResult OpenRead(string inputFile, InputOptions inputOptions)
        {
            var fileId = inputFile;
            var sql = "SELECT FileBytes FROM FileTable WHERE FileId=" + fileId;

            using (var connection = new SqlConnection("CONNECTION STRING"))
            {
                connection.Open();

                using (var command = new SqlCommand(sql))
                using (var reader = command.ExecuteReader())
                {
                    if (!reader.Read())
                        throw new Exception("File not found");

                    // read the file data from the selected row (first column in above query)
                    var fileBytes = (byte[])reader.GetValue(0);

                    return new StreamResult(new MemoryStream(fileBytes));
                }
            }
        }
    }

}