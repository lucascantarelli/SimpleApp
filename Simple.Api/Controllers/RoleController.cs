using Microsoft.AspNetCore.Mvc;

using Simple.Domain.Entities;
using Simple.Domain.Repositories;

namespace Simple.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly ILogger<RoleController> _logger;
        private readonly IRoleRepository _db;
        public RoleController(ILogger<RoleController> logger, IRoleRepository db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpPost(Name = "CreateRole")]
        public async Task<IActionResult> Post([FromBody] Role role)
        {
            if (role == null)
            {
                return BadRequest();
            }

            if (role.Id != 0)
            {
                return BadRequest();
            }

            await _db.AddAsync(role);

            return CreatedAtRoute("GetRole", new { id = role.Id }, role);
        }

        [HttpGet("{id}", Name = "GetRole")]
        public async Task<IActionResult> Get(int id)
        {
            var role = await _db.GetAsync(
                x => x.Id == id && !x.IsDeleted
            );

            if (role == null)
            {
                return NotFound();
            }

            return Ok(role);
        }

        [HttpGet(Name = "GetAllRoles")]
        public async Task<IActionResult> Get()
        {
            var roles = await _db.GetAllAsync();
            if (roles == null)
            {
                return NotFound();
            }

            return Ok(roles);
        }

        [HttpPut(Name = "UpdateRole")]
        public async Task<IActionResult> Put([FromBody] Role role)
        {
            if (role == null)
            {
                return BadRequest();
            }

            if (role.Id == 0)
            {
                return BadRequest();
            }

            var roleDb = await _db.GetAsync(x => x.Id == role.Id);
            if (roleDb == null)
            {
                return NotFound();
            }

            roleDb.Description = role.Description;

            await _db.UpdateAsync(roleDb);

            return Ok(roleDb);
        }

        [HttpDelete("{id}", Name = "DeleteRole")]
        public async Task<IActionResult> Delete(int id)
        {
            var roleDb = await _db.GetAsync(x => x.Id == id);
            if (roleDb == null)
            {
                return NotFound();
            }

            roleDb.IsDeleted = true;

            await _db.UpdateAsync(roleDb);

            return Ok(roleDb);
        }

    }
}