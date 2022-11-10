using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectV2.Bll.Interfaces;
using ProjectV2.Common.Dtos.Countries;
using ProjectV2.Common.Exceptions;
using ProjectV2.Dal.Interfaces;
using ProjectV2.Domain;

namespace ProjectV2.Bll.Services
{
    public class CountryService : ICountryService
    {
        private readonly IRepository<Country> _repository;
        private readonly IMapper _mapper;

        public CountryService(IRepository<Country> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CountryDto> GetByIdAsync(int id)
        {
            var country = await _repository.GetByIdAsync(id);
            if (country is null)
            {
                throw new NotExistInDbException();
            }
            return _mapper.Map<CountryDto>(country);
        }

        public async Task<IList<CountryDto>> GetAllAsync()
        {
            var countrys = _repository.GetAllAsync();
            var countryDtos = new List<CountryDto>();
            foreach (var c in await countrys)
            {
                countryDtos.Add(_mapper.Map<CountryDto>(c));
            }
            return countryDtos;
        }

        public async Task<CountryDto> CreateCountryAsync(CountryUpdateDto countryUpdateDto)
        {
            var country = _mapper.Map<Country>(countryUpdateDto);
            if (_repository.ExistInDbByProperties(country, nameof(country.Name)))
            {
                throw new ExistInDbException();
            }
            await _repository.AddAsync(country);
            await _repository.SaveChangesAsync();
            return _mapper.Map<CountryDto>(country);
        }

        public async Task UpdateCountryAsync(int id, CountryUpdateDto countryUpdateDto)
        {
            var country = await _repository.GetByIdAsync(id);
            if (country is null)
            {
                throw new NotExistInDbException();
            }
            _mapper.Map(countryUpdateDto, country);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteCountryAsync(int id)
        {
            var country = await _repository.GetByIdAsync(id);
            if (country is null)
            {
                throw new NotExistInDbException();
            }
            await _repository.DeleteAsync(id);
            await _repository.SaveChangesAsync();
        }
    }
}
