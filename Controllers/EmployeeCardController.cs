using Microsoft.AspNetCore.Mvc;
using ViewLibrary.Pdks.Dtos.Pdks.EmployeeCardDtos;
using pdksApi.Services.Interface;

namespace pdksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeCardController : ControllerBase
    {
        private readonly IEmployeeCardService _employeeCardService;
        public EmployeeCardController(IEmployeeCardService EmployeeCardService)
        {
            _employeeCardService = EmployeeCardService;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        [Route("/api/personelkartlar")]
        public async Task<IActionResult> Get()
        {
            var result = await _employeeCardService.GetList();
            return Ok(result);
        }

        // GET api/<ValuesController>/5
        [HttpGet("/api/personelkart/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _employeeCardService.GetEmployeeCardById(id);
            return Ok(result);
        }

        // POST api/<ValuesController>
        [HttpPost("/api/personelkartkaydet")]
        public async Task<IActionResult> Post([FromBody] EmployeeCardAddDto value)
        {
            var result = await _employeeCardService.Create(value);
            return Ok(result);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("/api/personelkartguncelle")]
        public async Task<IActionResult> Put(int id, [FromBody] EmployeeCardUpdateDto value)
        {
            var result = await _employeeCardService.Update(value);
            return Ok(result);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("/api/personelkartsil/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _employeeCardService.Delete(id);
            return Ok(result);
        }
    }
}
