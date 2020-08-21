using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointFood.Model
{
    public class Restaurant
    {
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public string RestaurantOwnerId { get; set; }
        public RestaurantOwner RestaurantOwner { get; set; }

        public List<RestaurantCategory> RestaurantCategories { get; set; }
        public List<Product> Products { get; set; }
    }
}
