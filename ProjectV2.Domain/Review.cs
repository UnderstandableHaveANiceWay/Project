namespace ProjectV2.Domain
{
    public class Review : BaseEntity
    {
        public string Text { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        
        public int RoomId { get; set; }
        public Room Room { get; set; } = null!;
    }
}
