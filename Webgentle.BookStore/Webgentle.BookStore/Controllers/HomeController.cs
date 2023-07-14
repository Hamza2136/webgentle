using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Dynamic;
using Webgentle.BookStore.Models;

namespace Webgentle.BookStore.Controllers
{
    public class HomeController : Controller
    {
        [ViewData]
        public string Title { get; set; }

        public ViewResult Index()
        {
            return View();
        }
        public ViewResult AboutUs()
        {
            Title = "About Us";// We Can also set the tile of the page
            return View();
        }
        public ViewResult ContactUs()
        {
            return View();
        }
    }
}
