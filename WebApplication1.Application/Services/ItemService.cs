using Mapster;
using WebApplication1.Application.DTOs;
using WebApplication1.Application.Interfaces;
using WebApplication1.Domain.Entities;
using WebApplication1.Domain.Interfaces;

namespace WebApplication1.Application.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _repo;

        public ItemService(IItemRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<ItemDto>> GetAllAsync()
        {
            var items = await _repo.GetAllAsync();
            return items.Adapt<IEnumerable<ItemDto>>();
        }

        public async Task<IEnumerable<ItemDto>> SearchAsync(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return await GetAllAsync();
            }

            var items = await _repo.SearchAsync(searchTerm);
            return items.Adapt<IEnumerable<ItemDto>>();
        }

        public async Task<ItemDto> GetByIdAsync(int id)
        {
            var item = await _repo.GetByIdAsync(id);
            return item?.Adapt<ItemDto>();
        }

        public async Task<ItemDto> AddAsync(ItemDto dto)
        {
            var entity = dto.Adapt<Item>();
            var created = await _repo.AddAsync(entity);
            return created.Adapt<ItemDto>();
        }

        public async Task<ItemDto> UpdateAsync(ItemDto dto)
        {
            var entity = dto.Adapt<Item>();
            var updated = await _repo.UpdateAsync(entity);
            return updated.Adapt<ItemDto>();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repo.DeleteAsync(id);
        }
    }
}