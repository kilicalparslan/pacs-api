using Microsoft.AspNetCore.Mvc;
using ViewLibrary.Pdks.Dtos.Pdks.BranchDtos;
//using ViewLibrary.Pdks.Dtos.Pdks.Branch;
using pdksApi.Services.Interface;

namespace pdksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IBranchService _branchService;
        public BranchController(IBranchService BranchService)
        {
            _branchService = BranchService;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        [Route("/api/subeler/{companyId}")]
        public async Task<IActionResult> Get(int companyId)
        {
            var result = await _branchService.GetList(companyId);
            return Ok(result);
        }

        // GET api/<ValuesController>/5
        [HttpGet("/api/sube/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _branchService.GetBranchById(id);
            return Ok(result);
        }

        // POST api/<ValuesController>
        [HttpPost("/api/subekaydet")]
        public async Task<IActionResult> Post([FromBody] BranchAddDto value)
        {
            var result = await _branchService.Create(value);
            return Ok(result);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("/api/subeguncelle")]
        public async Task<IActionResult> Put(int id, [FromBody] BranchUpdateDto value)
        {
            var result = await _branchService.Update(value);
            return Ok(result);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("/api/subesil/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _branchService.Delete(id);
            return Ok(result);
        }
    }
}
