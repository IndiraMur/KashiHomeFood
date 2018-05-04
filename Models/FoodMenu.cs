using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KashiHomeFood.Models
{
    public class FoodMenu
    {
        public int MenuID { get; set; }
        public Menu Menu { get; set; }

        public int FoodID { get; set; }
        public Food Food { get; set; }
      
    }
}
