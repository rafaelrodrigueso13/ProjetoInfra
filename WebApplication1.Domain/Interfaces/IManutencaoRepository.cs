using WebApplication1.Domain.Entities;

namespace WebApplication1.Domain.Interfaces
{
    public interface IManutencaoRepository
    {
        Task<IEnumerable<Manutencao>> GetAllAsync();
        Task<IEnumerable<Manutencao>> GetByItemIdAsync(int itemId);
        Task<Manutencao> GetByIdAsync(int id);
        Task<Manutencao> AddAsync(Manutencao entity);
        Task<Manutencao> UpdateAsync(Manutencao entity);
        Task<bool> DeleteAsync(int id);
    }
}
