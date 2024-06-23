using Microsoft.AspNetCore.Mvc;
using ViewLibrary.Pdks.Dtos.Pdks.UserRoleDtos;

//using ViewLibrary.Pdks.Dtos.Pdks.UserRole;
using pdksApi.Services.Interface;

namespace pdksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        private readonly IUserRoleService _userRoleService;
        public UserRoleController(IUserRoleService userRoleService)
        {
            _userRoleService = userRoleService;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        [Route("/api/kullaniciroller/{userId}")]
        public async Task<IActionResult> GetUserRoleList(int userId)
        {
            var result = await _userRoleService.GetList(userId);
            return Ok(result);
        }

        // GET api/<ValuesController>/5
        [HttpGet("/api/kullanicirol/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _userRoleService.GetUserRoleById(id);
            return Ok(result);
        }

        // POST api/<ValuesController>
        [HttpPost("/api/kullanicirolkaydet")]
        public async Task<IActionResult> Post([FromBody] UserRoleAddDto value)
        {
            var result = await _userRoleService.Create(value);
            return Ok(result);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("/api/kullanicirolguncelle")]
        public async Task<IActionResult> Put(int id, [FromBody] UserRoleUpdateDto value)
        {
            var result = await _userRoleService.Update(value);
            return Ok(result);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("/api/kullanicirolsil/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _userRoleService.Delete(id);
            return Ok(result);
        }
    }
}
