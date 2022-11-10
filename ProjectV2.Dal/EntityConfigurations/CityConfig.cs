using ProjectV2.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectV2.Dal.EntityConfigurations
{
    internal class CityConfig : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder
                .HasIndex(c => c.Name, "City_Name_Unique")
                .IsUnique();
            builder
                .HasOne(city => city.Country)
                .WithMany(country => country.Cities)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
