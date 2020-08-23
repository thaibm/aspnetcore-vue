using System;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.AspNetCore.SignalR;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.Configuration;
using ASPNETCORE.VUE.Authentication.JwtBearer;
using ASPNETCORE.VUE.Configuration;
using ASPNETCORE.VUE.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using ASPNETCORE.VUE.Authentication.External;
using ASPNETCORE.VUE.Authentication.Social;
using System.Collections.Generic;

namespace ASPNETCORE.VUE
{
    [DependsOn(
         typeof(VUEApplicationModule),
         typeof(VUEEntityFrameworkModule),
         typeof(AbpAspNetCoreModule)
        , typeof(AbpAspNetCoreSignalRModule)
     )]
    public class VUEWebCoreModule : AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public VUEWebCoreModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                VUEConsts.ConnectionStringName
            );

            // Use database for language management
            Configuration.Modules.Zero().LanguageManagement.EnableDbLocalization();

            Configuration.Modules.AbpAspNetCore()
                 .CreateControllersForAppServices(
                     typeof(VUEApplicationModule).GetAssembly()
                 );

            ConfigureTokenAuth();
        }

        private void ConfigureTokenAuth()
        {
            IocManager.Register<TokenAuthConfiguration>();
            var tokenAuthConfig = IocManager.Resolve<TokenAuthConfiguration>();

            tokenAuthConfig.SecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_appConfiguration["Authentication:JwtBearer:SecurityKey"]));
            tokenAuthConfig.Issuer = _appConfiguration["Authentication:JwtBearer:Issuer"];
            tokenAuthConfig.Audience = _appConfiguration["Authentication:JwtBearer:Audience"];
            tokenAuthConfig.SigningCredentials = new SigningCredentials(tokenAuthConfig.SecurityKey, SecurityAlgorithms.HmacSha256);
            tokenAuthConfig.Expiration = TimeSpan.FromDays(1);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(VUEWebCoreModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(VUEWebCoreModule).Assembly);
            
            var providers = new List<ExternalLoginProviderInfo>();

            if (_appConfiguration.GetValue<bool>("Authentication:Facebook:IsEnabled"))
            {
                providers.Add(new ExternalLoginProviderInfo(
                    FacebookAuthProvider.Name,
                    _appConfiguration["Authentication:Facebook:AppId"],
                    _appConfiguration["Authentication:Facebook:AppSecret"],
                    typeof(FacebookAuthProvider)
                ));
            }

            if (_appConfiguration.GetValue<bool>("Authentication:Google:IsEnabled"))
            {
                providers.Add(new ExternalLoginProviderInfo(
                    GoogleAuthProvider.Name,
                    _appConfiguration["Authentication:Google:ClientId"],
                    _appConfiguration["Authentication:Google:ClientSecret"],
                    typeof(GoogleAuthProvider)
                ));
            }

            var externalAuthConfiguration = IocManager.Resolve<IExternalAuthConfiguration>();
            externalAuthConfiguration.Providers.AddRange(providers);
        }
    }
}
