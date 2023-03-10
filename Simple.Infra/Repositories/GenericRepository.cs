using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Simple.Domain.Interfaces.Repositories;
using Simple.Infra.Database;

namespace Simple.Infra.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly SqlServerDbContext _context;
        private DbSet<TEntity> _dbSet;

        public GenericRepository(SqlServerDbContext context)
        {
            this._context = context;
            this._dbSet = _context.Set<TEntity>();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default)
        {
            return await _dbSet.FirstOrDefaultAsync(expression, cancellationToken) ?? throw new Exception("Entity not found");
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default)
        {
            return await _dbSet.Where(expression).ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbSet.ToListAsync(cancellationToken);
        }

        public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await _dbSet.AddAsync(entity, cancellationToken);
            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task<TEntity> DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity;
        }
    }
}