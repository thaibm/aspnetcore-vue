using System.Threading.Tasks;
using Abp.Application.Services;
using ASPNETCORE.VUE.Sessions.Dto;

namespace ASPNETCORE.VUE.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
