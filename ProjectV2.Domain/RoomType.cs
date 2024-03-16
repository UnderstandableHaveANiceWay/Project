namespace ProjectV2.Domain
{
    public class RoomType : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price {  get; set; }
        public virtual ICollection<Room> Rooms { get; set; } = null!;
    }
}
