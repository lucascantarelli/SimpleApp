using SimpleDomain.Repositories;

namespace SimpleDomain.UnitOfWork
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        IRoleRepository Roles { get; }

        Task<int> CommitAsync();
        Task RollbackAsync();
    }
}