using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectV2.Bll.Interfaces;
using ProjectV2.Bll.Services;
using ProjectV2.Common.Dtos.Sights;

namespace ProjectV2.API.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/sights")]
    public class SightController : AppBaseController
    {
        private readonly ISightService _sightService;

        public SightController(ISightService sightService)
        {
            _sightService = sightService;
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSightAsync([FromRoute] int id)
        {
            SightDto sightDto = await _sightService.GetByIdAsync(id);
            if (sightDto is null)
            {
                return BadRequest();
            }
            return Ok(sightDto);
        }

        [AllowAnonymous]
        [HttpGet("from/{city}")]
        public async Task<IActionResult> GetAllSightsFromCityAsync([FromRoute] string city)
        {
            var sightDtos = await _sightService.GetAllOfCityAsync(city);
            return Ok(sightDtos);
        }

        [AllowAnonymous]
        [HttpGet("hot/from/{cityId}")]
        public async Task<IActionResult> GetTopTenSightsAsync([FromRoute] int cityId)
        {
            var topTenSights = await _sightService.GetTopTenSightOfCityAsync(cityId);
            return Ok(topTenSights);
        }


        [HttpGet]
        public async Task<IActionResult> GetAllSightsAsync()
        {
            var sightDtos = await _sightService.GetAllAsync();
            return Ok(sightDtos);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSightAsync([FromBody] SightUpdateDto sightUpdateDto)
        {
            SightDto sightDto = await _sightService.CreateSightAsync(sightUpdateDto);
            if (sightDto is null)
            {
                return BadRequest();
            }
            return Ok(sightDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSightAsync([FromRoute] int id, [FromBody] SightUpdateDto sightUpdateDto)
        {
            var sightDto = await _sightService.GetByIdAsync(id);
            if (sightDto is null)
            {
                return BadRequest();
            }
            await _sightService.UpdateSightAsync(id, sightUpdateDto);
            return Ok(sightDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSightAsync([FromRoute] int id)
        {
            var sightDto = await _sightService.GetByIdAsync(id);
            if (sightDto is null)
            {
                return BadRequest();
            }
            await _sightService.DeleteSightAsync(id);
            return Ok();
        }
    }
}
