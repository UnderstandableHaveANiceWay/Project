using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectV2.Domain
{
    public class Review : BaseEntity
    {
        public string Text { get; set; }

        public double Rating { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        
        public int SightId { get; set; }
        public Sight Sight { get; set; }
    }
}
