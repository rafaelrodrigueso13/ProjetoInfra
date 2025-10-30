using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Application.ViewModels
{
    public class ItemCreateUpdateViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Modelo { get; set; }

        [Required]
        public string Categoria { get; set; }

        [Required]
        public string Patrimonio { get; set; }

        [Required]
        public string NumeroSerie { get; set; }
    }
}
