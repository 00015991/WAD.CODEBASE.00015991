using Microsoft.AspNetCore.Mvc;
using WAD._00015991.CODEBASE.Models;
using WAD._00015991.CODEBASE.Services;

namespace WAD._00015991.CODEBASE.Controllers
// 00015991
{
    [Route("api/[controller]")]
    [ApiController]
    public class FitnessActivityController : ControllerBase
    {
        private readonly FitnessActivitySingletonService _singletonService;

        public FitnessActivityController(FitnessActivitySingletonService singletonService)
        {
            _singletonService = singletonService;
        }

        // GET: api/FitnessActivity
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FitnessActivity>>> GetActivities()
        {
            var activities = await _singletonService.GetAllActivitiesAsync();
            return Ok(activities);
        }

        // POST: api/FitnessActivity
        [HttpPost]
        public async Task<IActionResult> AddActivity(FitnessActivity activity)
        {
            await _singletonService.AddActivityAsync(activity);
            return CreatedAtAction(nameof(GetActivities), new { id = activity.Id }, activity);
        }

        // PUT: api/FitnessActivity/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateActivity(int id, FitnessActivity activity)
        {
            if (id != activity.Id)
            {
                return BadRequest("Id in the URL and body do not match.");
            }

            await _singletonService.UpdateActivityAsync(activity);
            return NoContent();
        }

        // DELETE: api/FitnessActivity/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(int id)
        {
            await _singletonService.DeleteActivityAsync(id);
            return NoContent();
        }
    }
}
