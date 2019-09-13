using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Web.Mvc;
using GleamTech.AspNet;
using GleamTech.DocumentUltimate;
using GleamTech.DocumentUltimateExamples.Mvc.CS.Models;
using GleamTech.Examples;
using GleamTech.IO;
using GleamTech.Zip;

namespace GleamTech.DocumentUltimateExamples.Mvc.CS.Controllers
{
    public partial class DocumentConverterController
    {
        public ActionResult Overview()
        {
            var model = new OverviewViewModel
            {
                ExampleFileSelector = new ExampleFileSelector
                {
                    Id = "exampleFileSelector",
                    InitialFile = "Default.pdf"
                }
            };

            var inputDocument = model.ExampleFileSelector.SelectedFile;
            var fileInfo = new FileInfo(inputDocument);
            var inputFormat = DocumentFormatInfo.Get(inputDocument);
            model.InputFormat = inputFormat != null ? inputFormat.Description : "(not supported)";

            PopulatePossibleOutputFormats(inputDocument, model);

            model.ConvertHandlerUrl = ExamplesConfiguration.GetDynamicDownloadUrl(
                ConvertHandlerName,
                new NameValueCollection
                {
                    {"inputDocument", ExamplesConfiguration.ProtectString(inputDocument)},
                    {"version", fileInfo.LastWriteTimeUtc.Ticks + "-" +  fileInfo.Length}
                });

            return View(model);
        }

        private void PopulatePossibleOutputFormats(string inputDocument, OverviewViewModel model)
        {
            foreach (var format in DocumentConverter.EnumeratePossibleOutputFormats(inputDocument))
            {
                var formatInfo = DocumentFormatInfo.Get(format);

                List<SelectListItem> groupData;
                if (!model.OutputFormats.TryGetValue(formatInfo.Group.Description, out groupData))
                {
                    groupData = new List<SelectListItem>();
                    model.OutputFormats.Add(formatInfo.Group.Description, groupData);
                }
                groupData.Add(new SelectListItem
                {
                    Text = formatInfo.Description,
                    Value = formatInfo.Value.ToString()
                });
            }

            if (model.OutputFormats.Count == 0)
                model.OutputFormats.Add("(not supported)", new List<SelectListItem>());
        }

        public static void ConvertHandler(IHttpContext context)
        {
            DocumentConverterResult result;

            try
            {
                var inputDocument = new BackSlashPath(ExamplesConfiguration.UnprotectString(context.Request["inputDocument"]));
                var outputFormat = (DocumentFormat)Enum.Parse(typeof(DocumentFormat), context.Request["outputFormat"]);
                var fileName = inputDocument.FileNameWithoutExtension + "." + DocumentFormatInfo.Get(outputFormat).DefaultExtension;
                var outputPath = ConvertedPath.Append(context.Session.Id).Append(fileName);
                var outputDocument = outputPath.Append(fileName);

                if (Directory.Exists(outputPath))
                    Directory.Delete(outputPath, true);
                Directory.CreateDirectory(outputPath);
                result = DocumentConverter.Convert(inputDocument, outputDocument, outputFormat);
            }
            catch (Exception exception)
            {
                context.Response.Output.Write("<span style=\"color: red; font-weight: bold\">Conversion failed</span><br/>");
                context.Response.Output.Write(exception.Message);
                return;
            }

            context.Response.Output.Write("<span style=\"color: green; font-weight: bold\">Conversion successful</span>");
            context.Response.Output.Write("<br/>Conversion time: " + result.ElapsedTime);
            context.Response.Output.Write("<br/>Output files:");

            if (result.OutputFiles.Length > 1)
                context.Response.Output.Write(" - " + GetZipDownloadLink(new FileInfo(result.OutputFiles[0]).Directory));

            context.Response.Output.Write("<br/><ol>");
            foreach (var outputFile in result.OutputFiles)
            {
                if (outputFile.EndsWith("\\"))
                {
                    var directoryInfo = new DirectoryInfo(outputFile);
                    context.Response.Output.Write(string.Format(
                        "<br/><li><b>{0}\\</b> - {1}</li>",
                        directoryInfo.Name,
                        GetZipDownloadLink(directoryInfo))
                    );
                }
                else
                {
                    var fileInfo = new FileInfo(outputFile);
                    context.Response.Output.Write(string.Format(
                        "<br/><li><b>{0}</b> ({1} bytes) - {2}</li>",
                        fileInfo.Name,
                        fileInfo.Length,
                        GetDownloadLink(fileInfo))
                    );
                }
            }
            context.Response.Output.Write("<br/></ol>");
        }

        private static string GetDownloadLink(FileInfo fileInfo)
        {
            return string.Format(
                "<a href=\"{0}\">Download</a>",
                ExamplesConfiguration.GetDownloadUrl(fileInfo.FullName, fileInfo.LastWriteTimeUtc.Ticks.ToString()));
        }

        private static string GetZipDownloadLink(DirectoryInfo directoryInfo)
        {
            return string.Format(
                "<a href=\"{0}\">Download as Zip</a>",
                ExamplesConfiguration.GetDynamicDownloadUrl(
                    ZipDownloadHandlerName,
                    new NameValueCollection
                    {
                        {"path", ExamplesConfiguration.ProtectString(directoryInfo.FullName)},
                        {"version", directoryInfo.LastWriteTimeUtc.Ticks.ToString()},
                    }));
        }

        public static void ZipDownloadHandler(IHttpContext context)
        {
            var path = new BackSlashPath(ExamplesConfiguration.UnprotectString(context.Request["path"])).RemoveTrailingSlash();

            var fileResponse = new FileResponse(context, 0);
            fileResponse.Transmit((targetStream) =>
            {
                QuickZip.Zip(targetStream, Directory.EnumerateFileSystemEntries(path));
            }, path.FileName + ".zip", 0);

        }

        private static string ConvertHandlerName
        {
            get
            {
                if (convertHandlerName == null)
                {
                    convertHandlerName = "ConvertHandler";
                    ExamplesConfiguration.RegisterDynamicDownloadHandler(convertHandlerName, ConvertHandler);
                }

                return convertHandlerName;
            }
        }
        private static string convertHandlerName;

        private static string ZipDownloadHandlerName
        {
            get
            {
                if (zipDownloadHandlerName == null)
                {
                    zipDownloadHandlerName = "ZipDownloadHandler";
                    ExamplesConfiguration.RegisterDynamicDownloadHandler(zipDownloadHandlerName, ZipDownloadHandler);
                }

                return zipDownloadHandlerName;
            }
        }
        private static string zipDownloadHandlerName;

        private static readonly BackSlashPath ConvertedPath = Hosting.ResolvePhysicalPath("~/App_Data/ConvertedDocuments");
    }
}