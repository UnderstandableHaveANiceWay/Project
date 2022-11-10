using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectV2.Domain;

namespace ProjectV2.Dal.EntityConfigurations
{
    internal class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasIndex(p => p.Username, "User_Username_Unique")
                .IsUnique();
            builder
                .HasIndex(p => p.Email, "User_Email_Unique")
                .IsUnique();
            builder
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
