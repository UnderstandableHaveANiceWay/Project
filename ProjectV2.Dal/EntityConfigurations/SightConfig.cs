using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectV2.Domain;

namespace ProjectV2.Dal.EntityConfigurations
{
    internal class SightConfig : IEntityTypeConfiguration<Sight>
    {
        public void Configure(EntityTypeBuilder<Sight> builder)
        {
            builder
                .HasIndex(s => new { s.Name, s.CityId }, "Sight_Name-CityId_Unique")
                .IsUnique();
            builder
                .HasOne(s => s.City)
                .WithMany(c => c.Sights)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
