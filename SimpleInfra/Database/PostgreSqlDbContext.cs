using Microsoft.EntityFrameworkCore;
using SimpleDomain.Entities;
using SimpleInfra.TypeConfiguratiions;


namespace SimpleInfra.Database
{
    public class PostgreSqlDbContext : DbContext
    {
        /*
        TODO: Adicionar verificação se existe o banco, caso não, criar.
        TODO: Adicionar o OnModelCreating para configurar as tabelas sobre código.
        TODO: Criar uma Classe TypeConfiguration para cada entidade com as configurações de cada tabela.

        */
        public PostgreSqlDbContext(
            DbContextOptions<PostgreSqlDbContext> options
        ) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Adicionar as configurações de cada tabela.
            modelBuilder.ApplyConfiguration(new UserTypeConfiguration());
            modelBuilder.ApplyConfiguration(new RoleTypeConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public void Save()
        {
            base.SaveChanges();
        }
    }
}