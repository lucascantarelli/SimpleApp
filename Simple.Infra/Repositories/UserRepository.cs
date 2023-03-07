using Simple.Domain.Entities;
using Simple.Domain.Interfaces.Repositories;
using Simple.Infra.Database;

namespace Simple.Infra.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(SqlServerDbContext context) : base(context)
        {
        }
    }
}