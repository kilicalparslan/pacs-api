using Microsoft.AspNetCore.Mvc;
using ViewLibrary.Pdks.Dtos.Pdks.LanguageDtos;

//using ViewLibrary.Pdks.Dtos.Pdks.Language;
using pdksApi.Services.Interface;

namespace pdksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly ILanguageService _languageService;
        public LanguageController(ILanguageService LanguageService)
        {
            _languageService = LanguageService;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        [Route("/api/diller")]
        public async Task<IActionResult> Get()
        {
            var result = await _languageService.GetList();
            return Ok(result);
        }

        // GET api/<ValuesController>/5
        [HttpGet("/api/dil/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _languageService.GetLanguageById(id);
            return Ok(result);
        }

        // POST api/<ValuesController>
        [HttpPost("/api/dilkaydet")]
        public async Task<IActionResult> Post([FromBody] LanguageAddDto value)
        {
            var result = await _languageService.Create(value);
            return Ok(result);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("/api/dilguncelle")]
        public async Task<IActionResult> Put(int id, [FromBody] LanguageUpdateDto value)
        {
            var result = await _languageService.Update(value);
            return Ok(result);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("/api/dilsil/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _languageService.Delete(id);
            return Ok(result);
        }
    }
}
