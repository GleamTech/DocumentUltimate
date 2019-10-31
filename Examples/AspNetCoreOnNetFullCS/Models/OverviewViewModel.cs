using System.Collections.Generic;
using GleamTech.Examples;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GleamTech.DocumentUltimateExamples.AspNetCoreOnNetFullCS.Models
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