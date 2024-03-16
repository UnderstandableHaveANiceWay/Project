using ProjectV2.Domain;
using ProjectV2.Domain.Utils.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectV2.Dal.EntityConfigurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(user => user.Role).HasConversion<string>();

            builder.Property(user => user.FirstName)
                .HasMaxLength(UserConstants.NameMaxLength);
            builder.Property(user => user.LastName)
                .HasMaxLength(UserConstants.NameMaxLength);

            builder.Property(user => user.FullName).HasComputedColumnSql("[FirstName] + ' ' + [LastName]", stored: true);
        }
    }
}
