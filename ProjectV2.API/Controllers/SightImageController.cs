using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectV2.Bll.Interfaces;
using ProjectV2.Bll.Services;
using ProjectV2.Common.Dtos.SightImages;
using ProjectV2.Common.Dtos.Users;
using ProjectV2.Dal.Interfaces;
using ProjectV2.Domain;
using System.Diagnostics;
using System.Net;

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
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllImagesOfSightAsync([FromRoute] int sightId, [FromRoute] int id)
        {
            var file = await _sightImageService.GetByIdByteArrayAsync(id);
            return File(file.Item1, file.Item2);
        }

        [AllowAnonymous]
        [HttpGet("byte")]
        public async Task<IActionResult> GetAllImagesOfSightByteArrayAsync([FromRoute] int sightId)
        {
            var sightImageDtos = await _sightImageService.GetAllOfSightByteArrayAsync(sightId);
            return Ok(sightImageDtos);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllImagesOfSightFileUrlAsync([FromRoute] int sightId)
        {
            var sightImageDtos = await _sightImageService.GetAllOfSightFileUrlAsync(sightId);
            return Ok(sightImageDtos);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSightImageAsync()
        {
            var root = HttpContext.Request.Form;

            byte[] image; 

            using (var ms = new MemoryStream())
            {
                root.Files[0].CopyTo(ms);
                image = ms.ToArray();
            }

            var sightImageDto = await _sightImageService.CreateSightImageAsync(new SightImageUpdateDto()
            {
                Name = root["name"],
                File = image,
                Type = root["type"],
                SightId = Convert.ToInt32(root["sightId"])
            });
            if (sightImageDto is null)
            {
                return BadRequest();
            }
            return Ok(sightImageDto);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSightImageAsync([FromRoute] int sightId)
        {
            await _sightImageService.DeleteSightImageAsync(sightId);
            return Ok();
        }
    }
}
