using ProjectV2.Domain;
using ProjectV2.Domain.Utils.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectV2.Dal.EntityConfigurations
{
    internal class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.Property(room => room.Title)
                .HasMaxLength(RoomConstants.TitleMaxLength);

            builder.HasOne(room => room.RoomType)
                .WithMany(roomType => roomType.Rooms)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(room => room.Floor)
                .WithMany(floor => floor.Rooms)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
