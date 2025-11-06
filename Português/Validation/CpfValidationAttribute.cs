using System.ComponentModel.DataAnnotations;

namespace CadastroDeEstudantes.Validation
{
    public class CpfValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }

            var cpf = value.ToString()!.Trim().Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)
            {
                return new ValidationResult("O CPF deve conter 11 dígitos.");
            }

            // Verifica se todos os dígitos são iguais, o que é inválido (ex: 111.111.111-11)
            if (cpf.Distinct().Count() == 1)
            {
                return new ValidationResult("O CPF informado não é válido.");
            }

            // Lógica de cálculo do primeiro dígito verificador
            int soma = 0;
            for (int i = 0; i < 9; i++)
            {
                soma += int.Parse(cpf[i].ToString()) * (10 - i);
            }
            int resto = soma % 11;
            int digitoVerificador1 = resto < 2 ? 0 : 11 - resto;

            if (int.Parse(cpf[9].ToString()) != digitoVerificador1)
            {
                return new ValidationResult("O CPF informado não é válido.");
            }

            // Lógica de cálculo do segundo dígito verificador
            soma = 0;
            for (int i = 0; i < 10; i++)
            {
                soma += int.Parse(cpf[i].ToString()) * (11 - i);
            }
            resto = soma % 11;
            int digitoVerificador2 = resto < 2 ? 0 : 11 - resto;

            if (int.Parse(cpf[10].ToString()) != digitoVerificador2)
            {
                return new ValidationResult("O CPF informado não é válido.");
            }

            return ValidationResult.Success;
        }
    }
}