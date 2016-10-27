using System;
using System.Web.UI;
using GleamTech.ExamplesCore;

namespace GleamTech.DocumentUltimateExamples.WebForms.CS
{
    public partial class DefaultPage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            exampleExplorer.Examples = new ExampleBase[]
            {
                new ExampleFolder
                {
                    Title = "Document Viewer",
                    Children = new ExampleBase[]
                    {
                        new Example
                        {
                            Title = "Overview",
                            Url = "DocumentViewer/Overview.aspx",
                            SourceFiles = new[] {"DocumentViewer/Overview.aspx", "DocumentViewer/Overview.aspx.cs"},
                            DescriptionFile = "Descriptions/DocumentViewer/Overview.html"
                        },
                        new Example
                        {
                            Title = "Copy protection (DRM)",
                            Url = "DocumentViewer/Protection.aspx",
                            SourceFiles = new[] {"DocumentViewer/Protection.aspx", "DocumentViewer/Protection.aspx.cs"},
                            DescriptionFile = "Descriptions/DocumentViewer/Protection.html"
                        },
                        new Example
                        {
                            Title = "Highlighting keywords",
                            Url = "DocumentViewer/Highlight.aspx",
                            SourceFiles = new[] {"DocumentViewer/Highlight.aspx", "DocumentViewer/Highlight.aspx.cs"},
                            DescriptionFile = "Descriptions/DocumentViewer/Highlight.html"
                        },
                        new Example
                        {
                            Title = "Watermarking pages",
                            Url = "DocumentViewer/Watermark.aspx",
                            SourceFiles = new[] {"DocumentViewer/Watermark.aspx", "DocumentViewer/Watermark.aspx.cs"},
                            DescriptionFile = "Descriptions/DocumentViewer/Watermark.html"
                        },
                        new Example
                        {
                            Title = "Using with a stream",
                            Url = "DocumentViewer/Stream.aspx",
                            SourceFiles = new[] {"DocumentViewer/Stream.aspx", "DocumentViewer/Stream.aspx.cs"},
                            DescriptionFile = "Descriptions/DocumentViewer/Stream.html"
                        }
                    }
                }
            };

            exampleExplorer.ExampleProjectName = "ASP.NET Web Forms (C#)";
            exampleExplorer.ExampleProjects = ExamplesCoreConfiguration.LoadExampleProjects(Server.MapPath("~/App_Data/ExampleProjects.json"));
        }
    }
}
