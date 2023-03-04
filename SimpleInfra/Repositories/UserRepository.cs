using SimpleDomain.Entities;
using SimpleDomain.Repositories;
using SimpleInfra.Database;

namespace SimpleInfra.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(InMemoryDbContext context) : base(context)
        {
        }
    }
}