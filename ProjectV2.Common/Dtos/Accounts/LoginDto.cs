using System.ComponentModel.DataAnnotations;

namespace ProjectV2.Common.Dtos.Accounts
{
    public class LoginDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
