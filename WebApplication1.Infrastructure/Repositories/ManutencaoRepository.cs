using Microsoft.EntityFrameworkCore;
using WebApplication1.Domain.Entities;
using WebApplication1.Domain.Interfaces;
using WebApplication1.Infrastructure.Data;

namespace WebApplication1.Infrastructure.Repositories
{
    public class ManutencaoRepository : IManutencaoRepository
    {
        private readonly AppDbContext _context;

        public ManutencaoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Manutencao>> GetByItemIdAsync(int itemId)
        {
            return await _context.Manutencoes
                .Include(m => m.Item)
                .Where(m => m.ItemId == itemId)
                .OrderByDescending(m => m.DataInicio)
                .ToListAsync();
        }

        public async Task<IEnumerable<Manutencao>> GetAllAsync()
        {
            return await _context.Manutencoes
                .Include(m => m.Item)
                .OrderByDescending(m => m.DataInicio)
                .ToListAsync();
        }

        public async Task<Manutencao> GetByIdAsync(int id)
        {
            return await _context.Manutencoes
                .Include(m => m.Item)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Manutencao> AddAsync(Manutencao entity)
        {
            _context.Manutencoes.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Manutencao> UpdateAsync(Manutencao entity)
        {
            _context.Manutencoes.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Manutencoes.FindAsync(id);
            if (entity == null) return false;
            _context.Manutencoes.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
