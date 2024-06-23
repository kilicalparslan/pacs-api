using Microsoft.AspNetCore.Mvc;
using ViewLibrary.Pdks.Dtos.Pdks.CityDtos;
using pdksApi.Services.Interface;

namespace pdksApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CityController : ControllerBase
	{
		private readonly ICityService _cityService;
		public CityController(ICityService CityService)
		{
			_cityService = CityService;
		}
		// GET: api/<ValuesController>
		[HttpGet]
		[Route("/api/iller/{countryId}")]
		public async Task<IActionResult> GetCityList(int? countryId)
		{
			var result = await _cityService.GetList(countryId);
			return Ok(result);
		}

		// GET api/<ValuesController>/5
		[HttpGet("/api/il/{id}")]
		public async Task<IActionResult> Get(int id)
		{
			var result = await _cityService.GetCityById(id);
			return Ok(result);
		}

		// POST api/<ValuesController>
		[HttpPost("/api/ilkaydet")]
		public async Task<IActionResult> Post([FromBody] CityAddDto value)
		{
			var result = await _cityService.Create(value);
			return Ok(result);
		}

		// PUT api/<ValuesController>/5
		[HttpPut("/api/ilguncelle")]
		public async Task<IActionResult> Put(int id, [FromBody] CityUpdateDto value)
		{
			var result = await _cityService.Update(value);
			return Ok(result);
		}

		// DELETE api/<ValuesController>/5
		[HttpDelete("/api/ilsil/{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var result = await _cityService.Delete(id);
			return Ok(result);
		}
	}
}
