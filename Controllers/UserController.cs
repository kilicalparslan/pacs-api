using Microsoft.AspNetCore.Mvc;
using ViewLibrary.Pdks.Dtos.Pdks.UserDtos;

//using ViewLibrary.Pdks.Dtos.Pdks.User;
using pdksApi.Services.Interface;

namespace pdksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        [Route("/api/kullaniciler")]
        public async Task<IActionResult> Get()
        {
            var result = await _userService.GetList();
            return Ok(result);
        }

        // GET api/<ValuesController>/5
        [HttpGet("/api/kullanici/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _userService.GetUserById(id);
            return Ok(result);
        }

        // POST api/<ValuesController>
        [HttpPost("/api/kullanicikaydet")]
        public async Task<IActionResult> Post([FromBody] UserAddDto value)
        {
            var result = await _userService.Create(value);
            return Ok(result);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("/api/kullaniciguncelle")]
        public async Task<IActionResult> Put(int id, [FromBody] UserUpdateDto value)
        {
            var result = await _userService.Update(value);
            return Ok(result);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("/api/kullanicisil/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _userService.Delete(id);
            return Ok(result);
        }
    }
}
