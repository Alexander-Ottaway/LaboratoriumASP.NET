using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class BirthController : Controller
    {
        // Display the form
        [HttpGet]
        public IActionResult Form()
        {
            return View();
        }

        // Handle form submission
        [HttpPost]
        public IActionResult Form(Birth model)
        {
            if (model.IsValid())
            {
                // If the data is valid, calculate age and pass it to the result view
                int age = model.CalculateAge();
                ViewBag.Message = $"Hello {model.Name}, you are {age} years old.";
                return View("Result");
            }
            else
            {
                // If the data is invalid, reload the form
                ViewBag.Message = "Invalid input, please try again.";
                return View();
            }
        }
    }
}