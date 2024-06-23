using Microsoft.AspNetCore.Mvc;
using ViewLibrary.Pdks.Dtos.Pdks.AccessPointDtos;
using pdksApi.Services.Interface;

namespace pdksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessPointController : ControllerBase
    {
        private readonly IAccessPointService _accessPointService;
        public AccessPointController(IAccessPointService accessPointService)
        {
            _accessPointService = accessPointService;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        [Route("/api/kontrolnoktalari")]
        public async Task<IActionResult> Get()
        {
            var result = await _accessPointService.GetList();
            return Ok(result);
        }

        // GET api/<ValuesController>/5
        [HttpGet("/api/kontrolnokta/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _accessPointService.GetAccessPointById(id);
            return Ok(result);
        }

        // POST api/<ValuesController>
        [HttpPost("/api/kontrolnoktakaydet")]
        public async Task<IActionResult> Post([FromBody] AccessPointAddDto value)
        {
            var result = await _accessPointService.Create(value);
            return Ok(result);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("/api/kontrolnoktaguncelle")]
        public async Task<IActionResult> Put(int id, [FromBody] AccessPointUpdateDto value)
        {
            var result = await _accessPointService.Update(value);
            return Ok(result);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("/api/kontrolnoktasil/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _accessPointService.Delete(id);
            return Ok(result);
        }
    }
}
