using System.Collections.Generic;
using System.Linq;
using KashiHomeFood.Data;
using KashiHomeFood.Models;
using KashiHomeFood.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KashiHomeFood.Controllers
{
    public class MenuController : Controller
    {
        private readonly FoodDbContext context;
        public MenuController(FoodDbContext dbContext)
        {
            context = dbContext;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Menu> menus = context.Menus.ToList();
            return View(menus);
        }
        public IActionResult Add()
        {
            AddMenuViewModel addMenuViewModel = new AddMenuViewModel();
            return View(addMenuViewModel);
        }
        [HttpPost]
        public IActionResult Add(AddMenuViewModel addMenuViewModel)
        {
            if (ModelState.IsValid)
            {
                Menu newMenu = new Menu
                {
                    Name = addMenuViewModel.Name
                };
                context.Menus.Add(newMenu);
                context.SaveChanges();
                return Redirect("/Menu");
            }
            return View(addMenuViewModel);
        }
        public IActionResult ViewMenu(int id)

        {
            List<FoodMenu> items = context
                .FoodMenus
                .Include(item => item.Food)
                .Where(cm => cm.MenuID == id)
                .ToList();

            Menu menu = context.Menus.Single(m => m.ID == id);

            ViewMenuViewModel viewModel = new ViewMenuViewModel
            {
                Menu = menu,
                Items = items

            };
            return View(viewModel);
        }
        // /Menu/AddItem/3
        public IActionResult AddItem(int id)
        {
            Menu menu = context.Menus.Single(m => m.ID == id);
            List<Food> foods = context.Foods.ToList();
            return View(new AddMenuItemViewModel(menu, foods));
        }
        [HttpPost]
        public IActionResult AddItem(AddMenuItemViewModel addMenuItemViewModel)
        {
            if (ModelState.IsValid)
            {
                var foodID = addMenuItemViewModel.FoodID;
                var menuID = addMenuItemViewModel.MenuID;

                IList<FoodMenu> existingItems = context.FoodMenus
                    .Where(cm => cm.FoodID == foodID)
                    .Where(cm => cm.MenuID == menuID).ToList();
                //prepwork says this is unnecessary
                if (existingItems.Count == 0)
                {
                    FoodMenu menuItem = new FoodMenu
                    {
                        Food = context.Foods.Single(c => c.ID == foodID),
                        Menu = context.Menus.Single(m => m.ID == menuID)
                    };

                    context.FoodMenus.Add(menuItem);
                    context.SaveChanges();
                }

                return Redirect(string.Format("/Menu/ViewMenu/{0}", addMenuItemViewModel.MenuID));
            }
            return View(addMenuItemViewModel);
        }
    }
}
