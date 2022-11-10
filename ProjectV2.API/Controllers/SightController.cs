using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectV2.Bll.Interfaces;
using ProjectV2.Bll.Services;
using ProjectV2.Common.Dtos.Sights;

namespace ProjectV2.API.Controllers
{
    [Route("api/sights")]
    public class SightController : AppBaseController
    {
        private readonly ISightService _sightService;

        public SightController(ISightService sightService)
        {
            _sightService = sightService;
        }

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

        [HttpGet("from/{city}")]
        public async Task<IActionResult> GetAllSightsFromCityAsync([FromRoute] string city)
        {
            var sightDtos = await _sightService.GetAllOfCityAsync(city);
            return Ok(sightDtos);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSightsAsync()
        {
            var sightDtos = await _sightService.GetAllAsync();
            return Ok(sightDtos);
        }

        [Authorize(Roles = "admin")]
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

        [Authorize(Roles = "admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSightAsync([FromRoute] int id, [FromBody] SightUpdateDto sightUpdateDto)
        {
            var sightDto = await _sightService.GetByIdAsync(id);
            if (sightDto is null)
            {
                return BadRequest();
            }
            await _sightService.UpdateSightAsync(id, sightUpdateDto);
            return Ok();
        }

        [Authorize(Roles = "admin")]
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
