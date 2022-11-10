using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectV2.Domain
{
    public class Sight : BaseEntity
    {
        public string Name { get; set; }
        public int VisitPriority { get; set; }

        public int CityId { get; set; }
        public City City { get; set; }

        public ICollection<Review>? Reviews { get; set; }
        public ICollection<SightImage>? SightImages { get; set; }
    }
}
