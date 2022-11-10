using Microsoft.AspNetCore.Mvc;
using ProjectV2.Domain;
using System.ComponentModel.DataAnnotations;

namespace ProjectV2.Common.Dtos.SightImages
{
    public class SightImageUpdateDto
    {
        [FromBody]
        [Required]
        public string Name { get; set; }

        [FromBody]
        [Required]
        public string Type { get; set; }

        [FromRoute]
        public int SightId { get; set; }
    }
}
