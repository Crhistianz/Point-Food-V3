using PointFood.Model.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointFood.Model
{
    public class Client : ApplicationUser
    {
        public List<Card> Cards { get; set; }
    }
}
