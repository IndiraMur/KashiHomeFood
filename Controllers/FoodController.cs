using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KashiHomeFood.Data;
using KashiHomeFood.Models;
using KashiHomeFood.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KashiHomeFood.Controllers
{
    public class FoodController : Controller
    {
        private FoodDbContext context;

        public FoodController(FoodDbContext dbContext)
        {
            context = dbContext;
        }

        
        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Food> foods = context.Foods.ToList();
            return View(foods);
        }
        public IActionResult Add()
        {
            AddFoodViewModel addFoodViewModel = new AddFoodViewModel();
            return View(addFoodViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddFoodViewModel addFoodViewModel)
        {
            if (ModelState.IsValid)
            {
                //Add the new food to my existing foods
                Food newFood = new Food
                {
                    Name = addFoodViewModel.Name,
                    Description = addFoodViewModel.Description,
                    Price = addFoodViewModel.Price
                    

                };
                

                context.Foods.Add(newFood);
                context.SaveChanges();

                return Redirect("/Food");

            }
            return View(addFoodViewModel);
        }

        public IActionResult Remove()
        {

            ViewBag.title = "Remove Foods";
            ViewBag.Foods = context.Foods.ToList();
            return View();
        }

        [HttpPost]

        public IActionResult Remove(int[] foodIds)
        {
            foreach (int foodId in foodIds)
            {
                Food theFood = context.Foods.Single(f => f.ID == foodId);
                context.Foods.Remove(theFood);
            }

            context.SaveChanges();

            return Redirect("/");
        }
    }
}
