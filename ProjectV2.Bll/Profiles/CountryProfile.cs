using AutoMapper;
using ProjectV2.Common.Dtos.Countries;
using ProjectV2.Domain;

namespace ProjectV2.Bll.Profiles
{
    public class CountryProfile : Profile
    {
        public CountryProfile()
        {
            CreateMap<CountryUpdateDto, Country>();
            CreateMap<Country, CountryDto>();
        }
    }
}
