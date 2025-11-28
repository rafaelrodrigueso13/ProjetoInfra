using Mapster;
using WebApplication1.Domain.Entities;
using WebApplication1.Application.ViewModels;

namespace WebApplication1.Application.Mappings
{
    public class MappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Item, ItemViewModel>().TwoWays();
            config.NewConfig<Manutencao, ManutencaoViewModel>().TwoWays();
        }
    }
}
