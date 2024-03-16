using ProjectV2.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ProjectV2.Dal.EntityConfigurations
{
    internal class BookingAuditConfiguration : IEntityTypeConfiguration<BookingAudit>
    {
        public void Configure(EntityTypeBuilder<BookingAudit> builder)
        {
            builder.Property(b => b.Status)
                .HasConversion<string>();

            builder.HasOne(bookingAudit => bookingAudit.Booking)
                .WithMany(bookingAudit => bookingAudit.BookingAudits)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
