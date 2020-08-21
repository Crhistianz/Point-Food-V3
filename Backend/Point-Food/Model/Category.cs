using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointFood.Model
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public List<RestaurantCategory> RestaurantCategories { get; set; }
    }
}
