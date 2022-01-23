using AutoMapper;
using PlateformService.Dtos;
using PlateformService.Models;

namespace PlateformService.Profiles
{
    public class PlatformProfile : Profile
    {
       public PlatformProfile()
       {
           CreateMap<Platform,PlatformReadDto>();
           CreateMap<PlateformCreateDto,Platform>();
       }
    }
}