﻿Imports GleamTech.DocumentUltimate
Imports GleamTech.DocumentUltimate.AspNet.UI
Imports GleamTech.Drawing

Namespace Controllers
    Partial Public Class  DocumentViewerController
        Inherits Controller

    Public Function Watermark() As ActionResult
		Dim documentViewer = New DocumentViewer() With {
			.Width = 960,
			.Height = 720,
			.Resizable = True,
			.Document = "~/App_Data/ExampleFiles/Default.doc"
		}

        documentViewer.DocumentOptions.Watermarks.Add(
                New TextWatermark() With
                    {
                        .Text = "Contoso",
                        .Rotation = -45,
                        .Opacity = 50,
                        .FontColor = Color.Red,
                        .Width = 50,
                        .Height = 50,
                        .SizeIsPercentage = true
                    })
        documentViewer.DocumentOptions.Watermarks.Add(
                New ImageWatermark() With
                    {
                        .Image = "~/App_Data/contoso-logo.png",
                        .HorizontalAlignment = HorizontalAlignment.Right,
                        .VerticalAlignment  = VerticalAlignment.Top,
                        .Opacity = 50,
                        .PageRange = "Odd"
                    })

		Return View(documentViewer)
	End Function

    End Class
End Namespace
