using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using GleamTech.AspNet;
using GleamTech.DocumentUltimate;
using GleamTech.DocumentUltimateExamples.AspNetCoreCS.Models;
using GleamTech.Examples;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GleamTech.DocumentUltimateExamples.AspNetCoreCS.Controllers
{
    public partial class DocumentConverterController
    {
        public IActionResult Possible()
        {
            var model = new PossibleViewModel();

            PopulateInputFormats(model);
            PopulateOutputFormats(model);

            model.ResultHandlerUrl = ExamplesConfiguration.GetDynamicDownloadUrl(
                ResultHandlerName,
                new NameValueCollection
                {
                    {"version", DateTime.UtcNow.Ticks.ToString()}
                });

            return View(model);
        }

        private void PopulateInputFormats(PossibleViewModel model)
        {
            foreach (var formatInfo in DocumentFormatInfo.Enumerate(DocumentFormatSupport.Load))
            {
                List<SelectListItem> groupData;
                if (!model.InputFormats.TryGetValue(formatInfo.Group.Description, out groupData))
                {
                    groupData = new List<SelectListItem>();
                    model.InputFormats.Add(formatInfo.Group.Description, groupData);
                }
                groupData.Add(new SelectListItem
                {
                    Text = formatInfo.Description,
                    Value = formatInfo.Value.ToString()
                });
                model.InputFormatCount++;
            }
        }

        private void PopulateOutputFormats(PossibleViewModel model)
        {
            foreach (var formatInfo in DocumentFormatInfo.Enumerate(DocumentFormatSupport.Save))
            {
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
                model.OutputFormatCount++;
            }
        }

        public static void ResultHandler(IHttpContext context)
        {
            var inputFormat = (DocumentFormat)Enum.Parse(typeof(DocumentFormat), context.Request["inputFormat"]);
            var outputFormat = (DocumentFormat)Enum.Parse(typeof(DocumentFormat), context.Request["outputFormat"]);

            context.Response.Output.Write("<center>");

            if (DocumentConverter.CanConvert(inputFormat, outputFormat))
            {
                context.Response.Output.Write(string.Format(
                    "<span style=\"color: green; font-weight: bold\">Direct conversion from {0} to {1} is possible</span>",
                    inputFormat, outputFormat)
                );

                foreach (var engine in Enum<DocumentEngine>.GetValues())
                {
                    if (DocumentConverter.CanConvert(inputFormat, outputFormat, engine))
                        context.Response.Output.Write(string.Format(
                            "<br/><span style=\"color: green; font-weight: bold\">Via {0} Engine &#x2713;</span>", 
                            engine));
                    else
                        context.Response.Output.Write(string.Format(
                            "<br/><span style=\"color: red; font-weight: bold\">Via {0} Engine &#x2717;</span>", 
                            engine));
                }
            }
            else
                context.Response.Output.Write(string.Format(
                    "<span style=\"color: red; font-weight: bold\">Direct conversion from {0} to {1} is not possible</span>",
                    inputFormat, outputFormat)
                    );

            context.Response.Output.Write("</center>");
        }

        private static string ResultHandlerName
        {
            get
            {
                if (resultHandlerName == null)
                {
                    resultHandlerName = "ResultHandler";
                    ExamplesConfiguration.RegisterDynamicDownloadHandler(resultHandlerName, ResultHandler);
                }

                return resultHandlerName;
            }
        }
        private static string resultHandlerName;
    }
}