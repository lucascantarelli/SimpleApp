using Simple.Domain.Entities;
using Simple.Domain.Repositories;
using Simple.Infra.Database;

namespace Simple.Infra.Repositories
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(SqlServerDbContext context) : base(context)
        {
        }
    }
}