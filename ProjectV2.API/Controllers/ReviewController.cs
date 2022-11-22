using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectV2.Bll.Interfaces;
using ProjectV2.Common.Dtos.Reviews;

namespace ProjectV2.API.Controllers
{
    [Authorize(Roles = "admin, user")]
    [Route("api/reviews")]
    public class ReviewController : AppBaseController
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReviewAsync([FromRoute] int id)
        {
            ReviewDto reviewDto = await _reviewService.GetByIdAsync(id);
            if (reviewDto is null)
            {
                return BadRequest();
            }
            return Ok(reviewDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReviewsAsync()
        {
            var reviewDtos = await _reviewService.GetAllAsync();
            return Ok(reviewDtos);
        }

        [AllowAnonymous]
        [HttpGet("sight/{id}")]
        public async Task<IActionResult> GetAllReviewsOfSight([FromRoute] int id)
        {
            var reviewDtos = await _reviewService.GetAllOfSightAsync(id);
            return Ok(reviewDtos);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReviewAsync([FromBody] ReviewUpdateDto reviewUpdateDto)
        {
            ReviewDto reviewDto = await _reviewService.CreateReviewAsync(reviewUpdateDto);
            if (reviewDto is null)
            {
                return BadRequest();
            }
            return Ok(reviewDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReviewAsync([FromRoute] int id, [FromBody] ReviewUpdateDto reviewUpdateDto)
        {
            var reviewDto = await _reviewService.GetByIdAsync(id);
            if (reviewDto is null)
            {
                return BadRequest();
            }
            await _reviewService.UpdateReviewAsync(id, reviewUpdateDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReviewAsync([FromRoute] int id)
        {
            var reviewDto = await _reviewService.GetByIdAsync(id);
            if (reviewDto is null)
            {
                return BadRequest();
            }
            await _reviewService.DeleteReviewAsync(id);
            return Ok();
        }
    }
}
