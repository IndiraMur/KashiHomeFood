using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KashiHomeFood.Models;
using KashiHomeFood.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KashiHomeFood.Controllers
{
    public class UserController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            List<User> users = UserData.GetAll();
            return View(users);
        }
        public IActionResult Add()
        {
            AddUserViewModel addUserViewModel = new AddUserViewModel();
            return View(addUserViewModel);

        }
        [HttpPost]
        public IActionResult Add(AddUserViewModel addUserViewModel, User user)
        {
            if (user == null) user = new User();

            if (ModelState.IsValid)
            {
                user = new User()
                {
                    Username = addUserViewModel.Username,
                    Email = addUserViewModel.Email,
                    Password = addUserViewModel.Password


                };
                UserData.Add(user);

                return Redirect("Order");

            }


            return View(addUserViewModel);
        }
        public IActionResult Order()
        {
            return View();
        }
    }
}
