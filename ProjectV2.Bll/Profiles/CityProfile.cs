using AutoMapper;
using ProjectV2.Common.Dtos.Cities;
using ProjectV2.Domain;

namespace ProjectV2.Bll.Profiles
{
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<CityUpdateDto, City>();
            CreateMap<City, CityDto>();
        }
    }
}
