using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace task21.Attributes
{
    public class NoSpecialCharactersAttribute: ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null) return ValidationResult.Success;
            var name= value.ToString();
            bool hasSpecialCharacters = Regex.IsMatch(name, @"[^a-zA-Z\s]");
            if (hasSpecialCharacters)
            {
                return new ValidationResult("The field contains special characters.");
            }
            return ValidationResult.Success;
        }
    }
}
