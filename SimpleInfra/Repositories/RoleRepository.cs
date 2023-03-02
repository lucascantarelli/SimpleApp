using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleDomain.Entities;
using SimpleDomain.Repositories;
using SimpleInfra.Tools;

namespace SimpleInfra.Repositories
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(InMemoryDbContext context) : base(context)
        {
        }
    }
}