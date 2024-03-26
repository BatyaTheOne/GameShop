using AutoMapper;
using GameShop.DTO;
using GameShop.Models;

namespace GameShop.Mappers
{
    public class AppMappersProfile : Profile
    {
        public AppMappersProfile() 
        {
            CreateMap<Game, GameDto>().ReverseMap()
                .ForMember(x => x.GameTypeId, y => y.MapFrom(j => j.Type))
                .ForMember(x => x.MinimumLimitAge, y => y.MapFrom(j => j.AgeLimit))
                .ForMember(x => x.LibraryId, y => y.MapFrom(j => 1));
        }
    }
}
