namespace ProjectV2.Common.Dtos.RoomImages
{
    public class RoomImageDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DirPath { get; set; }
        public string FullPath { get; set; }
        public string Type { get; set; }

        public int RoomId { get; set; }
    }
}
