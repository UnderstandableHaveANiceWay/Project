using ProjectV2.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectV2.Common.Dtos.Users
{
    public class UserDto
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }
    }
}