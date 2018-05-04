using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KashiHomeFood.Models
{
    public class Food
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        public List<FoodMenu> FoodMenus { get; set; }


    }
}
