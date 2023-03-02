using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SimpleDomain;
using SimpleDomain.Repositories;
using SimpleInfra.Repositories;
using SimpleInfra.Tools;

namespace SimpleInfra
{
    public static class IoCServices
    {
        public static void ConfigureServices(this IServiceCollection services)
        {

            services.AddDbContext<InMemoryDbContext>(options => options.UseInMemoryDatabase("SimpleDb"));


            /*
             * Injeção de dependência para o repositório genérico
             */
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient(typeof(IRoleRepository), typeof(RoleRepository));
            services.AddTransient(typeof(IUserRepository), typeof(UserRepository));

        }
    }
}