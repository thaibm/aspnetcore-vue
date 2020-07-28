using Abp.Application.Features;
using Abp.Domain.Repositories;
using Abp.MultiTenancy;
using ASPNETCORE.VUE.Authorization.Users;
using ASPNETCORE.VUE.Editions;

namespace ASPNETCORE.VUE.MultiTenancy
{
    public class TenantManager : AbpTenantManager<Tenant, User>
    {
        public TenantManager(
            IRepository<Tenant> tenantRepository, 
            IRepository<TenantFeatureSetting, long> tenantFeatureRepository, 
            EditionManager editionManager,
            IAbpZeroFeatureValueStore featureValueStore) 
            : base(
                tenantRepository, 
                tenantFeatureRepository, 
                editionManager,
                featureValueStore)
        {
        }
    }
}
