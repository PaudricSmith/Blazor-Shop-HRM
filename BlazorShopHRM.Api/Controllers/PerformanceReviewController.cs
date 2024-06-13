using BlazorShopHRM.Api.Repositories.Interfaces;
using BlazorShopHRM.Shared.Domain;
using Microsoft.AspNetCore.Mvc;


namespace BlazorShopHRM.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class PerformanceReviewController : ControllerBase
    {
        private readonly IPerformanceReviewRepository _performanceReviewRepository;


        public PerformanceReviewController(IPerformanceReviewRepository performanceReviewRepository)
        {
            _performanceReviewRepository = performanceReviewRepository;
        }


        [HttpGet]
        public IActionResult GetAllPerformanceReviews()
        {
            return Ok(_performanceReviewRepository.GetAllPerformanceReviews());
        }

        [HttpGet("{id}")]
        public IActionResult GetPerformanceReviewById(int id)
        {
            var review = _performanceReviewRepository.GetPerformanceReviewById(id);
            if (review == null)
            {
                return NotFound();
            }
            return Ok(review);
        }

        [HttpGet("employee/{employeeId}")]
        public IActionResult GetPerformanceReviewsByEmployeeId(int employeeId)
        {
            return Ok(_performanceReviewRepository.GetPerformanceReviewsByEmployeeId(employeeId));
        }

        [HttpPost]
        public IActionResult AddPerformanceReview(PerformanceReview review)
        {
            if (review == null)
            {
                return BadRequest();
            }

            var createdReview = _performanceReviewRepository.AddPerformanceReview(review);
            return CreatedAtAction(nameof(GetPerformanceReviewById), new { id = createdReview.PerformanceReviewId }, createdReview);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePerformanceReview(PerformanceReview review)
        {
            if (review == null)
            {
                return BadRequest();
            }

            var updatedReview = _performanceReviewRepository.UpdatePerformanceReview(review);
            if (updatedReview == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePerformanceReview(int id)
        {
            _performanceReviewRepository.DeletePerformanceReview(id);
            return NoContent();
        }
    }
}
