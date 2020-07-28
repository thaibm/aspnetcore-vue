using Abp.Application.Services;
using ASPNETCORE.VUE.MultiTenancy.Dto;

namespace ASPNETCORE.VUE.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

