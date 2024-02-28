using Microsoft.AspNetCore.Mvc;
//using Mission8_0215.Models;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace Mission8_0215.Controllers
{
    public class HomeController : Controller
    {


        public HomeController()
        {
        }

        public IActionResult UserTaskForm()
        {
            return View();
        }

        //Take a look at home controller to make sure code matches to be able to add/edit

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.UserTaskQuadrant
                .Single(x => x.MovieId == id);

            ViewBag.category = _context.Categories //ViewBag stores small amounts of data to transfer to Views
               .OrderBy(x => x.CategoryName)
               .ToList();

            //_context.SaveChanges();
            return View("Quadrant", recordToEdit); //Returns them back to quadrant page with updated record
        }



        [HttpPost]
        public IActionResult Edit(Application UpdatedInfo) 
        {
            _context.Update(UpdatedInfo);
            _context.SaveChanges();

            return RedirectToAction("Confirmation");
        }

        [HttpGet]
        public IActionResult Movies() //Change Movies and figure out where the user will be when they click this button and where you want them to go 
        {
            ViewBag.category = _context.Categories //ViewBag stores small amounts of data to transfer to Views
                .OrderBy(x => x.CategoryName)
                .ToList();
            return View();
        }


        [HttpPost]
        public IActionResult Movies(Application response)
        {
            _context.Movies.Add(response); //Add record to database
            _context.SaveChanges(); //commits changes to database

            return View("UserTaskForm", response);
        }


    }
}
