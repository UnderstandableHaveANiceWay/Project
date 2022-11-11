using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectV2.Bll.Interfaces;
using ProjectV2.Common.Dtos.Cities;

namespace ProjectV2.API.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/cities")]
    public class CityController : AppBaseController
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCityAsync([FromRoute] int id)
        {
            CityDto cityDto = await _cityService.GetByIdAsync(id);
            if (cityDto is null)
            {
                return BadRequest();
            }
            return Ok(cityDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCitiesAsync()
        {
            var cityDtos = await _cityService.GetAllAsync();
            return Ok(cityDtos);
        }

        [AllowAnonymous]
        [HttpGet("from/{country}")]
        public async Task<IActionResult> GetAllCitiesOfCountryAsync([FromRoute] string country)
        {
            var cityDtos = await _cityService.GetAllOfCountryAsync(country);
            return Ok(cityDtos);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCityAsync([FromBody] CityUpdateDto cityUpdateDto)
        {
            CityDto cityDto = await _cityService.CreateCityAsync(cityUpdateDto);
            if (cityDto is null)
            {
                return BadRequest();
            }
            return Ok(cityDto);
        }

        [Authorize(Roles = "admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCityAsync([FromRoute] int id, [FromBody] CityUpdateDto cityUpdateDto)
        {
            var cityDto = await _cityService.GetByIdAsync(id);
            if (cityDto is null)
            {
                return BadRequest();
            }
            await _cityService.UpdateCityAsync(id, cityUpdateDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCityAsync([FromRoute] int id)
        {
            var cityDto = await _cityService.GetByIdAsync(id);
            if (cityDto is null)
            {
                return BadRequest();
            }
            await _cityService.DeleteCityAsync(id);
            return Ok();
        }
    }
}
