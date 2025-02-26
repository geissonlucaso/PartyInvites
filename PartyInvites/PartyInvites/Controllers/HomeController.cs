using Microsoft.AspNetCore.Mvc;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {
        //public string Index()
        //{
        //    return "Hello World";
        //}

        public ViewResult Index()
        {
            int hour = DateTime.Now.Hour;

            //Dynamic Output.
            ViewBag.Greeting = hour < 12 ? "Good Morning" : "Good Afternoon";

            return View("MyView");
        }
    }
}
