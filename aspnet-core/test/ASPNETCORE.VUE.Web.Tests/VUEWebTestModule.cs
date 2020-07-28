using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ASPNETCORE.VUE.EntityFrameworkCore;
using ASPNETCORE.VUE.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace ASPNETCORE.VUE.Web.Tests
{
    [DependsOn(
        typeof(VUEWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class VUEWebTestModule : AbpModule
    {
        public VUEWebTestModule(VUEEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(VUEWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(VUEWebMvcModule).Assembly);
        }
    }
}