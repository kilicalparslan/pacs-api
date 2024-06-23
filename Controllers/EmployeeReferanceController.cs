using Microsoft.AspNetCore.Mvc;
using ViewLibrary.Pdks.Dtos.Pdks.EmployeeReferanceDtos;

//using ViewLibrary.Pdks.Dtos.Pdks.EmployeeReferance;
using pdksApi.Services.Interface;

namespace pdksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeReferanceController : ControllerBase
    {
        private readonly IEmployeeReferanceService _employeeReferanceService;
        public EmployeeReferanceController(IEmployeeReferanceService EmployeeReferanceService)
        {
            _employeeReferanceService = EmployeeReferanceService;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        [Route("/api/personelreferanslar")]
        public async Task<IActionResult> Get()
        {
            var result = await _employeeReferanceService.GetList();
            return Ok(result);
        }

        // GET api/<ValuesController>/5
        [HttpGet("/api/personelreferans/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _employeeReferanceService.GetEmployeeReferanceById(id);
            return Ok(result);
        }

        // POST api/<ValuesController>
        [HttpPost("/api/personelreferanskaydet")]
        public async Task<IActionResult> Post([FromBody] EmployeeReferanceAddDto value)
        {
            var result = await _employeeReferanceService.Create(value);
            return Ok(result);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("/api/personelreferansguncelle")]
        public async Task<IActionResult> Put(int id, [FromBody] EmployeeReferanceUpdateDto value)
        {
            var result = await _employeeReferanceService.Update(value);
            return Ok(result);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("/api/personelreferanssil/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _employeeReferanceService.Delete(id);
            return Ok(result);
        }
    }
}
