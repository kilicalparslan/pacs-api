using Microsoft.AspNetCore.Mvc;
using ViewLibrary.Pdks.Dtos.Pdks.CompanyDtos;
//using ViewLibrary.Pdks.Dtos.Pdks.Company;
using pdksApi.Services.Interface;

namespace pdksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        public CompanyController(ICompanyService CompanyService)
        {
            _companyService = CompanyService;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        [Route("/api/firmalar")]
        public async Task<IActionResult> Get()
        {
            var result = await _companyService.GetList();
            return Ok(result);
        }

        // GET api/<ValuesController>/5
        [HttpGet("/api/firma/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _companyService.GetCompanyById(id);
            return Ok(result);
        }

        // POST api/<ValuesController>
        [HttpPost("/api/firmakaydet")]
        public async Task<IActionResult> Post([FromBody] CompanyAddDto value)
        {
            var result = await _companyService.Create(value);
            return Ok(result);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("/api/firmaguncelle")]
        public async Task<IActionResult> Put(int id, [FromBody] CompanyUpdateDto value)
        {
            var result = await _companyService.Update(value);
            return Ok(result);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("/api/firmasil/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _companyService.Delete(id);
            return Ok(result);
        }
    }
}
