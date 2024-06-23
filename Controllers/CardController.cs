using Microsoft.AspNetCore.Mvc;
using ViewLibrary.Pdks.Dtos.Pdks.CardDtos;
//using ViewLibrary.Pdks.Dtos.Pdks.Card;
using pdksApi.Services.Interface;

namespace pdksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly ICardService _cardService;
        public CardController(ICardService cardService)
        {
            _cardService = cardService;
        }
        // GET: api/<ValuesController>
        [HttpPost]
        [Route("/api/kartlar")]
        public async Task<IActionResult> Get(CardActiveDeleteDto value)
        {
            var result = await _cardService.GetList(value);
            return Ok(result);
        }

        // GET api/<ValuesController>/5
        [HttpGet("/api/kart/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _cardService.GetCardById(id);
            return Ok(result);
        }

        // POST api/<ValuesController>
        [HttpPost("/api/kartkaydet")]
        public async Task<IActionResult> Post([FromBody] CardAddDto value)
        {
            var result = await _cardService.Create(value);
            return Ok(result);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("/api/kartguncelle")]
        public async Task<IActionResult> Put([FromBody] CardUpdateDto value)
        {
            var result = await _cardService.Update(value);
            return Ok(result);
        }

        // DELETE api/<ValuesController>/5
        [HttpPut("/api/kartsil/{id}")]
        public async Task<IActionResult> Delete(int id, [FromBody] bool? cancelled)
        {
            var result = await _cardService.Delete(id,cancelled);
            return Ok(result);
        }
    }
}
