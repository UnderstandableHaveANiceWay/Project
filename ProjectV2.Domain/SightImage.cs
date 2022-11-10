namespace ProjectV2.Domain
{
    public class SightImage : BaseEntity
    {
        public string Name { get; set; }
        public string DirPath { get; set; }
        public string FullPath { get; set; }
        public string Type { get; set; }

        public int SightId { get; set; }
        public Sight Sight { get; set; }

    }
}
