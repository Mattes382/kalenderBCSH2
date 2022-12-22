using kalendar.Models;
using kalendar.Services;
using Microsoft.AspNetCore.Mvc;

namespace kalendar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoznamkaController : ControllerBase
    {
        private readonly PoznamkyService _poznamkaService;

        public PoznamkaController(PoznamkyService udalostService)
        {
            _poznamkaService = udalostService;
        }



        // GET: api/<KalendarController>
        [HttpGet]
        public async Task<List<Poznamka>> Get()
        {
            return await _poznamkaService.GetAsync();
        }

        // GET api/<KalendarController>/5
        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Poznamka>> Get(string id)
        {
            var udalost = await _poznamkaService.GetAsync(id);

            if (udalost is null)
            {
                return NotFound();
            }

            return udalost;
        }

        // POST api/<KalendarController>
        [HttpPost]
        public async Task<IActionResult> Post(/*[FromForm]*/ Poznamka udalost)
        {
            await _poznamkaService.CreateAsync(udalost);

            return CreatedAtAction(nameof(Get), new { id = udalost.Id }, udalost);
        }

        // PUT api/<KalendarController>/5
        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Poznamka updatedUdalost)
        {
            var udalost = await _poznamkaService.GetAsync(id);

            if (udalost is null)
            {
                return NotFound();
            }

            updatedUdalost.Id = udalost.Id;

            await _poznamkaService.UpdateAsync(id, updatedUdalost);

            return NoContent();
        }

        // DELETE api/<KalendarController>/5

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var udalost = await _poznamkaService.GetAsync(id);

            if (udalost is null)
            {
                return NotFound();
            }

            await _poznamkaService.RemoveAsync(id);

            return NoContent();
        }
    }
}
