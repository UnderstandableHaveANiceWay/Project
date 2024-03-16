using System.ComponentModel.DataAnnotations;

namespace ProjectV2.Common.Dtos.Reviews
{
    public class ReviewUpdateDto
    {
        [Required]
        public string Text { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int RoomId { get; set; }
    }
}
