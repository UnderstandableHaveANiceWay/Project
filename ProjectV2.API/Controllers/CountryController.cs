using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectV2.Bll.Interfaces;
using ProjectV2.Common.Dtos.Countries;

namespace ProjectV2.API.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/countries")]
    public class CountryController : AppBaseController
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCountryByIdAsync([FromRoute] int id)
        {
            var countryDto = await _countryService.GetByIdAsync(id);

            if (countryDto is null)
            {
                return BadRequest();
            }

            return Ok(countryDto);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllCountrysAsync()
        {
            var countryDtos = await _countryService.GetAllAsync();
            return Ok(countryDtos);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCountryAsync([FromBody] CountryUpdateDto countryUpdateDto)
        {
            CountryDto countryDto = await _countryService.CreateCountryAsync(countryUpdateDto);
            if (countryDto is null)
            {
                return BadRequest();
            }
            return Ok(countryDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCountryAsync([FromRoute] int id, [FromBody] CountryUpdateDto countryUpdateDto)
        {
            var countryDto = await _countryService.GetByIdAsync(id);
            if (countryDto is null)
            {
                return BadRequest();
            }
            await _countryService.UpdateCountryAsync(id, countryUpdateDto);
            return Ok();
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountryAsync([FromRoute] int id)
        {
            var countryDto = await _countryService.GetByIdAsync(id);
            if (countryDto is null)
            {
                return BadRequest();
            }
            await _countryService.DeleteCountryAsync(id);
            return Ok();
        }
    }
}
