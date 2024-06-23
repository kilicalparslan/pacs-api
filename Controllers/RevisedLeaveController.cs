using Microsoft.AspNetCore.Mvc;
using ViewLibrary.Pdks.Dtos.Pdks.RevisedLeaveDtos;

//using ViewLibrary.Pdks.Dtos.Pdks.RevisedLeave;
using pdksApi.Services.Interface;

namespace pdksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RevisedLeaveController : ControllerBase
    {
        private readonly IRevisedLeaveService _revisedLeaveService;
        public RevisedLeaveController(IRevisedLeaveService revisedLeaveService)
        {
            _revisedLeaveService = revisedLeaveService;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        [Route("/api/revizeizinler")]
        public async Task<IActionResult> Get()
        {
            var result = await _revisedLeaveService.GetList();
            return Ok(result);
        }

        // GET api/<ValuesController>/5
        [HttpGet("/api/revizeizin/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _revisedLeaveService.GetRevisedLeaveById(id);
            return Ok(result);
        }

        // POST api/<ValuesController>
        [HttpPost("/api/revizeizinkaydet")]
        public async Task<IActionResult> Post([FromBody] RevisedLeaveAddDto value)
        {
            var result = await _revisedLeaveService.Create(value);
            return Ok(result);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("/api/revizeizinguncelle")]
        public async Task<IActionResult> Put(int id, [FromBody] RevisedLeaveUpdateDto value)
        {
            var result = await _revisedLeaveService.Update(value);
            return Ok(result);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("/api/revizeizinsil/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _revisedLeaveService.Delete(id);
            return Ok(result);
        }
    }
}
