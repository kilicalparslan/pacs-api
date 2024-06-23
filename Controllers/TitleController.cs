using Microsoft.AspNetCore.Mvc;
using ViewLibrary.Pdks.Dtos.Pdks.TitleDtos;

//using ViewLibrary.Pdks.Dtos.Pdks.Title;
using pdksApi.Services.Interface;

namespace pdksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TitleController : ControllerBase
    {
        private readonly ITitleService _titleService;
        public TitleController(ITitleService titleService)
        {
            _titleService = titleService;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        [Route("/api/unvanlar")]
        public async Task<IActionResult> Get()
        {
            var result = await _titleService.GetList();
            return Ok(result);
        }

        // GET api/<ValuesController>/5
        [HttpGet("/api/unvan/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _titleService.GetTitleById(id);
            return Ok(result);
        }

        // POST api/<ValuesController>
        [HttpPost("/api/unvankaydet")]
        public async Task<IActionResult> Post([FromBody] TitleAddDto value)
        {
            var result = await _titleService.Create(value);
            return Ok(result);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("/api/unvanguncelle")]
        public async Task<IActionResult> Put(int id, [FromBody] TitleUpdateDto value)
        {
            var result = await _titleService.Update(value);
            return Ok(result);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("/api/unvansil/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _titleService.Delete(id);
            return Ok(result);
        }
    }
}
