using Microsoft.Extensions.DependencyInjection;
using Simple.Domain.Repositories;
using Simple.Infra.Repositories;

namespace Simple.Infra
{
    public static class DependenceInjection
    {
        public static void Configure(this IServiceCollection services)
        {
            /*
             * IoC - Inversão de controle nas injeções de dependências.
             */
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IRoleRepository), typeof(RoleRepository));
            services.AddScoped(typeof(IUserRepository), typeof(UserRepository));

        }
    }
}