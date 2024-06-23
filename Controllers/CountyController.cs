using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewLibrary.Pdks.Dtos.Pdks.CountyDtos;
using pdksApi.Services.Interface;

namespace pdksApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CountyController : ControllerBase
	{
		private readonly ICountyService _countyService;
		public CountyController(ICountyService CountyService)
		{
			_countyService = CountyService;
		}
		// GET: api/<ValuesController>
		[HttpGet]
		[Route("/api/ilceler/{cityId}")]
		public async Task<IActionResult> Get(int cityId)
		{
			var result = await _countyService.GetList(cityId);
			return Ok(result);
		}
		

		// POST api/<ValuesController>
		[HttpPost("/api/ilcekaydet")]
		public async Task<IActionResult> Post([FromBody] CountyAddDto value)
		{
			var result = await _countyService.Create(value);
			return Ok(result);
		}

		// PUT api/<ValuesController>/5
		[HttpPut("/api/ilceguncelle")]
		public async Task<IActionResult> Put(int id, [FromBody] CountyUpdateDto value)
		{
			var result = await _countyService.Update(value);
			return Ok(result);
		}

		// DELETE api/<ValuesController>/5
		[HttpDelete("/api/ilcesil/{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var result = await _countyService.Delete(id);
			return Ok(result);
		}
	}
}
