Imports GleamTech.ExamplesCore

Public Class DefaultPage
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        exampleExplorer.Examples = New ExampleBase() {
            New ExampleFolder() With { 
	            .Title = "Document Viewer",
	            .Children = New ExampleBase() {
                    New Example() With {
		                .Title = "Overview", 
		                .Url = "DocumentViewer/Overview.aspx", 
		                .SourceFiles = New String() {"DocumentViewer/Overview.aspx", "DocumentViewer/Overview.aspx.vb"}, 
		                .DescriptionFile = "Descriptions/DocumentViewer/Overview.html" 
	                },
                    New Example() With {
		                .Title = "Copy protection (DRM)", 
		                .Url = "DocumentViewer/Protection.aspx", 
		                .SourceFiles = New String() {"DocumentViewer/Protection.aspx", "DocumentViewer/Protection.aspx.vb"}, 
		                .DescriptionFile = "Descriptions/DocumentViewer/Protection.html" 
	                },
                    New Example() With {
		                .Title = "Highlighting keywords", 
		                .Url = "DocumentViewer/Highlight.aspx", 
		                .SourceFiles = New String() {"DocumentViewer/Highlight.aspx", "DocumentViewer/Highlight.aspx.vb"}, 
		                .DescriptionFile = "Descriptions/DocumentViewer/Highlight.html" 
	                },
                    New Example() With {
		                .Title = "Using with a stream", 
		                .Url = "DocumentViewer/Stream.aspx", 
		                .SourceFiles = New String() {"DocumentViewer/Stream.aspx", "DocumentViewer/Stream.aspx.vb"}, 
		                .DescriptionFile = "Descriptions/DocumentViewer/Stream.html" 
	                }
                }
            }
        }

        exampleExplorer.ExampleProjectName = "ASP.NET Web Forms (VB)"
        exampleExplorer.ExampleProjects = ExamplesCoreConfiguration.LoadExampleProjects(Server.MapPath("~/App_Data/ExampleProjects.json"))

    End Sub

End Class