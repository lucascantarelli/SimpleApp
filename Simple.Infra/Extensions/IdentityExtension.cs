using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Simple.Infra.Database;
using Simple.Infra.Entities;

namespace Simple.Infra.Extensions
{
    public static class IdentityExtension
    {
        public static void Configure(this IServiceCollection services, IConfiguration configuration)
        {
            // Identity
            services.AddDbContext<IdentityContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("SqlConnectionString"),
                    b => b.MigrationsAssembly("Simple.Infra")
            ));

            services.AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<IdentityContext>()
                .AddDefaultTokenProviders();
        }
    }
}