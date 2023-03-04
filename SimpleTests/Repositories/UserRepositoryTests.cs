using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using SimpleDomain.Entities;
using SimpleDomain.Repositories;
using SimpleInfra.Repositories;

namespace SimpleTests.Repositories
{

    public class UserRepositoryTests : GenericRepositoryTests
    {
        private readonly UserRepository _userRepository;
        public UserRepositoryTests()
        {
            _userRepository = new UserRepository(GetContext());
        }

        [Fact]
        public async Task GetAllUsersSuccessTest()
        {
            var users = await _userRepository.GetAllAsync();

            Assert.NotEmpty(users);
        }
    }
}