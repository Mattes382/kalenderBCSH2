namespace kalendar.Controllers
{
    using global::kalendar.Models;
    using global::kalendar.Services;
    using Microsoft.AspNetCore.Mvc;

    namespace kalendar.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class UpominkaController : ControllerBase
        {
            private readonly UpominkyService _upominkaService;

            public UpominkaController(UpominkyService udalostService)
            {
                _upominkaService = udalostService;
            }



            // GET: api/<KalendarController>
            [HttpGet]
            public async Task<List<Upominka>> Get()
            {
                return await _upominkaService.GetAsync();
            }

            // GET api/<KalendarController>/5
            [HttpGet("{id:length(24)}")]
            public async Task<ActionResult<Upominka>> Get(string id)
            {
                var udalost = await _upominkaService.GetAsync(id);

                if (udalost is null)
                {
                    return NotFound();
                }

                return udalost;
            }

            // POST api/<KalendarController>
            [HttpPost]
            public async Task<IActionResult> Post(/*[FromForm]*/ Upominka udalost)
            {
                await _upominkaService.CreateAsync(udalost);

                return CreatedAtAction(nameof(Get), new { id = udalost.Id }, udalost);
            }

            // PUT api/<KalendarController>/5
            [HttpPut("{id:length(24)}")]
            public async Task<IActionResult> Update(string id, Upominka updatedUdalost)
            {
                var udalost = await _upominkaService.GetAsync(id);

                if (udalost is null)
                {
                    return NotFound();
                }

                updatedUdalost.Id = udalost.Id;

                await _upominkaService.UpdateAsync(id, updatedUdalost);

                return NoContent();
            }

            // DELETE api/<KalendarController>/5

            [HttpDelete("{id:length(24)}")]
            public async Task<IActionResult> Delete(string id)
            {
                var udalost = await _upominkaService.GetAsync(id);

                if (udalost is null)
                {
                    return NotFound();
                }

                await _upominkaService.RemoveAsync(id);

                return NoContent();
            }
        }
    }

}
