using System.ComponentModel.DataAnnotations;

namespace ProjectV2.Common.Dtos.Floors
{
    public class FloorUpdateDto
    {
        [Required]
        public string Name { get; set; }
    }
}
