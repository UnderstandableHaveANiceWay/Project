using ProjectV2.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectV2.Dal.EntityConfigurations
{
    internal class SightImageConfig : IEntityTypeConfiguration<SightImage>
    {
        public void Configure(EntityTypeBuilder<SightImage> builder)
        {
            builder
                .HasIndex(sI => new { sI.Name, sI.SightId}, "SightImage_Name-SightId_Unique")
                .IsUnique();
            builder
                .HasOne(sI => sI.Sight)
                .WithMany(s => s.SightImages)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
