using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

public class ContactController : Controller
{

    private static Dictionary<int, ContactModel> _contacts = new()
    {// klamra _contacts = new()
        { // klamra wpisu
            1,
            new ContactModel()
            {// klamra new Contact()
                Id = 1,
                FirstName = "Alexander",
                LastName = "Ottaway",
                Email = "adres@gmail.com",
                PhoneNumber = "777 777 777",
                BirthDate = new DateOnly(2002, 10, 29)
            }
        },
        {
            2,
            new ContactModel()
            {
                Id = 2,
                FirstName = "Jagoda",
                LastName = "Kasperek",
                Email = "adres2@gmail.com",
                PhoneNumber = "444 444 444",
                BirthDate = new DateOnly(2002, 9, 14)
            }
        },
        
    };

    private static int currentId = 3;
    
    // Lista kontaktów, przycisk dodawania kontaktu
    public IActionResult Index()
    {
        return View(_contacts);
    }
    
    // metoda dodawania kontaktu

    public IActionResult Add()
    {
        return View();
    }

    //odebranie danych z formularza walidacja i dodawanie kontaktu do kolekcji

    [HttpPost]
    public IActionResult Add(ContactModel model)
    {
        if (!ModelState.IsValid)
        {
            //wyswietlanie ponowne formularza z bledami
            return View(model);
        }

        // dodanie modelu do kolekcji
        model.Id = ++currentId;
        _contacts.Add(model.Id, model);
        
        
        return View("Index", _contacts);
    }

    public IActionResult Delete(int id)
    {
        _contacts.Remove(id);
        return View("Index", _contacts);
    }

    public IActionResult Edit()
    {
        throw new NotImplementedException();
    }

    public IActionResult Details()
    {
        throw new NotImplementedException();
    }
}
