using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using CadastroDeEstudantes.Validation;


namespace CadastroDeEstudantes.Models
{
        // Index para deixar o CPF como valor único
        [Index(nameof(CPF), IsUnique = true)]
    public class Estudante
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O Nome deve ter no máximo 100 caracteres.")]
        [RegularExpression(@"^[a-zA-ZáéíóúàâêôãõçÁÉÍÓÚÀÂÊÔÃÕÇ ]+$", ErrorMessage = "O nome deve conter apenas letras e espaços.")]
        [Display(Name = "Nome Completo")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo CPF é obrigatório.")]
        [Display(Name = "CPF")]
        [CpfValidation(ErrorMessage = "O CPF informado não é válido.")] // Atributo para validação do CPF
        public string CPF { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo Endereço é obrigatório.")]
        [StringLength(200, ErrorMessage = "O Endereço deve ter no máximo 200 caracteres.")]
        [Display(Name = "Endereço")]
        public string Endereco { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo Data de Conclusão é obrigatório.")]
        [DataType(DataType.Date)]
        [Display(Name = "Data de Conclusão")]
        [DateValidationAttribute]
        public DateTime DataConclusao { get; set; }
    }
}