using BlazorShopHRM.Api.Repositories;
using BlazorShopHRM.Api.Repositories.Interfaces;
using BlazorShopHRM.Shared.Domain;
using Microsoft.AspNetCore.Mvc;


namespace BlazorShopHRM.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class LeaveController : ControllerBase
    {
        private readonly ILeaveRepository _leaveRepository;


        public LeaveController(ILeaveRepository leaveRepository)
        {
            _leaveRepository = leaveRepository;
        }


        [HttpGet]
        public IActionResult GetAllLeaves()
        {
            return Ok(_leaveRepository.GetAllLeaves());
        }

        [HttpGet("{id}")]
        public IActionResult GetLeaveById(int id)
        {
            var leave = _leaveRepository.GetLeaveById(id);
            if (leave == null)
            {
                return NotFound();
            }
            return Ok(leave);
        }

        [HttpGet("employee/{employeeId}")]
        public IActionResult GetLeavesByEmployeeId(int employeeId)
        {
            return Ok(_leaveRepository.GetLeavesByEmployeeId(employeeId));
        }

        //[HttpPost]
        //public IActionResult AddLeave(Leave leave)
        //{
        //    if (leave == null)
        //    {
        //        return BadRequest();
        //    }

        //    var createdLeave = _leaveRepository.AddLeave(leave);
        //    return CreatedAtAction(nameof(GetLeaveById), new { id = createdLeave.LeaveId }, createdLeave);
        //}

        [HttpPost]
        public IActionResult CreateLeave([FromBody] Leave leave)
        {
            if (leave == null)
            {
                return BadRequest("Leave is null");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var createdLeave = _leaveRepository.AddLeave(leave);
                return Created("leave", createdLeave);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateLeave(Leave leave)
        {
            if (leave == null)
            {
                return BadRequest();
            }

            var updatedLeave = _leaveRepository.UpdateLeave(leave);
            if (updatedLeave == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteLeave(int id)
        {
            _leaveRepository.DeleteLeave(id);
            return NoContent();
        }
    }
}
