using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpaDay.Models;

namespace SpaDay.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            ViewBag.username = "";
            ViewBag.email = "";

            return View();
        }

        [HttpPost]
        [Route("/User/Add")]
        public IActionResult SubmitAddUserForm(User newUser, string verify)
        {
            ViewBag.date = newUser.Date;
            ViewBag.email = newUser.Email;

            if (newUser.Password == verify)
            {
                ViewBag.name = newUser.Username;
                return View("Index");
            } else
            {
                ViewBag.noMatch = true;
                ViewBag.error = "passwords do not match";
                return View("Add");
            }

        }
    }
}
