namespace ProjectV2.Domain
{
    public class SightImage : BaseEntity
    {
        public string Name { get; set; }

        public byte[] File { get; set; }

        public string Type { get; set; }

        public int SightId { get; set; }
        public Sight Sight { get; set; }

    }
}
