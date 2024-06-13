using BlazorShopHRM.Api.Repositories;
using BlazorShopHRM.Api.Repositories.Interfaces;
using BlazorShopHRM.Shared.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace BlazorShopHRM.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class PayrollController : ControllerBase
    {
        private readonly IPayrollRepository _payrollRepository;


        public PayrollController(IPayrollRepository payrollRepository)
        {
            _payrollRepository = payrollRepository;
        }


        [HttpGet]
        public IActionResult GetAllPayrolls()
        {
            return Ok(_payrollRepository.GetAllPayrolls());
        }

        [HttpGet("{id}")]
        public IActionResult GetPayrollById(int id)
        {
            var payroll = _payrollRepository.GetPayrollById(id);
            if (payroll == null)
            {
                return NotFound();
            }
            return Ok(payroll);
        }

        [HttpGet("employee/{employeeId}")]
        public IActionResult GetPayrollsByEmployeeId(int employeeId)
        {
            return Ok(_payrollRepository.GetPayrollsByEmployeeId(employeeId));
        }

        [HttpPost]
        public IActionResult CreatePayroll([FromBody] Payroll payroll)
        {
            if (payroll == null)
            {
                return BadRequest("Payroll is null");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var createdPayroll = _payrollRepository.AddPayroll(payroll);
                return Created("payroll", createdPayroll);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePayroll(int id, [FromBody] Payroll payroll)
        {
            if (payroll == null || payroll.PayrollId != id)
                return BadRequest("Invalid payroll data");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var payrollToUpdate = _payrollRepository.GetPayrollById(id);

            if (payrollToUpdate == null)
                return NotFound("Payroll not found");

            try
            {
                _payrollRepository.UpdatePayroll(payroll);
            }
            catch (Exception ex)
            {
                // Log the error
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }

            return NoContent(); // success
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePayroll(int id)
        {
            if (id == 0)
                return BadRequest();

            var payrollToDelete = _payrollRepository.GetPayrollById(id);
            if (payrollToDelete == null)
                return NotFound();

            _payrollRepository.DeletePayroll(id);

            return NoContent();//success
        }
    }
}
