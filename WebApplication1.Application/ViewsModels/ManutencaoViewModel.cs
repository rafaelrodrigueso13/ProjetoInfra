namespace WebApplication1.Application.ViewModels
{
    public class ManutencaoViewModel
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string ItemModelo { get; set; }
        public string Observacao { get; set; }  
        public string Status { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
    }
}
