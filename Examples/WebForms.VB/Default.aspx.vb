﻿Imports GleamTech.DocumentUltimate
Imports GleamTech.ExamplesCore

Public Class DefaultPage
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        exampleExplorer.VersionTitle = "v" + DocumentUltimateConfiguration.AssemblyInfo.FileVersion.ToString()

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
		                .Title = "Watermarking pages", 
		                .Url = "DocumentViewer/Watermark.aspx", 
		                .SourceFiles = New String() {"DocumentViewer/Watermark.aspx", "DocumentViewer/Watermark.aspx.vb"}, 
		                .DescriptionFile = "Descriptions/DocumentViewer/Watermark.html" 
	                },
                    New Example() With {
		                .Title = "Using with a stream", 
		                .Url = "DocumentViewer/Stream.aspx", 
		                .SourceFiles = New String() {"DocumentViewer/Stream.aspx", "DocumentViewer/Stream.aspx.vb"}, 
		                .DescriptionFile = "Descriptions/DocumentViewer/Stream.html" 
	                },
                    New Example() With {
                        .Title = "Events", 
                        .Url = "DocumentViewer/Events.aspx", 
                        .SourceFiles = New String() {"DocumentViewer/Events.aspx", "DocumentViewer/Events.aspx.vb"}, 
                        .DescriptionFile = "Descriptions/DocumentViewer/Events.html" 
                        }
                }
            },
            New ExampleFolder() With {
	            .Title = "Document Converter",
	            .Children = New ExampleBase() {
                    New Example() With {
		                .Title = "Overview",
		                .Url = "DocumentConverter/Overview.aspx",
		                .SourceFiles = New String() {"DocumentConverter/Overview.aspx", "DocumentConverter/Overview.aspx.vb"},
		                .DescriptionFile = "Descriptions/DocumentConverter/Overview.html"
	                }, 
                    New Example() With {
		                .Title = "Possible conversions",
		                .Url = "DocumentConverter/Possible.aspx",
		                .SourceFiles = New String() {"DocumentConverter/Possible.aspx", "DocumentConverter/Possible.aspx.vb"},
		                .DescriptionFile = "Descriptions/DocumentConverter/Possible.html"
	                }
                }
            }
        }

        exampleExplorer.ExampleProjectName = "ASP.NET Web Forms (VB)"
        exampleExplorer.ExampleProjects = ExamplesCoreConfiguration.LoadExampleProjects(Server.MapPath("~/App_Data/ExampleProjects.json"))

    End Sub

End Class