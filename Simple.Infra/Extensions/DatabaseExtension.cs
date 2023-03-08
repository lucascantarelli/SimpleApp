using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Simple.Infra.Database;

namespace Simple.Infra.Extensions
{
    public static class DatabaseExtension
    {
        public static void Configure(this IServiceCollection services, IConfiguration configuration)
        {
            // Database - Sqlite
            services.AddDbContext<SqlServerDbContext>(
                options => options.UseSqlite(
                    connectionString: configuration.GetConnectionString("SqlConnectionString"),
                    b => b.MigrationsAssembly("Simple.Infra")
                )
                .LogTo(System.Console.WriteLine));
        }
    }
}