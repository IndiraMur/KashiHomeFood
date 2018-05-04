using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KashiHomeFood.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using static System.Net.Mime.MediaTypeNames;

namespace KashiHomeFood.ViewModels
{
    public class AddMenuItemViewModel
    { 
        public Menu Menu { get; set; }
        public List<SelectListItem> Foods { get; set; }
        public int FoodID { get; set; }
        public int MenuID { get; set; }

        public AddMenuItemViewModel()
        { }
        public AddMenuItemViewModel(Menu menu, IEnumerable<Food> foods)
        {
            Foods = new List<SelectListItem>();

            foreach (var food in foods)
            {
                Foods.Add(new SelectListItem
                {
                    Value = food.ID.ToString(),
                    Text = food.Name 
                });
            Menu = menu;
            }
        }


    }
}
