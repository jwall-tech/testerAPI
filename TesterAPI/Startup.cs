// System
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// Microsoft
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using Okta.AspNet;
using Microsoft.Owin.Security;
using Owin;
using CookieAuthenticationOptions = Microsoft.Owin.Security.Cookies.CookieAuthenticationOptions;
using CookieAuthenticationDefaults = Microsoft.Owin.Security.Cookies.CookieAuthenticationDefaults;
// TesterAPI

namespace TesterAPI 
{
    public class Startup
    {
        // Public Variables
        public IConfiguration ConfigurationI { get; }

        public Startup(IConfiguration configuration)
        {
            ConfigurationI = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Authenticiation
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
            .AddCookie()
            .AddOpenIdConnect(options =>
            {
                options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.Authority = Configuration["Okta:Domain"] + "/oauth2/default";
                options.RequireHttpsMetadata = true;
                options.ClientId = Configuration["Okta:ClientId"];
                options.ClientSecret = Configuration["Okta:ClientSecret"];
                options.ResponseType = OpenIdConnectResponseType.Code;
                options.GetClaimsFromUserInfoEndpoint = true;
                options.Scope.Add("openid");
                options.Scope.Add("profile");
                options.SaveTokens = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    NameClaimType = "name",
                    RoleClaimType = "groups",
                    ValidateIssuer = true
                };
            });

            // Authorization
            services.AddAuthorization();

            // Controllers
            services.AddMvc();

            //Swagger
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "TesterAPI", Version = "v1" });
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                // Swagger
                //app.UseDeveloperExceptionPage();
                //app.UseSwagger();
                //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TesterAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            // Using auths
            app.UseAuthorization();
            app.UseAuthentication();

            // Endpoint Setup
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public void Configuration(Owin.IAppBuilder app)
        {
            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);
            app.UseCookieAuthentication(new CookieAuthenticationOptions());

            app.UseOktaMvc(new OktaMvcOptions()
            {
                OktaDomain = ConfigurationI["okta:OktaDomain"],
                ClientId = ConfigurationI["okta:ClientId"],
                ClientSecret = ConfigurationI["okta:ClientSecret"],
                RedirectUri = ConfigurationI["okta:RedirectUri"],
            });
        }
    }
}