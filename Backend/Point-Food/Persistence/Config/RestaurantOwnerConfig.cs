using GenFu;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PointFood.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointFood.Persistence.Config
{
    public class RestaurantOwnerConfig
    {
        public RestaurantOwnerConfig(EntityTypeBuilder<RestaurantOwner> entityBuilder)
        {
            entityBuilder.HasOne(x => x.Restaurant)
                .WithOne(x => x.RestaurantOwner)
                .HasForeignKey<Restaurant>(x => x.RestaurantOwnerId);
        }
    }
}
