using System.Drawing;
using GleamTech.DocumentUltimate;
using GleamTech.DocumentUltimate.AspNet.UI;
using Microsoft.AspNetCore.Mvc;

namespace GleamTech.DocumentUltimateExamples.AspNetCore.CS.Controllers
{
    public partial class DocumentViewerController
    {
        public IActionResult Watermark()
        {
            var documentViewer = new DocumentViewer
            {
                Width = 800,
                Height = 600,
                Resizable = true,
                Document = "~/App_Data/ExampleFiles/Default.doc",
                Watermarks = {
                    new TextWatermark
                    {
                        Text = "Contoso",
                        Rotation = -45,
                        Opacity = 50,
                        FontColor = Color.Red,
                        Width = 50,
                        Height = 50,
                        SizeIsPercentage = true
                    },
                    new ImageWatermark
                    {
                        ImageFile = "~/App_Data/contoso-logo.png",
                        HorizontalAlignment = HorizontalAlignment.Right,
                        VerticalAlignment  = VerticalAlignment.Top,
                        Opacity = 50,
                        PageRange = "Odd"
                    }
                }
            };

            return View(documentViewer);
        }
    }
}