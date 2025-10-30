using WebApplication1.Domain.Entities;

namespace WebApplication1.Domain.Interfaces
{
    public interface IItemRepository
    {
        Task<List<Item>> GetAllAsync();
        Task<Item?> GetByIdAsync(int id);
        Task AddAsync(Item item);
        Task UpdateAsync(Item item);
        Task DeleteAsync(Item item);
        Task SaveChangesAsync();
    }
}
