using ProjectV2.Common.Dtos.Reviews;

namespace ProjectV2.Common.Dtos.Rooms
{
    public class RoomDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int VisitPriority { get; set; }

        public int CityId { get; set; }

        public ICollection<ReviewDto>? Reviews { get; set; }
    }
}
