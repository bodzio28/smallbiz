using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Smallbiz.Domain.Validation
{
    public class NipAttribute : ValidationAttribute
    {
        public NipAttribute()
        {
            ErrorMessage = "Podany numer NIP jest nieprawidłowy";
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is null || string.IsNullOrWhiteSpace(value.ToString()))
            {
                return ValidationResult.Success;
            }
            if (value is string nip && NipValidator.IsValid(nip))
            {
                return ValidationResult.Success;
            }
            return new ValidationResult(ErrorMessage, new[] { validationContext.MemberName ?? string.Empty });
        }
    }
}
