namespace WebApplication1.Application.DTOs
{
    public class ManutencaoDto
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string Observacao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
    }
}
