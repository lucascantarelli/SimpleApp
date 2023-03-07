using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Simple.Infra.Entities;
using Simple.Infra.TypeConfigurations;

namespace Simple.Infra.Database
{
    public class IdentityContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public IdentityContext()
        {

        }
        public IdentityContext(
            DbContextOptions<IdentityDbContext<AppUser>> options
        ) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=SimpleDB.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            // Adicionar as configurações de cada tabela.
            modelBuilder.ApplyConfiguration(new AppUserTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AppRoleTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserClaimTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserLoginTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserTokenTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserRoleTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AppRoleClaimTypeConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}