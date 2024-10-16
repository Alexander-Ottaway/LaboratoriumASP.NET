using System;

namespace WebApp.Models
{
    public class Birth
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }

        // walidacja
        public bool IsValid()
        {
            return !string.IsNullOrEmpty(Name) && BirthDate < DateTime.Now;
        }

        // obliczanie
        public int CalculateAge()
        {
            var today = DateTime.Today;
            var age = today.Year - BirthDate.Year;
            if (BirthDate.Date > today.AddYears(-age)) age--;
            return age;
        }
    }
}