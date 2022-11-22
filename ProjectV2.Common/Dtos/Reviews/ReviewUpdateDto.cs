using ProjectV2.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectV2.Common.Dtos.Reviews
{
    public class ReviewUpdateDto
    {
        [Required]
        public string Text { get; set; }

        [Required]
        public double Rating { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public int SightId { get; set; }
    }
}
