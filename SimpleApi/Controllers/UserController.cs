using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleDomain.Entities;
using SimpleDomain.Repositories;

namespace SimpleApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserRepository _db;
        public UserController(ILogger<UserController> logger, IUserRepository db)
        {
            _logger = logger;
            _db = db;
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

            await _db.AddAsync(user);


            return CreatedAtRoute("GetUser", new { id = user.Id }, user);
        }

        [HttpGet("{id}", Name = "GetUser")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _db.GetAsync(
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
            var users = await _db.GetAllAsync();
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

            var userDb = await _db.UpdateAsync(user);
            if (userDb == null)
            {
                return NotFound();
            }

            userDb.Name = user.Name;
            userDb.Email = user.Email;
            userDb.Password = user.Password;
            userDb.UpdatedAt = DateTime.Now;



            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteUser")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _db.GetAsync(
                x => x.Id == id && !x.IsDeleted
            );

            if (user == null)
            {
                return NotFound();
            }

            user.IsDeleted = true;
            user.UpdatedAt = DateTime.Now;

            await _db.UpdateAsync(user);

            return NoContent();
        }

    }
}