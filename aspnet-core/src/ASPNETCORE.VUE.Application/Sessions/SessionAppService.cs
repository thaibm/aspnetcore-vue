using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Auditing;
using ASPNETCORE.VUE.Sessions.Dto;

namespace ASPNETCORE.VUE.Sessions
{
    public class SessionAppService : VUEAppServiceBase, ISessionAppService
    {
        [DisableAuditing]
        public async Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations()
        {
            var output = new GetCurrentLoginInformationsOutput
            {
                Application = new ApplicationInfoDto
                {
                    Version = AppVersionHelper.Version,
                    ReleaseDate = AppVersionHelper.ReleaseDate,
                    Features = new Dictionary<string, bool>()
                }
            };

            if (AbpSession.TenantId.HasValue)
            {
                output.Tenant = ObjectMapper.Map<TenantLoginInfoDto>(await GetCurrentTenantAsync());
            }

            if (AbpSession.UserId.HasValue)
            {
                var user = await GetCurrentUserAsync();
                output.User = new UserLoginInfoDto()
                {
                    Id = user.Id,
                    Name = user.Name,
                    Surname = user.Surname,
                    UserName = user.UserName,
                    RoleNames = user.RoleNames,
                    EmailAddress = user.EmailAddress,
                };
            }

            return output;
        }
    }
}
