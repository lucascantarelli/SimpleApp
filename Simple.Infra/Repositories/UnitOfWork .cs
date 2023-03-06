using Simple.Domain.Repositories;
using Simple.Infra.Database;

namespace Simple.Infra.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SqlServerDbContext _context;
        public IRoleRepository Roles { get; private set; }
        public IUserRepository Users { get; private set; }
        public UnitOfWork(SqlServerDbContext context)
        {
            this._context = context;
            this.Roles = new RoleRepository(_context);
            this.Users = new UserRepository(_context);
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