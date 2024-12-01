using System;
using System.Collections.Generic;
using System.IO;
using GleamTech.AspNet;
using GleamTech.DocumentUltimate.AspNet.UI;
using GleamTech.FileProviders;
using Microsoft.AspNetCore.Mvc;

namespace GleamTech.DocumentUltimateExamples.AspNetCoreOnNetFullCS.Controllers
{
    public partial class DocumentViewerController
    {
        public IActionResult FileProvider()
        {
            var documentViewer = new DocumentViewer
            {
                Width = 960,
                Height = 720,
                Resizable = true,

                // See below for CustomFileProvider class which implements FileProvider base class
                Document = new CustomFileProvider
                {
                    File = "~/App_Data/ExampleFiles/Default.docx",
                    Parameters = new Dictionary<string, string>
                    {
                        {"parameter1", "value1"}
                    }
                }
            };

            return View(documentViewer);
        }
    }

    // Implement FileProvider base class to provide a custom way of loading the input files.
    // For the simplicity of this example, we are getting a stream from a file on disk.
    // Otherwise the stream can come from network or a database or even a zip file.
    public class CustomFileProvider : FileProvider
    {
        public override string File { get; set; }

        //Return true if DoGetInfo method is implemented, and false if not.
        public override bool CanGetInfo => true;

        //Return true if DoOpenRead method is implemented, and false if not.
        public override bool CanOpenRead => true;

        //Return true if DoOpenWrite method is implemented, and false if not.
        public override bool CanOpenWrite => false;

        //Return true only if File identifier is usable across processes/machines.
        public override bool CanSerialize => true;

        protected override FileProviderInfo DoGetInfo()
        {
            //Return info here which corresponds to the identifier in File property.

            //When this file provider is used in DocumentViewer:
            //This method will be called every time DocumentViewer requests a document.
            //The cache key and document format will be determined according to the info you return here.

            var physicalPath = Hosting.ResolvePhysicalPath(File);
            var fileInfo = new FileInfo(physicalPath);

            return new FileProviderInfo(fileInfo.Name, fileInfo.LastWriteTimeUtc, fileInfo.Length);

            //throw new NotImplementedException();
        }

        protected override Stream DoOpenRead()
        {
            //Open and return a readable stream here which corresponds to the identifier in File property.

            //You can make use of Parameters dictionary which was passed when this provider was initialized.
            //var someParameter = Parameters["parameter1"];

            //When this file provider is used in DocumentViewer:
            //This method will be called only when original input document is required, 
            //For example if DocumentViewer already did the required conversions and cached the results, 
            //it will not be called.

            var physicalPath = Hosting.ResolvePhysicalPath(File);
            var stream = System.IO.File.OpenRead(physicalPath);

            return stream;

            //throw new NotImplementedException();
        }

        protected override Stream DoOpenWrite()
        {
            //Open and return a writable stream here which corresponds to the identifier in File property.

            throw new NotImplementedException();
        }
    }
}
