using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewLibrary.Pdks.Dtos.Pdks.CountryDtos;
using pdksApi.Services.Interface;

namespace pdksApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CountryController : ControllerBase
	{
		private readonly ICountryService _countryService;
		public CountryController(ICountryService CountryService)
		{
			_countryService = CountryService;
		}
		// GET: api/<ValuesController>
		[HttpGet]
		[Route("/api/ulkeler")]
		public async Task<IActionResult> Get()
		{
			var result = await _countryService.GetList();
			return Ok(result);
		}

		// GET api/<ValuesController>/5
		[HttpGet("/api/ulke/{id}")]
		public async Task<IActionResult> Get(int id)
		{
			var result = await _countryService.GetCountryById(id);
			return Ok(result);
		}

		// POST api/<ValuesController>
		[HttpPost("/api/ulkekaydet")]
		public async Task<IActionResult> Post([FromBody] CountryAddDto value)
		{
			var result = await _countryService.Create(value);
			return Ok(result);
		}

		// PUT api/<ValuesController>/5
		[HttpPut("/api/ulkeguncelle")]
		public async Task<IActionResult> Put(int id, [FromBody] CountryUpdateDto value)
		{
			var result = await _countryService.Update(value);
			return Ok(result);
		}

		// DELETE api/<ValuesController>/5
		[HttpDelete("/api/ulkesil/{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var result = await _countryService.Delete(id);
			return Ok(result);
		}
	}
}
