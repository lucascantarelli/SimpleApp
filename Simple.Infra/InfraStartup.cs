using Microsoft.Extensions.DependencyInjection;
using Simple.Infra.Extensions;

namespace Simple.Infra
{
    public static class InfraStartup
    {
        public static void Start(this IServiceCollection services, string connectionString)
        {
            // Extensions - Injeção de Dependência.
            DependenceInjection.Configure(
                services: services
            );

            // Extensions - Database.
            DatabaseExtension.Configure(
                services: services,
                connectionString: connectionString
            );

            // Extensions - Identity.
            IdentityExtension.Configure(
                services: services,
                connectionString: connectionString
            );
        }
    }
}