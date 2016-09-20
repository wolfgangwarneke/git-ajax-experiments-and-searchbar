using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using basicAJAX.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace basicAJAX.Controllers
{
    public class HomeController : Controller
    {
        private AjaxDemoContext db = new AjaxDemoContext();
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult HelloAjax()
        {
            return Content("Hello XMLHttp Request Object!", "text/plain");
        }
        public IActionResult Sum(int firstNumber, int secondNumber)
        {
            return Content((firstNumber + secondNumber).ToString(), "text/plain");
        }

        public IActionResult DisplayObject()
        {
            Destination destination = new Destination("Tokyo", "Japan", 1);
            return Json(destination);
        }

        public IActionResult DisplayViewWithAjax()
        {
            return View();
        }

        public int ReturnNumber1()
        {
            return 1; 
        }

        public string GetMessageToUpper(string message)
        {
            string newMessage = message + ' ' + message;
            return newMessage;
        }
        public Destination DisplayDestinationObject()
        {
            Destination coolDestination = new Destination("McMurdo Station", "Antarctica", 2319);
            return coolDestination;
        }

        public List<Destination> DisplayDestinationList()
        {
            List<Destination> list = new List<Destination> { };
            Destination coolDestination = new Destination("McMurdo Station", "Antarctica", 2319);
            list.Add(coolDestination);
            Destination warmDestination = new Destination("San Miguel", "El Salvador", 9234);
            list.Add(warmDestination);
            Destination mildDestination = new Destination("Cleveland", "USA", 2100);
            list.Add(warmDestination);
            return list;
        }
        public IActionResult RandomDestinationList(int destinationCount)
        {
            var randomDestinationList = db.Destinations.OrderBy(r => Guid.NewGuid()).Take(destinationCount);
            return Json(randomDestinationList);
        }

        [HttpPost]
        public IActionResult NewDestination(string newCity, string newCountry)
        {
            Destination newDestination = new Destination(newCity, newCountry);
            Random rnd = new Random();
            int randomId = rnd.Next(1, 12000000);
            newDestination.Id = randomId;
            db.Destinations.Add(newDestination);
            db.SaveChanges();
            return Json(newDestination);
        }

        public IActionResult SearchName(string nameQuery)
        {
            var randomDestinationList = db.Destinations.Where(s => s.City.Contains(nameQuery));
            return Json(randomDestinationList);
        }

    }
}
