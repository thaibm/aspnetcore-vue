using Abp.MultiTenancy;
using ASPNETCORE.VUE.Authorization.Users;

namespace ASPNETCORE.VUE.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
