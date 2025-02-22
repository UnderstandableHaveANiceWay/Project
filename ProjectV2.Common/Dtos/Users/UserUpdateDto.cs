﻿using System.ComponentModel.DataAnnotations;

namespace ProjectV2.Common.Dtos.Users
{
    public class UserUpdateDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
