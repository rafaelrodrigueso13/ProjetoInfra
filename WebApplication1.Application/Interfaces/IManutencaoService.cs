using WebApplication1.Application.DTOs;

namespace WebApplication1.Application.Interfaces
{
    public interface IManutencaoService
    {
        Task<IEnumerable<ManutencaoDto>> GetByItemAsync(int itemId);
        Task<ManutencaoDto> GetByIdAsync(int id);
        Task<ManutencaoDto> AddAsync(ManutencaoDto dto);
        Task<ManutencaoDto> UpdateAsync(ManutencaoDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
