using Microsoft.AspNetCore.Mvc;
using PartyInvites.Models;

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

        [HttpGet]
        public ViewResult RsvpForm()
        {
            return View();
        }

        [HttpPost]
        public ViewResult RsvpForm(GuestResponse guestResponse)
        {
            // TODO: Store response from guest.
            if (ModelState.IsValid)
            {
                Repository.AddResponse(guestResponse);
                return View("Thanks", guestResponse);
            } else
            {
                // There is a validation error.
                return View();
            }
        }

        public ViewResult ListResponses()
        {
            return View(Repository.Responses.Where(r => r.WillAttend == true)); ;
        }
    }
}
