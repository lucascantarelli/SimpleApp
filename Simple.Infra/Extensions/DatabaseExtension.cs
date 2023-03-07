using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Simple.Infra.Database;

namespace Simple.Infra.Extensions
{
    public static class DatabaseExtension
    {
        public static void Configure(this IServiceCollection services, string connectionString)
        {
            // Database - Sqlite
            services.AddDbContext<SqlServerDbContext>(
                options => options.UseSqlite(
                    connectionString: connectionString,
                    b => b.MigrationsAssembly("Simple.Infra")
                )
                .LogTo(System.Console.WriteLine));
        }
    }
}