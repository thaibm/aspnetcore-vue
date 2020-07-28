using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace ASPNETCORE.VUE.EntityFrameworkCore
{
    public static class VUEDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<VUEDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<VUEDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
