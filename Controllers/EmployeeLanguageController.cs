using Microsoft.AspNetCore.Mvc;
using ViewLibrary.Pdks.Dtos.Pdks.EmployeeLanguageDtos;

//using ViewLibrary.Pdks.Dtos.Pdks.EmployeeLanguage;
using pdksApi.Services.Interface;

namespace pdksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeLanguageController : ControllerBase
    {
        private readonly IEmployeeLanguageService _employeeLanguageService;
        public EmployeeLanguageController(IEmployeeLanguageService EmployeeLanguageService)
        {
            _employeeLanguageService = EmployeeLanguageService;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        [Route("/api/personeldiller")]
        public async Task<IActionResult> Get()
        {
            var result = await _employeeLanguageService.GetList();
            return Ok(result);
        }

        // GET api/<ValuesController>/5
        [HttpGet("/api/personeldil/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _employeeLanguageService.GetEmployeeLanguageById(id);
            return Ok(result);
        }

        // POST api/<ValuesController>
        [HttpPost("/api/personeldilkaydet")]
        public async Task<IActionResult> Post([FromBody] EmployeeLanguageAddDto value)
        {
            var result = await _employeeLanguageService.Create(value);
            return Ok(result);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("/api/personeldilguncelle")]
        public async Task<IActionResult> Put(int id, [FromBody] EmployeeLanguageUpdateDto value)
        {
            var result = await _employeeLanguageService.Update(value);
            return Ok(result);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("/api/personeldilsil/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _employeeLanguageService.Delete(id);
            return Ok(result);
        }
    }
}
