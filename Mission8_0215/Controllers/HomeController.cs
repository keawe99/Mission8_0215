using Microsoft.AspNetCore.Mvc;
//using Mission8_0215.Models;
using System.Diagnostics;

namespace Mission8_0215.Controllers
{
    public class HomeController : Controller
    {


        public HomeController()
        {
        }

        public IActionResult Task()
        {
            return View();
        }


    }
}
