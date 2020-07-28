using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace ASPNETCORE.VUE.Controllers
{
    public abstract class VUEControllerBase: AbpController
    {
        protected VUEControllerBase()
        {
            LocalizationSourceName = VUEConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
