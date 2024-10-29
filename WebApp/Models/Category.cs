using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace WebApp.Models;

public enum Category
{   [Display(Name = "Rodzina", Order = 2)]
    Family,
    [Display(Name = "Znajomi", Order = 1)]
    Friend,
    [Display(Name = "Kontakty zawodowe", Order = 3)]
    Business
}