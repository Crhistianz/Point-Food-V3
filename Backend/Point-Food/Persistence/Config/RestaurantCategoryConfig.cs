using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PointFood.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointFood.Persistence.Config
{
    public class RestaurantCategoryConfig
    {
        public RestaurantCategoryConfig(EntityTypeBuilder<RestaurantCategory> entityBuilder)
        {
            entityBuilder.HasKey(x => new { x.RestaurantId, x.CategoryId });
            entityBuilder.HasOne(x => x.Restaurant)
                .WithMany(x => x.RestaurantCategories)
                .HasForeignKey(x => x.RestaurantId);
            entityBuilder.HasOne(x => x.Category)
                .WithMany(x => x.RestaurantCategories)
                .HasForeignKey(x => x.CategoryId);
        }
    }
}
