using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SimpleInfra.Database;

namespace SimpleInfra
{
    public static class Extensions
    {
        public static void Configure(this IServiceCollection services, string connectionString)
        {
            // Database - InMemory
            services.AddDbContext<InMemoryDbContext>(options => options.UseInMemoryDatabase("SimpleDB"));

            // Database - SqlServer
            services.AddDbContext<PostgreSqlDbContext>(
                options => options.UseNpgsql(connectionString: connectionString, b => b.MigrationsAssembly("SimpleInfra")));

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }
    }
}