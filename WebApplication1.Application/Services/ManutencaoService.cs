using Mapster;
using WebApplication1.Application.ViewModels;
using WebApplication1.Domain.Entities;
using WebApplication1.Domain.Interfaces;

namespace WebApplication1.Application.Services
{
    public class ManutencaoService
    {
        private readonly IManutencaoRepository _repo;

        public ManutencaoService(IManutencaoRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Manutencao>> GetByItemIdAsync(int itemId)
        {
            return await _repo.GetByItemIdAsync(itemId);
        }

        public async Task<Manutencao> GetByIdAsync(int id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task CreateAsync(ManutencaoCreateUpdateViewModel model)
        {
            var entity = model.Adapt<Manutencao>();
            await _repo.AddAsync(entity);
        }

        public async Task UpdateAsync(ManutencaoCreateUpdateViewModel model)
        {
            var entity = await _repo.GetByIdAsync(model.Id);
            if (entity == null) return;

            entity.ItemId = model.ItemId;
            entity.Observacao = model.Observacao;
            entity.DataInicio = model.DataInicio;
            entity.DataFim = model.DataFim;
            entity.Status = model.Status;

            await _repo.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }
    }
}