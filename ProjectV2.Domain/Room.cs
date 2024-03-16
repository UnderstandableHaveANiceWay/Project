namespace ProjectV2.Domain
{
    public class Room : BaseEntity
    {
        public string Title { get; set; } = null!;
        public int Number { get; set; }
        public bool IsBookable { get; set; }
        public int RoomTypeId { get; set; }
        public virtual RoomType RoomType { get; set; } = null!;
        public virtual ICollection<Booking> Bookings { get; set; } = null!;
        public virtual ICollection<RoomImage> Images { get; set; } = null!;
        public virtual Floor Floor { get; set; } = null!;
    }
}
