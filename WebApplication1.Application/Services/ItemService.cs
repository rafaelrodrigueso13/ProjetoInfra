using WebApplication1.Domain.Entities;
using WebApplication1.Domain.Interfaces;

namespace WebApplication1.Application.Services
{
    public class ItemService
    {
        private readonly IItemRepository _repository;

        public ItemService(IItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Item>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Item> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

       public async Task CreateAsync(Item item)
        {
            await _repository.AddAsync(item);
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(Item item)
        {
            await _repository.UpdateAsync(item);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var item = await _repository.GetByIdAsync(id);
            if (item != null)
            {
                await _repository.DeleteAsync(item);
                await _repository.SaveChangesAsync();
            }
        }

    }
}
