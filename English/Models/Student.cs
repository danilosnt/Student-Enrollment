using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using StudentEnrollment.Validation;

namespace StudentEnrollment.Models
{
    [Index(nameof(CPF), IsUnique = true)]
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The Full Name field is required.")]
        [StringLength(100, ErrorMessage = "The name must be 100 characters or less.")]
        [RegularExpression(@"^[a-zA-ZáéíóúàâêôãõçÁÉÍÓÚÀÂÊÔÃÕÇ ]+$", ErrorMessage = "The name must contain only letters and spaces.")]
        [Display(Name = "Full Name")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "The CPF field is required.")]
        [Display(Name = "CPF")]
        [CpfValidation(ErrorMessage = "The provided CPF is not valid.")]
        public string CPF { get; set; } = string.Empty;

        [Required(ErrorMessage = "The Address field is required.")]
        [StringLength(200, ErrorMessage = "The address must be 200 characters or less.")]
        [Display(Name = "Address")]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "The Completion Date field is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Completion Date")]
        [DateValidation]
        public DateTime CompletionDate { get; set; }
    }
}