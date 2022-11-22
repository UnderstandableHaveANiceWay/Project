using Newtonsoft.Json;
using ProjectV2.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectV2.Common.Dtos.SightImages
{
    public class SightImageDto
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public string File { get; set; }

        public string Type { get; set; }

        public int SightId { get; set; }
    }
}
