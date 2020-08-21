using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointFood.Dto
{
    public class RestaurantDto
    {
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public List<ProductDto> Products { get; set; }
    }

    public class RestaurantCategoryDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public List<ProductDto> Products { get; set; }
    }

    public class RestaurantCreateDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string RestaurantOwnerId { get; set; }
        public List<RestaurantCategoryCreateDto> RestaurantCategories { get; set; }
    }

    public class RestaurantUpdateDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class RestaurantCategoryCreateDto
    {
        public int CategoryId { get; set; }
    }
}
