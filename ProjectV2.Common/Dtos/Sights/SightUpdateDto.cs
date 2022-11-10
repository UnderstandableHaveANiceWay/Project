using ProjectV2.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectV2.Common.Dtos.Sights
{
    public class SightUpdateDto
    {
        public string Name { get; set; }

        public int VisitPriority { get; set; }

        public int CityId { get; set; }
    }
}
