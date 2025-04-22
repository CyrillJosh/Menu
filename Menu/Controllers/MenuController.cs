using Microsoft.AspNetCore.Mvc;

namespace Menu.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult Index()
        {
            //Get list(dishes) from databse
            return View(/*for displaying of dishes*/);
        }

        public IActionResult Index(string Search)
        {
            //Get filtered list(dishes) from databse using Search
            return View(/*for displaying of dishes*/);
        }
    }
}
