using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectV2.Common.Dtos.Roles
{
    public class RoleUpdateDto
    {
        [Required]
        [MaxLength(int.MaxValue)]
        public string Name { get; set; }
    }
}
