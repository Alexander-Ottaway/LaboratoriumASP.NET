using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Models;

public class ContactModel
{
    [HiddenInput]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(length:20, ErrorMessage = "Imię nie może być większe niż 20 znaków")]
    [MinLength(length:2, ErrorMessage = "Imię nie może być mniejsze niż 2 znaki")]
    [DisplayAttribute(Name = "Imię")]
    public string FirstName { get; set; }
    
    [Required]
    [MaxLength(length:50, ErrorMessage = "Imię nie może być większe niż 50 znaków")]
    [MinLength(length:2, ErrorMessage = "Imię nie może być mniejsze niż 2 znaki")]
    [DisplayAttribute(Name = "Nazwisko")]
    public string LastName { get; set; }
    
    [EmailAddress] // wymaga małpę
    [DisplayAttribute(Name = "Email")]
    public string Email { get; set; }
    
    [Phone]
    [RegularExpression("\\d{3} \\d{3} \\d{3}", ErrorMessage = "Wpisz numer według wzoru xxx xxx xxx")]
    [DisplayAttribute(Name = "Telefon")]
    public string PhoneNumber { get; set; }
    
    [DataType(DataType.Date)]
    [DisplayAttribute(Name = "Data Urodzenia")]
    public DateOnly BirthDate { get; set; }
    
    [DisplayAttribute(Name = "Kateforia")]
    public Category Category { get; set; }
    
    [HiddenInput]
    public int OrganizationId { get; set; }
    
    public OrganizationEntity? Organization { get; set; }
    
    [ValidateNever] 
    public List<SelectListItem> Organizations { get; set; }
    
}

