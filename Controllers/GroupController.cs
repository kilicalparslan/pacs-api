using Microsoft.AspNetCore.Mvc;
using ViewLibrary.Pdks.Dtos.Pdks.GroupDtos;

//using ViewLibrary.Pdks.Dtos.Pdks.Group;
using pdksApi.Services.Interface;

namespace pdksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _groupService;
        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        [Route("/api/gruplar")]
        public async Task<IActionResult> Get()
        {
            var result = await _groupService.GetList();
            return Ok(result);
        }

        // GET api/<ValuesController>/5
        [HttpGet("/api/grup/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _groupService.GetGroupById(id);
            return Ok(result);
        }

        // POST api/<ValuesController>
        [HttpPost("/api/grupkaydet")]
        public async Task<IActionResult> Post([FromBody] GroupAddDto value)
        {
            var result = await _groupService.Create(value);
            return Ok(result);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("/api/grupguncelle")]
        public async Task<IActionResult> Put(int id, [FromBody] GroupUpdateDto value)
        {
            var result = await _groupService.Update(value);
            return Ok(result);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("/api/grupsil/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _groupService.Delete(id);
            return Ok(result);
        }
    }
}
