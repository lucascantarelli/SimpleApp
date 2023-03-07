using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Simple.Infra.Entities;
using Simple.Infra.TypeConfigurations;

namespace Simple.Infra.Database
{
    public class IdentityContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public IdentityContext()
        {

        }
        public IdentityContext(
            DbContextOptions<IdentityDbContext<AppUser, AppRole, Guid>> options
        ) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=SimpleDB.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Adicionar as configurações de cada tabela.
            modelBuilder.ApplyConfiguration<AppUser>(new AppUserTypeConfiguration());
            modelBuilder.ApplyConfiguration<AppRole>(new AppRoleTypeConfiguration());
            modelBuilder.ApplyConfiguration<IdentityUserClaim<Guid>>(new AppUserClaimTypeConfiguration());
            modelBuilder.ApplyConfiguration<IdentityUserLogin<Guid>>(new AppUserLoginTypeConfiguration());
            modelBuilder.ApplyConfiguration<IdentityUserRole<Guid>>(new AppUserRoleTypeConfiguration());
            modelBuilder.ApplyConfiguration<IdentityUserToken<Guid>>(new AppUserTokenTypeConfiguration());
            modelBuilder.ApplyConfiguration<IdentityRoleClaim<Guid>>(new AppRoleClaimTypeConfiguration());
        }
    }
}