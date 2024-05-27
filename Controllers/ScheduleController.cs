using InventoryManagementService.Models;
using InventoryManagementService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulesController : ControllerBase
    {
        private readonly IScheduleService _service;

        public SchedulesController(IScheduleService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Schedule>>> GetSchedules()
        {
            return Ok(await _service.GetAllSchedules());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Schedule>> GetSchedule(string id)
        {
            var schedule = await _service.GetScheduleById(id);
            if (schedule == null)
            {
                return NotFound();
            }

            return Ok(schedule);
        }

        [HttpPost]
        public async Task<ActionResult<Schedule>> PostSchedule(Schedule schedule)
        {
            var createdSchedule = await _service.CreateSchedule(schedule);
            return CreatedAtAction(nameof(GetSchedule), new { id = createdSchedule.Id }, createdSchedule);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSchedule(string id, Schedule schedule)
        {
            if (id != schedule.Id)
            {
                return BadRequest();
            }

            await _service.UpdateSchedule(id, schedule);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSchedule(string id)
        {
            await _service.DeleteSchedule(id);
            return NoContent();
        }
    }
}
