using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PointFood.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointFood.Persistence.Config
{
    public class ProductTypeConfig
    {
        public ProductTypeConfig(EntityTypeBuilder<ProductType> entityBuilder)
        {
            entityBuilder.Property(x => x.Name).IsRequired().HasMaxLength(20);

            entityBuilder.HasData(
                new ProductType
                {
                    ProductTypeId = 1,
                    Name = "Plato"
                },
                new ProductType
                {
                    ProductTypeId = 2,
                    Name = "Extra"
                }
                );
        }
    }
}
