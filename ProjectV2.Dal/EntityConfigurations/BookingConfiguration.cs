using ProjectV2.Domain;
using ProjectV2.Domain.Utils.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectV2.Dal.EntityConfigurations
{
    internal class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.Property(booking => booking.Status)
                .HasConversion<string>();

            builder.HasOne(booking => booking.User)
                .WithMany(user => user.Bookings)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(booking => booking.Notes)
                .HasMaxLength(BookingConstants.MaxNotesLength);

            builder.Property(booking => booking.BookedFor)
                .HasMaxLength(BookingConstants.MaxBookedForLength);

            builder.HasOne(booking => booking.Room)
                .WithMany(room => room.Bookings)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
