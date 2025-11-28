using WebApplication1.Domain.Entities;

namespace WebApplication1.Domain.Interfaces
{
    public interface IItemRepository
    {
        Task<IEnumerable<Item>> GetAllAsync();
        Task<IEnumerable<Item>> SearchAsync(string searchTerm);
        Task<Item> GetByIdAsync(int id);
        Task<Item> AddAsync(Item entity);
        Task<Item> UpdateAsync(Item entity);
        Task<bool> DeleteAsync(int id);
    }
}