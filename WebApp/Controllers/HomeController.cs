using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult About()
    {
        return View();
    }
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    
    public IActionResult Kalkulator(Operator? op, double? x, double? y)
    {
       
        if (x is null)
        {
            ViewBag.ErrorMessage = "Niepoprawny format parametru x";
            return View("CalculatorError");
        }

       
        if (op != Operator.Sin && y is null)
        {
            ViewBag.ErrorMessage = "Niepoprawny format parametru y";
            return View("CalculatorError");
        }

        if (op is null)
        {
            ViewBag.ErrorMessage = "Nieznany operator!";
            return View("CalculatorError"); // w przypadku złego operatora
        }

        switch (op)
        {
            case Operator.Add:
                ViewBag.Result = x + y;
                break;
            case Operator.Sub:
                ViewBag.Result = x - y;
                break;
            case Operator.Mul:
                ViewBag.Result = x * y;
                break;
            case Operator.Div:
                if (y == 0)
                {
                    ViewBag.ErrorMessage = "Nie można dzielić przez zero!";
                    return View("CalculatorError");
                }
                ViewBag.Result = x / y;
                break;
            case Operator.Pow:
                ViewBag.Result = Math.Pow((double)x, (double)y);
                break;
            case Operator.Sin:
                ViewBag.Result = Math.Sin((double)x); 
                break;
        }

        return View();
    }




    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

public enum Operator
{
    Add, Sub, Mul, Div, Pow, Sin
}