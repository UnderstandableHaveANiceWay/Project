using ProjectV2.Domain;
using ProjectV2.Domain.Utils.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectV2.Dal.EntityConfigurations
{
    internal class RoomTypeConfiguration : IEntityTypeConfiguration<RoomType>
    {
        public void Configure(EntityTypeBuilder<RoomType> builder)
        {
            builder.Property(roomType => roomType.Name)
                .HasMaxLength(RoomTypeConstants.NameMaxLength);

            builder.Property(roomType => roomType.Price).HasPrecision(18, 6);
        }
    }
}
