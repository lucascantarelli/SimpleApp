using SimpleDomain.Repositories;
using SimpleInfra.Database;

namespace SimpleInfra.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly InMemoryDbContext _context;
        public IRoleRepository Roles { get; private set; }
        public IUserRepository Users { get; private set; }
        public UnitOfWork(InMemoryDbContext context)
        {
            _context = context;
            Roles = new RoleRepository(_context);
            Users = new UserRepository(_context);
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task RollbackAsync()
        {
            await _context.DisposeAsync();
        }
    }
}