using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PointFood.Model.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointFood.Persistence.Config
{
    public class ApplicationRoleConfig
    {
        public ApplicationRoleConfig(EntityTypeBuilder<ApplicationRole> entityBuilder)
        {
            entityBuilder.HasMany(e => e.UserRoles)
                .WithOne(e => e.Role)
                .HasForeignKey(e => e.RoleId)
                .IsRequired();

            entityBuilder.HasData(
                    new ApplicationRole
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "RESTAURANTOWNER",
                        NormalizedName = "RESTAURANTOWNER"
                    },
                    new ApplicationRole
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "CLIENT",
                        NormalizedName = "CLIENT"
                    }
                ); ;
        }
    }
}
