using API.AutorizationProvider;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace API
{
    public class Startup
    { 
        public void Configuration(IAppBuilder app)
        {

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            var myProvider = new AutorizationToken();
            OAuthAuthorizationServerOptions options = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = myProvider
            };
            app.UseOAuthAuthorizationServer(options);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}