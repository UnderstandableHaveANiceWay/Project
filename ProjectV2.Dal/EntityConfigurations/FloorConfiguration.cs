using ProjectV2.Domain;
using ProjectV2.Domain.Utils.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectV2.Dal.EntityConfigurations
{
    internal class FloorConfiguration : IEntityTypeConfiguration<Floor>
    {
        public void Configure(EntityTypeBuilder<Floor> builder)
        {
            builder.Property(floor => floor.Title)
                .HasMaxLength(FloorConstants.TitleMaxLength);
        }
    }
}
