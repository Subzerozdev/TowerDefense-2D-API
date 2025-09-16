using AutoMapper;
using Repository.Model;

namespace TowerDefenseAPI.DTO

{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerReadDto>();
            CreateMap<CustomerCreateDto, Customer>();
            CreateMap<GameInfo, GameInfoReadDto>()
    .ForMember(dest => dest.Username,
               opt => opt.MapFrom(src => src.Customer.Username));
            CreateMap<GameInfoUpdateDto, GameInfo>();
        }
    }
}
