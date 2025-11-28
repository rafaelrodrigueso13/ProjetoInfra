namespace WebApplication1.Domain.Entities
{
    public class Manutencao
    {
        public int Id { get; set; }
        public int ItemId { get; set; }

        public string Observacao { get; set; }
        public string Status { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }

        public Item Item { get; set; }
    }
}
