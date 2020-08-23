using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ASPNETCORE.VUE.Configuration;
using ASPNETCORE.VUE.Authentication.External;

namespace ASPNETCORE.VUE.Web.Host.Startup
{
    [DependsOn(
       typeof(VUEWebCoreModule))]
    public class VUEWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public VUEWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(VUEWebHostModule).GetAssembly());
        }
    }
}
