using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Simple.Infra.Database;
using Simple.Infra.Entities;

namespace Simple.Infra.Extensions
{
    public static class IdentityExtension
    {
        public static void Configure(this IServiceCollection services, string connectionString)
        {
            // Identity
            services.AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<IdentityContext>();

        }
    }
}