using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KashiHomeFood.Models
{
    public class Menu
    {
        public int ID { get; set; }
        public String Name { get; set; }

        public List<FoodMenu> FoodMenus { get; set; }

    }
}
