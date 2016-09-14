@Imports GleamTech.ExamplesCore
@Imports GleamTech.Web.Mvc
@Code
    Dim exampleExplorer = New ExampleExplorer() With {
        .FullViewport = True,
        .NavigationTitle = "DocumentUltimate Examples",
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
                        .Title = "Highlighting keywords",
                        .Url = "DocumentViewer/Highlight",
                        .SourceFiles = New String() {"Views/DocumentViewer/Highlight.vbhtml", "Controllers/DocumentViewerController.Highlight.vb"},
                        .DescriptionFile = "Descriptions/DocumentViewer/Highlight.html"
                    },
                    New Example() With {
                        .Title = "Using with a stream",
                        .Url = "DocumentViewer/Stream",
                        .SourceFiles = New String() {"Views/DocumentViewer/Stream.vbhtml", "Controllers/DocumentViewerController.Stream.vb"},
                        .DescriptionFile = "Descriptions/DocumentViewer/Stream.html"
                    }
                }
            }
        },
        .ExampleProjectName = "ASP.NET MVC (VB)",
        .ExampleProjects = ExamplesCoreConfiguration.LoadExampleProjects(Server.MapPath("~/App_Data/ExampleProjects.json"))
    }
End Code
<!DOCTYPE html>

<html>
<head>
    <title>DocumentUltimate Examples - ASP.NET MVC (VB)</title>

    @Html.RenderCss(exampleExplorer)
    @Html.RenderJs(exampleExplorer)

</head>
<body>
    @Html.RenderControl(exampleExplorer)
</body>
</html>
