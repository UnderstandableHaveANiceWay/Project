using ProjectV2.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectV2.Common.Dtos.Reviews
{
    public class ReviewDto
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public int UserId { get; set; }

        public int SightId { get; set; }
    }
}
