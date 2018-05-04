using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KashiHomeFood.Models;

namespace KashiHomeFood.ViewModels
{
    public class ViewMenuViewModel
    {
        public IList<FoodMenu> Items { get; set; }
        public Menu Menu { get; set; }
    }
}
