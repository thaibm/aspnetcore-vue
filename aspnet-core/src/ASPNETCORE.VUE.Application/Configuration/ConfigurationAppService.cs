using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using ASPNETCORE.VUE.Configuration.Dto;

namespace ASPNETCORE.VUE.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : VUEAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
