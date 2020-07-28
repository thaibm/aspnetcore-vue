using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Abp.Authorization;
using ASPNETCORE.VUE.Authorization.Roles;
using ASPNETCORE.VUE.Authorization.Users;
using ASPNETCORE.VUE.MultiTenancy;
using Microsoft.Extensions.Logging;

namespace ASPNETCORE.VUE.Identity
{
    public class SecurityStampValidator : AbpSecurityStampValidator<Tenant, Role, User>
    {
        public SecurityStampValidator(
            IOptions<SecurityStampValidatorOptions> options,
            SignInManager signInManager,
            ISystemClock systemClock,
            ILoggerFactory loggerFactory) 
            : base(options, signInManager, systemClock, loggerFactory)
        {
        }
    }
}
