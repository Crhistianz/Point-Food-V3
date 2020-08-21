using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointFood.Model
{
    public class RestaurantCategory
    {
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
