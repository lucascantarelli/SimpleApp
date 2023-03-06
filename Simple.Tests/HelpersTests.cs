using System.Threading.Tasks;
using Simple.Infra.Database;
using Simple.Infra.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Simple.Tests
{
    public class HelpersTests
    {
        private readonly SqlServerDbContext _sqlServerDbContext;

        public HelpersTests()
        {
            var builder = new DbContextOptionsBuilder<SqlServerDbContext>();
            builder.UseSqlite("Data Source=SimpleDB.db");

            _sqlServerDbContext = new SqlServerDbContext(builder.Options);

            _sqlServerDbContext.Database.EnsureDeleted();
            _sqlServerDbContext.Database.EnsureCreated();

        }

        public UserRepository GetUserRepositoryAsync()
        {
            return new UserRepository(_sqlServerDbContext);
        }

        public RoleRepository GetRoleRepositoryAsync()
        {
            return new RoleRepository(_sqlServerDbContext);
        }
    }
}