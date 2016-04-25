using System;
using System.IO;
using System.Web;
using GleamTech.DocumentUltimate;

namespace GleamTech.DocumentUltimateExamples.WebForms.CS
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            var licenseFile = Server.MapPath("~/App_Data/License.dat");
            if (File.Exists(licenseFile))
                DocumentUltimateConfiguration.Current.LicenseKey = File.ReadAllText(licenseFile);
        }
    }
}