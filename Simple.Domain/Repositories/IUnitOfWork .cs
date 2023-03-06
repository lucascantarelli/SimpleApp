using Simple.Domain.Repositories;

namespace Simple.Domain.Repositories
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        IRoleRepository Roles { get; }

        Task<int> CommitAsync();
        Task RollbackAsync();
    }
}