using System.Threading.Tasks;
using ASPNETCORE.VUE.Configuration.Dto;

namespace ASPNETCORE.VUE.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
