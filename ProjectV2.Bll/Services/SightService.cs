using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectV2.Bll.Interfaces;
using ProjectV2.Common.Dtos.Cities;
using ProjectV2.Common.Dtos.Sights;
using ProjectV2.Common.Exceptions;
using ProjectV2.Dal.Interfaces;
using ProjectV2.Domain;
using System.Xml.Linq;

namespace ProjectV2.Bll.Services
{
    public class SightService : ISightService
    {
        private readonly IRepository<Sight> _repository;
        private readonly IMapper _mapper;

        public SightService(IRepository<Sight> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<SightDto> GetByIdAsync(int id)
        {
            var sight = await _repository.GetByIdAsync(id);

            if (sight is null)
            {
                throw new NotExistInDbException();
            }
            return _mapper.Map<SightDto>(sight);
        }

        public async Task<ICollection<SightDto>> GetAllOfCityAsync(string cityName)
        {
            var sights = _repository
                .GetIQueryableAll()
                .Include((sight) => sight.City)
                .Where((city) => city.City.Name.Equals(cityName)).ToListAsync();

            var sightDtos = new List<SightDto>();
            foreach (var s in await sights)
            {
                sightDtos.Add(_mapper.Map<SightDto>(s));
            }

            return sightDtos;
        }

        public async Task<ICollection<SightDto>> GetAllAsync()
        {
            var sights = _repository.GetAllAsync();
            var sightDtos = new List<SightDto>();
            foreach (var s in await sights)
            {
                sightDtos.Add(_mapper.Map<SightDto>(s));
            }
            return sightDtos;
        }

        public async Task<SightDto> CreateSightAsync(SightUpdateDto sightUpdateDto)
        {
            var sight = _mapper.Map<Sight>(sightUpdateDto);
            if (_repository.ExistInDbByEntityWithProperties(sight, nameof(sight.Name)))
            {
                throw new ExistInDbException();
            }
            await _repository.AddAsync(sight);
            await _repository.SaveChangesAsync();
            return _mapper.Map<SightDto>(sight);
        }

        public async Task UpdateSightAsync(int id, SightUpdateDto sightUpdateDto)
        {
            var sight = await _repository.GetByIdAsync(id);
            if (sight is null)
            {
                throw new NotExistInDbException();
            }
            _mapper.Map(sightUpdateDto, sight);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteSightAsync(int id)
        {
            var sight = await _repository.GetByIdAsync(id);
            if (sight is null)
            {
                throw new NotExistInDbException();
            }
            await _repository.DeleteAsync(id);
            await _repository.SaveChangesAsync();
        }
    }
}
