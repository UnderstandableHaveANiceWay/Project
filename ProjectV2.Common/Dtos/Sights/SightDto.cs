using ProjectV2.Common.Dtos.Reviews;
using ProjectV2.Domain;

namespace ProjectV2.Common.Dtos.Sights
{
    public class SightDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int VisitPriority { get; set; }

        public int CityId { get; set; }

        public ICollection<ReviewDto>? Reviews { get; set; }
    }
}
