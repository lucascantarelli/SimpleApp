using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using SimpleDomain.Entities;
using SimpleDomain.Repositories;
using SimpleDomain.UnitOfWork;

namespace SimpleApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public UserController(ILogger<UserController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpPost(Name = "CreateUser")]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            if (user.Id != 0)
            {
                return BadRequest();
            }

            await _unitOfWork.Users.AddAsync(user);

            return CreatedAtRoute("GetUser", new { id = user.Id }, user);
        }

        [HttpGet("{id}", Name = "GetUser")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _unitOfWork.Users.GetAsync(
                x => x.Id == id && !x.IsDeleted
            );

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet(Name = "GetAllUsers")]
        public async Task<IActionResult> Get()
        {
            var users = await _unitOfWork.Users.GetAllAsync(
                x => !x.IsDeleted
            );
            if (users == null)
            {
                return NotFound();
            }

            return Ok(users);
        }

        [HttpPut(Name = "UpdateUser")]
        public async Task<IActionResult> Put([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            if (user.Id == 0)
            {
                return BadRequest();
            }

            var userDb = await _unitOfWork.Users.GetAsync(
                x => x.Id == user.Id && !x.IsDeleted
            );

            if (userDb == null)
            {
                return NotFound();
            }

            userDb.Name = user.Name;
            userDb.Email = user.Email;
            userDb.Password = user.Password;
            userDb.UpdatedAt = DateTime.Now;

            _unitOfWork.CommitAsync();

            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteUser")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _unitOfWork.Users.GetAsync(
                x => x.Id == id && !x.IsDeleted
            );

            if (user == null)
            {
                return NotFound();
            }

            user.IsDeleted = true;
            user.UpdatedAt = DateTime.Now;

            await _unitOfWork.Users.UpdateAsync(user);

            return NoContent();
        }

    }
}