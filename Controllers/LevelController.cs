using Microsoft.AspNetCore.Mvc;
using ViewLibrary.Pdks.Dtos.Pdks.LevelDtos;

//using ViewLibrary.Pdks.Dtos.Pdks.Level;
using pdksApi.Services.Interface;

namespace pdksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LevelController : ControllerBase
    {
        private readonly ILevelService _levelService;
        public LevelController(ILevelService levelService)
        {
            _levelService = levelService;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        [Route("/api/seviyeler")]
        public async Task<IActionResult> Get()
        {
            var result = await _levelService.GetList();
            return Ok(result);
        }

        // GET api/<ValuesController>/5
        [HttpGet("/api/seviye/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _levelService.GetLevelById(id);
            return Ok(result);
        }

        // POST api/<ValuesController>
        [HttpPost("/api/seviyekaydet")]
        public async Task<IActionResult> Post([FromBody] LevelAddDto value)
        {
            var result = await _levelService.Create(value);
            return Ok(result);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("/api/seviyeguncelle")]
        public async Task<IActionResult> Put(int id, [FromBody] LevelUpdateDto value)
        {
            var result = await _levelService.Update(value);
            return Ok(result);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("/api/seviyesil/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _levelService.Delete(id);
            return Ok(result);
        }
    }
}
