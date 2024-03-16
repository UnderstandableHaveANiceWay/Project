namespace ProjectV2.Domain
{
    public class RoomImage : BaseEntity
    {
        public string Name { get; set; }
        public string DirPath { get; set; }
        public string FullPath { get; set; }
        public string Type { get; set; }

        public int RoomId { get; set; }
        public Room Room { get; set; }

    }
}
