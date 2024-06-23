using Microsoft.AspNetCore.Mvc;
using ViewLibrary.Pdks.Dtos.Pdks.RoleDtos;

//using ViewLibrary.Pdks.Dtos.Pdks.Role;
using pdksApi.Services.Interface;

namespace pdksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        [Route("/api/roller")]
        public async Task<IActionResult> Get()
        {
            var result = await _roleService.GetList();
            return Ok(result);
        }

        // GET api/<ValuesController>/5
        [HttpGet("/api/rol/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _roleService.GetRoleById(id);
            return Ok(result);
        }

        // POST api/<ValuesController>
        [HttpPost("/api/rolkaydet")]
        public async Task<IActionResult> Post([FromBody] RoleAddDto value)
        {
            var result = await _roleService.Create(value);
            return Ok(result);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("/api/rolguncelle")]
        public async Task<IActionResult> Put(int id, [FromBody] RoleUpdateDto value)
        {
            var result = await _roleService.Update(value);
            return Ok(result);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("/api/rolsil/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _roleService.Delete(id);
            return Ok(result);
        }
    }
}
