using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using ASPNETCORE.VUE.Authorization.Roles;
using ASPNETCORE.VUE.Authorization.Users;
using ASPNETCORE.VUE.MultiTenancy;

namespace ASPNETCORE.VUE.EntityFrameworkCore
{
    public class VUEDbContext : AbpZeroDbContext<Tenant, Role, User, VUEDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public VUEDbContext(DbContextOptions<VUEDbContext> options)
            : base(options)
        {
        }
    }
}
