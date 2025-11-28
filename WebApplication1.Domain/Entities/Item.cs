namespace WebApplication1.Domain.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public string Modelo { get; set; }
        public string Categoria { get; set; }
        public string Patrimonio { get; set; }
        public string NumeroSerie { get; set; }

        public ICollection<Manutencao> Manutencoes { get; set; }
    }
}
