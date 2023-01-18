using System;
using System.ComponentModel.DataAnnotations;

namespace PersonManagement.Web.Infrastructure.Attributes
{
    public class GeorgianOnlyAttribute : ValidationAttribute
    {

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is string)
            {
                string s = (string)value;
                if (s.All(ch => ch >= 'ა' && ch <= 'ჰ') == true)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("All characters must be Georgian letters");
                }
            }
            return new ValidationResult("Incorrect type");
        }
    }
}