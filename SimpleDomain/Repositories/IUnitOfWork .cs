using SimpleDomain.Repositories;

namespace SimpleDomain.Repositories
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        IRoleRepository Roles { get; }

        Task<int> CommitAsync();
        Task RollbackAsync();
    }
}