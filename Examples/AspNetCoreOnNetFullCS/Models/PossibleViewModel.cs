using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GleamTech.DocumentUltimateExamples.AspNetCoreOnNetFullCS.Models
{
    public class PossibleViewModel
    {
        public PossibleViewModel()
        {
            InputFormats = new Dictionary<string, List<SelectListItem>>();
            OutputFormats = new Dictionary<string, List<SelectListItem>>();
        }

        public int InputFormatCount { get; set; }

        public int OutputFormatCount { get; set; }

        public string ResultHandlerUrl { get; set; }

        public Dictionary<string, List<SelectListItem>> InputFormats { get; set; }

        public Dictionary<string, List<SelectListItem>> OutputFormats { get; set; }
    }
}
