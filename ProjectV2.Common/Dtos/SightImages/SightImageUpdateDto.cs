namespace ProjectV2.Common.Dtos.SightImages
{
    public class SightImageUpdateDto
    {
        public string Name { get; set; }

        public byte[] File { get; set; }

        public string Type { get; set; }

        public int SightId { get; set; }
    }
}
