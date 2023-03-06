using Microsoft.Extensions.DependencyInjection;

namespace Simple.Infra
{
    public static class InfraStartup
    {
        public static void Start(this IServiceCollection services, string connectionString)
        {
            // IoC - Injeção de Dependência.
            Simple.Infra.DependenceInjection.Configure(
                services: services
            );

            // Extensions - Extensões.
            Simple.Infra.Extensions.Configure(
                services: services,
                connectionString: connectionString
            );
        }
    }
}