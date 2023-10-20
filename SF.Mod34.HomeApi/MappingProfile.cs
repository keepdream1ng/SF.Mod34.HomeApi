using AutoMapper;
using SF.Mod34.HomeApi.Contracts;
using SF.Mod34.HomeApi.Configuration;

namespace SF.Mod34.HomeApi;

/// <summary>
/// Настройки маппинга всех сущностей приложения
/// </summary>
public class MappingProfile : Profile
{
    /// <summary>
    /// В конструкторе настроим соответствие сущностей при маппинге
    /// </summary>
    public MappingProfile()
    {
        CreateMap<Address, AddressInfo>();
        CreateMap<HomeOptions, InfoResponse>()
            .ForMember(m => m.AddressInfo,
                opt => opt.MapFrom(src => src.Address));
    }
}
