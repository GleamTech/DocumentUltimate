using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web;
using System.Web.Mvc;
using GleamTech.DocumentUltimate;
using GleamTech.DocumentUltimateExamples.Mvc.CS.Models;
using GleamTech.ExamplesCore;

namespace GleamTech.DocumentUltimateExamples.Mvc.CS.Controllers
{
    public partial class DocumentConverterController
    {
        public ActionResult Possible()
        {
            var model = new PossibleViewModel();

            PopulateInputFormats(model);
            PopulateOutputFormats(model);

            model.ResultHandlerUrl = ExamplesCoreConfiguration.GetDynamicDownloadUrl(
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

        public static void ResultHandler(HttpContext context)
        {
            var inputFormat = (DocumentFormat)Enum.Parse(typeof(DocumentFormat), context.Request["inputFormat"]);
            var outputFormat = (DocumentFormat)Enum.Parse(typeof(DocumentFormat), context.Request["outputFormat"]);

            context.Response.Write("<center>");

            if (DocumentConverter.CanConvert(inputFormat, outputFormat))
            {
                context.Response.Write(string.Format(
                    "<span style=\"color: green; font-weight: bold\">Direct conversion from {0} to {1} is possible</span>",
                    inputFormat, outputFormat)
                );

                foreach (var engine in Enum<DocumentEngine>.GetValues())
                {
                    if (DocumentConverter.CanConvert(inputFormat, outputFormat, engine))
                        context.Response.Write(string.Format(
                            "<br/><span style=\"color: green; font-weight: bold\">Via {0} Engine &#x2713;</span>", 
                            engine));
                    else
                        context.Response.Write(string.Format(
                            "<br/><span style=\"color: red; font-weight: bold\">Via {0} Engine &#x2717;</span>", 
                            engine));
                }
            }
            else
                context.Response.Write(string.Format(
                    "<span style=\"color: red; font-weight: bold\">Direct conversion from {0} to {1} is not possible</span>",
                    inputFormat, outputFormat)
                    );

            context.Response.Write("</center>");
        }

        private static string ResultHandlerName
        {
            get
            {
                if (resultHandlerName == null)
                {
                    resultHandlerName = "ResultHandler";
                    ExamplesCoreConfiguration.RegisterDynamicDownloadHandler(resultHandlerName, ResultHandler);
                }

                return resultHandlerName;
            }
        }
        private static string resultHandlerName;
    }
}