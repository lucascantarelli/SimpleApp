using System.Threading.Tasks;
using Simple.Infra.Repositories;
using Simple.Domain.Entities;
using Xunit;

namespace Simple.Tests.Repositories
{
    public class UserRepositoryCreateTests
    {
        [Fact]
        public async Task CreateUserSuccessAsync()
        {
            // Arrange
            var helpers = new HelpersTests();
            var userRepository = helpers.GetUserRepositoryAsync();

            // Act
            var user = await userRepository.AddAsync(new User
            {
                Name = "User 1",
                Email = "user1@local.com",
                Password = "123456"
            });


            // Assert


        }
    }
}