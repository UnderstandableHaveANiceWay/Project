using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectV2.Bll.Interfaces;
using ProjectV2.Common.Dtos.Cities;
using ProjectV2.Common.Exceptions;
using ProjectV2.Dal.Interfaces;
using ProjectV2.Domain;

namespace ProjectV2.Bll.Services
{
    public class CityService : ICityService
    {
        private readonly IRepository<City> _repository;
        private readonly IMapper _mapper;

        public CityService(IRepository<City> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CityDto> GetByIdAsync(int id)
        {
            var city = await _repository.GetByIdAsync(id);
            if (city is null)
            {
                throw new NotExistInDbException();
            }
            return _mapper.Map<CityDto>(city);
        }

        public async Task<IList<CityDto>> GetAllAsync()
        {
            var cities = _repository.GetAllAsync();
            var cityDtos = new List<CityDto>();
            foreach (var c in await cities)
            {
                cityDtos.Add(_mapper.Map<CityDto>(c));
            }
            return cityDtos;
        }

        public async Task<IList<CityDto>> GetAllOfCountryAsync(string countryName)
        {
            var cities = await _repository
                .GetIQueryableAll()
                .Include((city) => city.Country)
                .Where((city) => city.Country.Name.Equals(countryName)).ToListAsync();

            var cityDtos = new List<CityDto>();
            foreach (var c in cities)
            {
                cityDtos.Add(_mapper.Map<CityDto>(c));
            }

            return cityDtos;
        }

        public async Task<CityDto> CreateCityAsync(CityUpdateDto cityUpdateDto)
        {
            var city = _mapper.Map<City>(cityUpdateDto);
            if (_repository.ExistInDbByEntityWithProperties(city, nameof(city.Name)))
            {
                throw new ExistInDbException();
            }
            await _repository.AddAsync(city);
            await _repository.SaveChangesAsync();
            return _mapper.Map<CityDto>(city);
        }

        public async Task UpdateCityAsync(int id, CityUpdateDto cityUpdateDto)
        {
            var city = await _repository.GetByIdAsync(id);
            if (city is null)
            {
                throw new NotExistInDbException();
            }
            _mapper.Map(cityUpdateDto, city);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteCityAsync(int id)
        {
            var city = await _repository.GetByIdAsync(id);
            if (city is null)
            {
                throw new NotExistInDbException();
            }
            await _repository.DeleteAsync(id);
            await _repository.SaveChangesAsync();
        }
    }
}
