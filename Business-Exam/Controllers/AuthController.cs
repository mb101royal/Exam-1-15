using Business_Exam.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Business_Exam.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Register()
        {


            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}
