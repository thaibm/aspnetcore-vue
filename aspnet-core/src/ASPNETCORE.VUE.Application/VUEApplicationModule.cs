using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ASPNETCORE.VUE.Authorization;

namespace ASPNETCORE.VUE
{
    [DependsOn(
        typeof(VUECoreModule), 
        typeof(AbpAutoMapperModule))]
    public class VUEApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<VUEAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(VUEApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
