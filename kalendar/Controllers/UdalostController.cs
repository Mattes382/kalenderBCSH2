using kalendar.Models;
using kalendar.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace kalendar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UdalostController : ControllerBase
    {

        private readonly UdalostiService _udalostService;

        public UdalostController(UdalostiService udalostService)
        {
            _udalostService = udalostService;
        }



        // GET: api/<KalendarController>
        [HttpGet]
        public async Task<List<Udalost>> Get()
        {
            return await _udalostService.GetAsync();
        }

        // GET api/<KalendarController>/5
        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Udalost>> Get(string id)
        {
            var udalost = await _udalostService.GetAsync(id);

            if (udalost is null)
            {
                return NotFound();
            }

            return udalost;
        }

        // POST api/<KalendarController>
        [HttpPost]
        public async Task<IActionResult> Post(/*[FromForm]*/ Udalost udalost)
        {
            await _udalostService.CreateAsync(udalost);

            return CreatedAtAction(nameof(Get), new { id = udalost.Id }, udalost);
        }

        // PUT api/<KalendarController>/5
        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Udalost updatedUdalost)
        {
            var udalost = await _udalostService.GetAsync(id);

            if (udalost is null)
            {
                return NotFound();
            }

            updatedUdalost.Id = udalost.Id;

            await _udalostService.UpdateAsync(id, updatedUdalost);

            return NoContent();
        }

        // DELETE api/<KalendarController>/5

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var udalost = await _udalostService.GetAsync(id);

            if (udalost is null)
            {
                return NotFound();
            }

            await _udalostService.RemoveAsync(id);

            return NoContent();
        }
    }
}
