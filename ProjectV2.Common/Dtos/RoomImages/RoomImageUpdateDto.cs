using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ProjectV2.Common.Dtos.SightImages
{
    public class RoomImageUpdateDto
    {
        [FromBody]
        [Required]
        public string Name { get; set; }

        [FromBody]
        [Required]
        public string Type { get; set; }

        [FromRoute]
        public int RoomId { get; set; }
    }
}
