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
    internal class RoleConfig : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder
                .HasIndex(r => r.Name, "Role_Name_Unique")
                .IsUnique();
            builder
                .HasData(
                    new Role() { Id = 1, Name = "admin" },
                    new Role() { Id = 2, Name = "user" });
        }
    }
}
