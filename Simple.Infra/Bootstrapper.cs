using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Simple.Infra
{
    public static class Bootstrapper
    {
        public static IServiceCollection Configure(this IServiceCollection services, IConfiguration configuration)
        {
            /*
            * Configure - Método responsável por configurar a camada.
            @param services - Serviços do app.
            @param configuration - Configurações do app.
            return IServiceCollection - Coleção de serviços
            */

            // Configurações das Extensões.
            // Database
            Extensions.DatabaseExtension.Configure(services, configuration);

            // Identity
            Extensions.IdentityExtension.Configure(services, configuration);


            // IoC - Injeção de Dependência
            DependenceInjection.Configure(services);

            return services;
        }
    }
}