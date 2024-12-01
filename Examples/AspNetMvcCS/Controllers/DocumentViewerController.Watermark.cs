using System.Web.Mvc;
using GleamTech.DocumentUltimate;
using GleamTech.DocumentUltimate.AspNet.UI;
using GleamTech.Drawing;

namespace GleamTech.DocumentUltimateExamples.AspNetMvcCS.Controllers
{
    public partial class DocumentViewerController
    {
        public ActionResult Watermark()
        {
            var documentViewer = new DocumentViewer
            {
                Width = 960,
                Height = 720,
                Resizable = true,
                Document = "~/App_Data/ExampleFiles/Default.doc",
                DocumentOptions = new DocumentOptions
                {
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
	                        Image = "~/App_Data/contoso-logo.png",
	                        HorizontalAlignment = HorizontalAlignment.Right,
	                        VerticalAlignment  = VerticalAlignment.Top,
	                        Opacity = 50,
	                        PageRange = "Odd"
	                    }
	                }
                }
            };

            return View(documentViewer);
        }
    }
}