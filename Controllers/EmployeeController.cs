using Microsoft.AspNetCore.Mvc;
using ViewLibrary.Pdks.Dtos.Pdks.EmployeeDtos;
using pdksApi.Services.Interface;

namespace pdksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        [Route("/api/personeller")]
        public async Task<IActionResult> Get()
        {
            var result = await _employeeService.GetList();
            return Ok(result);
        }

        // GET api/<ValuesController>/5
        [HttpGet("/api/personel/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _employeeService.GetEmployeeById(id);
            return Ok(result);
        }

        // POST api/<ValuesController>
        [HttpPost("/api/personelkaydet")]
        public async Task<IActionResult> Post([FromBody] EmployeeAddDto value)
        {
            var result = await _employeeService.Create(value);
            return Ok(result);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("/api/personelguncelle")]
        public async Task<IActionResult> Put(int id, [FromBody] EmployeeUpdateDto value)
        {
            var result = await _employeeService.Update(value);
            return Ok(result);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("/api/personelsil/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _employeeService.Delete(id);
            return Ok(result);
        }
    }
}
