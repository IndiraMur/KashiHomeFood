using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KashiHomeFood.Data;
using KashiHomeFood.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KashiHomeFood.Controllers
{
    public class OnlineOrder : Controller
    {
        private readonly FoodDbContext context;
        public OnlineOrder(FoodDbContext dbContext)
        {
            this.context = dbContext;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            
            return View();
        }
        public IActionResult SelectMenu()
        {
            ViewBag.title = "Select Menu";
            ViewBag.foods = context.Foods.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult SelectMenu(int[] foodIds)
        {
            foreach (int foodId in foodIds)
            {
                Food theFood= context.Foods.Single(c => c.ID == foodId);
                context.Foods.Remove(theFood);
            }

            context.SaveChanges();
            return Redirect("/");
        }
    }
}
