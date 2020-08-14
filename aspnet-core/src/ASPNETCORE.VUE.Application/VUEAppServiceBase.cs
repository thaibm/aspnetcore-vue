using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Abp.Application.Services;
using Abp.IdentityFramework;
using Abp.Runtime.Session;
using ASPNETCORE.VUE.Authorization.Users;
using ASPNETCORE.VUE.MultiTenancy;
using ASPNETCORE.VUE.Users.Dto;

namespace ASPNETCORE.VUE
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class VUEAppServiceBase : ApplicationService
    {
        public TenantManager TenantManager { get; set; }

        public Users.UserAppService UserAppService { get; set; }

        protected VUEAppServiceBase()
        {
            LocalizationSourceName = VUEConsts.LocalizationSourceName;
        }

        protected virtual async Task<UserDto> GetCurrentUserAsync()
        {

            var user = await UserAppService.GetUserByIdAsync(AbpSession.GetUserId());
            if (user == null)
            {
                throw new Exception("There is no current user!");
            }

            return user;
        }

        protected virtual Task<Tenant> GetCurrentTenantAsync()
        {
            return TenantManager.GetByIdAsync(AbpSession.GetTenantId());
        }

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
