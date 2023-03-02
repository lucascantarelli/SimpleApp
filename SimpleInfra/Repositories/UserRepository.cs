using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleDomain.Entities;
using SimpleDomain.Repositories;
using SimpleInfra.Tools;

namespace SimpleInfra.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(InMemoryDbContext context) : base(context)
        {
        }
    }
}