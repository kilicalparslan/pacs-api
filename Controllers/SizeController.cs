using Microsoft.AspNetCore.Mvc;
using ViewLibrary.Pdks.Dtos.Pdks.SizeDtos;

//using ViewLibrary.Pdks.Dtos.Pdks.Size;
using pdksApi.Services.Interface;

namespace pdksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SizeController : ControllerBase
    {
        private readonly ISizeService _sizeService;
        public SizeController(ISizeService sizeService)
        {
            _sizeService = sizeService;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        [Route("/api/bedenler")]
        public async Task<IActionResult> Get()
        {
            var result = await _sizeService.GetList();
            return Ok(result);
        }

        // GET api/<ValuesController>/5
        [HttpGet("/api/beden/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _sizeService.GetSizeById(id);
            return Ok(result);
        }

        // POST api/<ValuesController>
        [HttpPost("/api/bedenkaydet")]
        public async Task<IActionResult> Post([FromBody] SizeAddDto value)
        {
            var result = await _sizeService.Create(value);
            return Ok(result);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("/api/bedenguncelle")]
        public async Task<IActionResult> Put(int id, [FromBody] SizeUpdateDto value)
        {
            var result = await _sizeService.Update(value);
            return Ok(result);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("/api/bedensil/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _sizeService.Delete(id);
            return Ok(result);
        }
    }
}
