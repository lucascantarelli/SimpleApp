using Microsoft.Extensions.DependencyInjection;

namespace SimpleInfra
{
    public static class InfraStartup
    {
        public static void Start(this IServiceCollection services, string connectionString)
        {
            // IoC - Injeção de Dependência.
            SimpleInfra.DependenceInjection.Configure(
                services: services
            );

            // Extensions - Extensões.
            SimpleInfra.Extensions.Configure(
                services: services,
                connectionString: connectionString
            );
        }
    }
}