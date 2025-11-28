using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Application.Validation
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class DataInicioMenorQueDataFimAttribute : ValidationAttribute
    {
        private readonly string _dataFimPropertyName;

        public DataInicioMenorQueDataFimAttribute(string dataFimPropertyName)
        {
            _dataFimPropertyName = dataFimPropertyName;
            ErrorMessage = "Data de início não pode ser maior que a Data de fim.";
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var dataInicio = value as DateTime?;
            if (dataInicio == null)
                return ValidationResult.Success;
            var dataFimProperty = validationContext.ObjectType.GetProperty(_dataFimPropertyName);
            if (dataFimProperty == null)
                return new ValidationResult($"Propriedade {_dataFimPropertyName} não encontrada.");

            var dataFim = dataFimProperty.GetValue(validationContext.ObjectInstance) as DateTime?;
            if (dataFim == null)
                return ValidationResult.Success; 

            if (dataInicio > dataFim)
                return new ValidationResult(ErrorMessage);

            return ValidationResult.Success;
        }
    }
}
