using Microsoft.EntityFrameworkCore;
using SimpleDomain.Entities;
using SimpleInfra.Database;

namespace SimpleTests.Repositories
{
    public abstract class GenericRepositoryTests
    {
        private DbContextOptions<InMemoryDbContext> _options;

        public GenericRepositoryTests()
        {
            this._options = new DbContextOptionsBuilder<InMemoryDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryDb")
                .Options;

            using (var context = GetContext())  // Seed
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Users.Add(new User
                {
                    Name = "Test User",
                    Email = "test@local.com",
                    Password = "123456"
                });

                context.SaveChanges();
            }
        }

        protected InMemoryDbContext GetContext()
        {
            return new InMemoryDbContext(_options);
        }
    }
}