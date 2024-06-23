using Microsoft.AspNetCore.Mvc;
using ViewLibrary.Pdks.Dtos.Pdks.EmployeeLeaveDtos;

//using ViewLibrary.Pdks.Dtos.Pdks.EmployeeLeave;
using pdksApi.Services.Interface;

namespace pdksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeLeaveController : ControllerBase
    {
        private readonly IEmployeeLeaveService _employeeLeaveService;
        public EmployeeLeaveController(IEmployeeLeaveService employeeLeaveService)
        {
            _employeeLeaveService = employeeLeaveService;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        [Route("/api/personelizinler")]
        public async Task<IActionResult> Get()
        {
            var result = await _employeeLeaveService.GetList();
            return Ok(result);
        }

        // GET api/<ValuesController>/5
        [HttpGet("/api/personelizin/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _employeeLeaveService.GetEmployeeLeaveById(id);
            return Ok(result);
        }

        // POST api/<ValuesController>
        [HttpPost("/api/personelizinkaydet")]
        public async Task<IActionResult> Post([FromBody] EmployeeLeaveAddDto value)
        {
            var result = await _employeeLeaveService.Create(value);
            return Ok(result);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("/api/personelizinguncelle")]
        public async Task<IActionResult> Put(int id, [FromBody] EmployeeLeaveUpdateDto value)
        {
            var result = await _employeeLeaveService.Update(value);
            return Ok(result);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("/api/personelizinsil/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _employeeLeaveService.Delete(id);
            return Ok(result);
        }
    }
}
