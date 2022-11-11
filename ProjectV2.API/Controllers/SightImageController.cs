using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectV2.Bll.Interfaces;
using ProjectV2.Bll.Services;
using ProjectV2.Common.Dtos.SightImages;
using ProjectV2.Common.Dtos.Users;
using ProjectV2.Dal.Interfaces;
using ProjectV2.Domain;

namespace ProjectV2.API.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/sights/{sightId}/images")]
    public class SightImageController : AppBaseController
    {
        private ISightImageService _sightImageService;

        public SightImageController(ISightImageService sightImageService)
        {
            _sightImageService = sightImageService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllImagesOfSightAsync([FromRoute] int sightId)
        {
            var sightImageDtos = await _sightImageService.GetAllOfSightAsync(sightId);
            return Ok(sightImageDtos);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSightImageAsync(SightImageUpdateDto sightImageUpdateDto)
        {
            var sightImageDto = await _sightImageService.CreateSightImageAsync(sightImageUpdateDto);
            if (sightImageDto is null)
            {
                return BadRequest();
            }
            return Ok(sightImageDto);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSightImageAsync(SightImageUpdateDto sightImageUpdateDto)
        {
            await _sightImageService.UpdateSightImageAsync(sightImageUpdateDto);
            return Ok();
        }

        [HttpDelete("{name}")]
        public async Task<IActionResult> DeleteSightImageAsync([FromRoute] int sightId, [FromRoute] string name)
        {
            await _sightImageService.DeleteSightImageAsync(sightId, name);
            return Ok();
        }
    }
}
