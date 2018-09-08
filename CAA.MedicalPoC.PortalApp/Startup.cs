using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.WsFederation;
using Owin;

[assembly: OwinStartup(typeof(CAA.MedicalPoC.PortalApp.Startup))]

namespace CAA.MedicalPoC.PortalApp
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            ConfigureAuth(app);
        }

        public void ConfigureAuth(IAppBuilder app)
        {
            app.UseCookieAuthentication(
            new CookieAuthenticationOptions
            {
                AuthenticationType = CookieAuthenticationDefaults.AuthenticationType
            });
            app.UseWsFederationAuthentication(
            new WsFederationAuthenticationOptions
            {
                //MetadataAddress = "https://login.microsoftonline.com/c4edd5ba-10c3-4fe3-946a-7c9c446ab8c8/federationmetadata/2007-06/federationmetadata.xml",
                MetadataAddress = "https://sts.caalab.co.uk/federationmetadata/2007-06/federationmetadata.xml",
                Wtrealm = "http://portal.caalab.co.uk/",
            });

            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);
        }
    }
}
