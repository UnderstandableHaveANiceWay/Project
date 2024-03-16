namespace ProjectV2.Domain
{
    public class Floor : BaseEntity
    {
        public string Title { get; set; } = null!;
        public int Number { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<Room> Rooms { get; set; } = null!;
    }
}
