using System.Collections.Generic;
using System.Web.Mvc;
using GleamTech.Examples;

namespace GleamTech.DocumentUltimateExamples.AspNetMvcCS.Models
{
    public class OverviewViewModel
    {
        public OverviewViewModel()
        {
            OutputFormats = new Dictionary<string, List<SelectListItem>>();
        }

        public ExampleFileSelector ExampleFileSelector { get; set; }

        public string InputFormat { get; set; }

        public string ConvertHandlerUrl { get; set; }

        public Dictionary<string, List<SelectListItem>> OutputFormats { get; set; }
    }
}