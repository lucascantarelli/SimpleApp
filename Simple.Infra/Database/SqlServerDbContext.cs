using Microsoft.EntityFrameworkCore;
using Simple.Infra.TypeConfigurations;

namespace Simple.Infra.Database
{
    public class SqlServerDbContext : DbContext
    {
        public SqlServerDbContext(
            DbContextOptions<SqlServerDbContext> options
        ) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Adicionar as configurações de cada tabela.
            modelBuilder.ApplyConfiguration(new UserTypeConfiguration());
            modelBuilder.ApplyConfiguration(new RoleTypeConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}