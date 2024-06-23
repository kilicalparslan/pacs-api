using Microsoft.AspNetCore.Mvc;
using ViewLibrary.Pdks.Dtos.Pdks.EmployeeTitleDtos;

//using ViewLibrary.Pdks.Dtos.Pdks.EmployeeTitle;
using pdksApi.Services.Interface;

namespace pdksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeTitleController : ControllerBase
    {
        private readonly IEmployeeTitleService _employeeTitleService;
        public EmployeeTitleController(IEmployeeTitleService employeeTitleService)
        {
            _employeeTitleService = employeeTitleService;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        [Route("/api/personelunvanlar")]
        public async Task<IActionResult> Get()
        {
            var result = await _employeeTitleService.GetList();
            return Ok(result);
        }

        // GET api/<ValuesController>/5
        [HttpGet("/api/personelunvan/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _employeeTitleService.GetEmployeeTitleById(id);
            return Ok(result);
        }

        // POST api/<ValuesController>
        [HttpPost("/api/personelunvankaydet")]
        public async Task<IActionResult> Post([FromBody] EmployeeTitleAddDto value)
        {
            var result = await _employeeTitleService.Create(value);
            return Ok(result);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("/api/personelunvanguncelle")]
        public async Task<IActionResult> Put(int id, [FromBody] EmployeeTitleUpdateDto value)
        {
            var result = await _employeeTitleService.Update(value);
            return Ok(result);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("/api/personelunvansil/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _employeeTitleService.Delete(id);
            return Ok(result);
        }
    }
}
