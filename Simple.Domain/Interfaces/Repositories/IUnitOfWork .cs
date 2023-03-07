using Simple.Domain.Interfaces.Repositories;

namespace Simple.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        IRoleRepository Roles { get; }

        Task<int> CommitAsync();
        Task RollbackAsync();
    }
}