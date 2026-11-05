using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Smallbiz.Domain.Validation;


namespace Smallbiz.Domain.Entities
{
    public class Company
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Podaj nazwę firmy."), MaxLength(200, ErrorMessage = "Nazwa może mieć najwyżej 200 znaków.")]
        public string Name { get; set; } = "";

        [Required(ErrorMessage = "Podaj NIP firmy."), MaxLength(20, ErrorMessage = "NIP może mieć najwyżej 20 znaków."), Nip]
        public string TaxId { get; set; } = "";

        [MaxLength(40, ErrorMessage = "Numer konta może mieć najwyżej 40 znaków.")]
        public string? BankAccount { get; set; }

        [Required(ErrorMessage = "Podaj państwo firmy."), MaxLength(100, ErrorMessage = "Państwo może mieć najwyżej 100 znaków.")]
        public string Country { get; set; } = "Polska";

        [Required(ErrorMessage = "Podaj miasto firmy."), MaxLength(100, ErrorMessage = "Miasto może mieć najwyżej 100 znaków.")]
        public string City { get; set; } = "";

        [Required(ErrorMessage = "Podaj adres firmy."), MaxLength(200, ErrorMessage = "Adres może mieć najwyżej 200 znaków.")]
        public string Street { get; set; } = "";

        [Required(ErrorMessage = "Podaj kod pocztowy firmy."), MaxLength(20, ErrorMessage = "Kod pocztowy może mieć najwyżej 20 znaków.")]
        public string PostalCode { get; set; } = "";

        [MaxLength(30, ErrorMessage = "Numer telefonu może mieć najwyżej 30 znaków.")]
        public string? Phone { get; set; }

        [MaxLength(150, ErrorMessage = "Email może mieć najwyżej 150 znaków.")]
        public string? Email { get; set; }

    }
}
