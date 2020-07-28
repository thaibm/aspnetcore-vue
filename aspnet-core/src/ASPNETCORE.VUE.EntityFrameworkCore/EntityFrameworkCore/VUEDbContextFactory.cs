using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using ASPNETCORE.VUE.Configuration;
using ASPNETCORE.VUE.Web;

namespace ASPNETCORE.VUE.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class VUEDbContextFactory : IDesignTimeDbContextFactory<VUEDbContext>
    {
        public VUEDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<VUEDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            VUEDbContextConfigurer.Configure(builder, configuration.GetConnectionString(VUEConsts.ConnectionStringName));

            return new VUEDbContext(builder.Options);
        }
    }
}
