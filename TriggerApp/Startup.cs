using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System.IO;
using TriggerApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using TriggerApp.AuthticationHelper;
using Microsoft.Extensions.Configuration;

namespace TriggerApp
{
    public class Startup
    {
        public IConfiguration Configuration { get;}

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            /*Enabling MVC requires that supported MVC features to be registered/injected into the defalut ASP.NET core DI container*/
            services.AddMvc();

            /*Enabling Authentication by Injecting Authentication middleware which does not using the Identity*/
            services.AddAuthentication(options => {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
            .AddAzureAd(options=>
            {
                Configuration.Bind("AzureAd", options);
            })
            .AddCookie();

            //services.AddIdentity<Users, IdentityRole>();            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            /*Enabling the yellow page of Death if environment is Development*/
            if (env.IsDevelopment())
            {                
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseAuthentication();
            /* Enabling the MVC, as by default in ASP.NET Core the MVC is not enabled. It need to be configured as middleware*/
            app.UseMvc(configRoute =>
            {
                configRoute.MapRoute(
                    name: "Welcome",
                    template: "Default/{controller}/{action}/{id?}",
                    defaults: new { controller = "Landing", action = "DefaultLand" }
                    );
            }
            );            
        }
    }
}
