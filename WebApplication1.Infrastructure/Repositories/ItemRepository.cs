using Microsoft.EntityFrameworkCore;
using WebApplication1.Domain.Entities;
using WebApplication1.Domain.Interfaces;
using WebApplication1.Infrastructure.Data;

namespace WebApplication1.Infrastructure.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly AppDbContext _context;

        public ItemRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Item>> GetAllAsync()
        {
            return await _context.Items.ToListAsync();
        }

        public async Task<IEnumerable<Item>> SearchAsync(string searchTerm)
        {
            var term = searchTerm.ToLower();

            return await _context.Items
                .Where(i => i.Modelo.ToLower().Contains(term) ||
                           i.Categoria.ToLower().Contains(term) ||
                           i.Patrimonio.ToLower().Contains(term) ||
                           i.NumeroSerie.ToLower().Contains(term))
                .ToListAsync();
        }

        public async Task<Item> GetByIdAsync(int id)
        {
            return await _context.Items.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Item> AddAsync(Item entity)
        {
            _context.Items.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Item> UpdateAsync(Item entity)
        {
            _context.Items.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var item = await GetByIdAsync(id);
            if (item == null) return false;

            _context.Items.Remove(item);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}