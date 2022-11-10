using System.ComponentModel.DataAnnotations;

namespace ProjectV2.Common.Dtos.Countries
{
    public class CountryUpdateDto
    {
        [Required]
        public string Name { get; set; }
    }
}
