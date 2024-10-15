using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class CalculatorController : Controller
    {
        // GET: CalculatorController
        public ActionResult Index()
        {
            return View();
        }
        
        public IActionResult Result()
        {
            
        }

    }
}
