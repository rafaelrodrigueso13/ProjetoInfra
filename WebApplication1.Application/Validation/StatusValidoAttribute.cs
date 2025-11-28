using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace WebApplication1.Application.Validation
{
    public class StatusValidoAttribute : ValidationAttribute
    {
        private readonly string[] _valoresPermitidos;

        public StatusValidoAttribute(string[] valoresPermitidos)
        {
            _valoresPermitidos = valoresPermitidos;
            ErrorMessage = $"Status inválido. Valores permitidos: {string.Join(", ", valoresPermitidos)}.";
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null) return ValidationResult.Success;

            var status = value.ToString();
            if (!_valoresPermitidos.Contains(status))
                return new ValidationResult(ErrorMessage);

            return ValidationResult.Success;
        }
    }
}
