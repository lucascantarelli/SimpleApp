using Microsoft.EntityFrameworkCore;
using SimpleDomain.Entities;

namespace SimpleInfra.Database
{
    public class InMemoryDbContext : DbContext
    {
        public InMemoryDbContext(DbContextOptions<InMemoryDbContext> options) : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<Role> Roles => Set<Role>();

        public void Save()
        {
            base.SaveChanges();
        }
    }
}