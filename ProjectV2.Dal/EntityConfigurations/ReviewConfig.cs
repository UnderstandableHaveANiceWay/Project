using ProjectV2.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectV2.Dal.EntityConfigurations
{
    internal class ReviewConfig : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder
                .HasOne(r => r.User)
                .WithMany(u => u.Reviews)
                .OnDelete(DeleteBehavior.Cascade);
            builder
                .HasOne(r => r.Sight)
                .WithMany(s => s.Reviews)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
