using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZavrsnaAplikacija2.Models;

namespace ZavrsnaAplikacija2
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
            app.UseFacebookAuthentication
                (
                appId: "1093819275122811",
                appSecret: "4534eb8397f4b6eea956e7279cd8ec7b"
            );
            app.UseTwitterAuthentication
                (
                    consumerKey: "oUsMHs7gnxOi6fpIttCqBoJ0i",
                    consumerSecret: "wCuVMEPmirGpbqJC4MlTApuyRnDItdfSxTfCGGx3kFufzA5y5a"
                );
            app.UseGoogleAuthentication
                (
                    clientId: "95120325107-pt0kig9e71rbrbppjnkonacelksin24e.apps.googleusercontent.com",
                    clientSecret: "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"
                );
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,

                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    OnValidateIdentity =
                    SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
                        validateInterval: TimeSpan.FromMinutes(30),
                        regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
                }
            });
        }
    }
}