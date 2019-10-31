using System;
using System.IO;
using System.Web;
using GleamTech.AspNet;
using GleamTech.DocumentUltimate;

namespace GleamTech.DocumentUltimateExamples.AspNetWebFormsCS
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            var gleamTechConfig = Hosting.ResolvePhysicalPath("~/App_Data/GleamTech.config");
            if (File.Exists(gleamTechConfig))
                GleamTechConfiguration.Current.Load(gleamTechConfig);

            var documentUltimateConfig = Hosting.ResolvePhysicalPath("~/App_Data/DocumentUltimate.config");
            if (File.Exists(documentUltimateConfig))
                DocumentUltimateConfiguration.Current.Load(documentUltimateConfig);
        }
    }
}