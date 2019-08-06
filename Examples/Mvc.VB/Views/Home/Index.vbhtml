@Imports GleamTech.AspNet.Mvc
@Imports GleamTech.DocumentUltimate
@Imports GleamTech.Examples
@Code
    Dim exampleExplorer = New ExampleExplorer() With {
        .DisplayMode = GleamTech.AspNet.UI.DisplayMode.Viewport,
        .NavigationTitle = "DocumentUltimate Examples",
        .VersionTitle = "v" + DocumentUltimateConfiguration.AssemblyInfo.FileVersion.ToString(),
        .Examples = New ExampleBase() {
            New ExampleFolder() With {
                .Title = "Document Viewer",
                .Children = New ExampleBase() {
                    New Example() With {
                        .Title = "Overview",
                        .Url = "DocumentViewer/Overview",
                        .SourceFiles = New String() {"Views/DocumentViewer/Overview.vbhtml", "Controllers/DocumentViewerController.Overview.vb"},
                        .DescriptionFile = "Descriptions/DocumentViewer/Overview.html"
                    },
                    New Example() With {
                        .Title = "Copy protection (DRM)",
                        .Url = "DocumentViewer/Protection",
                        .SourceFiles = New String() {"Views/DocumentViewer/Protection.vbhtml", "Controllers/DocumentViewerController.Protection.vb"},
                        .DescriptionFile = "Descriptions/DocumentViewer/Protection.html"
                    },
                    New Example() With {
                        .Title = "Auto searching and highlighting keywords",
                        .Url = "DocumentViewer/Highlight",
                        .SourceFiles = New String() {"Views/DocumentViewer/Highlight.vbhtml", "Controllers/DocumentViewerController.Highlight.vb"},
                        .DescriptionFile = "Descriptions/DocumentViewer/Highlight.html"
                    },
                    New Example() With {
                        .Title = "Watermarking pages",
                        .Url = "DocumentViewer/Watermark",
                        .SourceFiles = New String() {"Views/DocumentViewer/Watermark.vbhtml", "Controllers/DocumentViewerController.Watermark.vb"},
                        .DescriptionFile = "Descriptions/DocumentViewer/Watermark.html"
                    },
                    New Example() With {
                        .Title = "Using with a stream",
                        .Url = "DocumentViewer/Stream",
                        .SourceFiles = New String() {"Views/DocumentViewer/Stream.vbhtml", "Controllers/DocumentViewerController.Stream.vb"},
                        .DescriptionFile = "Descriptions/DocumentViewer/Stream.html"
                    },
                    New Example() With {
                        .Title = "Client-side events",
                        .Url = "DocumentViewer/ClientEvents",
                        .SourceFiles = New String() {"Views/DocumentViewer/ClientEvents.vbhtml", "Controllers/DocumentViewerController.ClientEvents.vb"},
                        .DescriptionFile = "Descriptions/DocumentViewer/ClientEvents.html"
                    },
                    New Example() With {
                        .Title = "Using MVC layout",
                        .Url = "DocumentViewer/UsingLayout",
                        .SourceFiles = New String() {"Views/DocumentViewer/UsingLayout.vbhtml", "Views/Shared/_Layout.vbhtml", "Controllers/DocumentViewerController.UsingLayout.vb"},
                        .DescriptionFile = "Descriptions/DocumentViewer/UsingLayout.html"
                    },
                    New Example() With {
                        .Title = "Using MVC partial view",
                        .Url = "DocumentViewer/UsingPartial",
                        .SourceFiles = New String() {"Views/DocumentViewer/UsingPartial.vbhtml", "Views/DocumentViewer/DocumentViewerPartialView.vbhtml", "Controllers/DocumentViewerController.UsingPartial.vb"},
                        .DescriptionFile = "Descriptions/DocumentViewer/UsingPartial.html"
                    }
                }
            },
            New ExampleFolder() With {
                .Title = "Document Converter",
                .Children = New ExampleBase() {
                    New Example() With {
                        .Title = "Overview",
                        .Url = "DocumentConverter/Overview",
                        .SourceFiles = New String() {"Views/DocumentConverter/Overview.vbhtml", "Controllers/DocumentConverterController.Overview.vb"},
                        .DescriptionFile = "Descriptions/DocumentConverter/Overview.html"
                    },
                    New Example() With {
                        .Title = "Possible conversions",
                        .Url = "DocumentConverter/Possible",
                        .SourceFiles = New String() {"Views/DocumentConverter/Possible.vbhtml", "Controllers/DocumentConverterController.Possible.vb"},
                        .DescriptionFile = "Descriptions/DocumentConverter/Possible.html"
                    }
                }
            }
        },
        .ExampleProjectName = "ASP.NET MVC (VB)",
        .ExampleProjects = ExamplesConfiguration.LoadExampleProjects("~/App_Data/ExampleProjects.json")
    }
End Code
<!DOCTYPE html>

<html>
<head>
    <title>DocumentUltimate Examples - ASP.NET MVC (VB)</title>

    @Me.RenderHead(exampleExplorer)
</head>
<body>
    @Me.RenderBody(exampleExplorer)
</body>
</html>
