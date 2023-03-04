using SimpleDomain.Entities;
using SimpleDomain.Repositories;
using SimpleInfra.Database;

namespace SimpleInfra.Repositories
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(InMemoryDbContext context) : base(context)
        {
        }
    }
}