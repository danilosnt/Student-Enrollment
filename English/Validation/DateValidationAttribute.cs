using System.ComponentModel.DataAnnotations;

namespace StudentEnrollment.Validation
{
    public class DateValidationAttribute : ValidationAttribute
    {

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is DateTime dateValue)
            {
                if (dateValue > DateTime.Now)
                {
                    return new ValidationResult("Esta data não pode ser no futuro.");
                }

                if (dateValue < new DateTime(1900, 1, 1))
                {
                    return new ValidationResult("Esta data deve ser a partir de 1900.");
                }
            }
                return ValidationResult.Success;
        }
    }
}
