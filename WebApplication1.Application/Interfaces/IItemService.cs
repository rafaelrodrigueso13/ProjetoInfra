using WebApplication1.Application.DTOs;

namespace WebApplication1.Application.Interfaces
{
    public interface IItemService
    {
        Task<IEnumerable<ItemDto>> GetAllAsync();
        Task<IEnumerable<ItemDto>> SearchAsync(string searchTerm);
        Task<ItemDto> GetByIdAsync(int id);
        Task<ItemDto> AddAsync(ItemDto dto);
        Task<ItemDto> UpdateAsync(ItemDto dto);
        Task<bool> DeleteAsync(int id);
    }
}