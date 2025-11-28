using System;
using System.ComponentModel.DataAnnotations;
using WebApplication1.Application.Validation;

namespace WebApplication1.Application.ViewModels
{
    public class ManutencaoCreateUpdateViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Descrição é obrigatória.")]
        public string Observacao { get; set; }

        [Required(ErrorMessage = "Data de início é obrigatória.")]
        [DataInicioMenorQueDataFim("DataFim", ErrorMessage = "Data de início não pode ser maior que a Data de fim.")]
        public DateTime DataInicio { get; set; }

        public DateTime? DataFim { get; set; }

        [Required(ErrorMessage = "Status é obrigatório.")]
        [StatusValido(new string[] { "Aberto", "Em andamento", "Concluído" })]
        public string Status { get; set; }

        public int ItemId { get; set; }
    }
}
