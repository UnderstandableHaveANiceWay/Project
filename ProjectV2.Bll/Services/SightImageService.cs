using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectV2.Bll.Interfaces;
using ProjectV2.Common.Dtos.SightImages;
using ProjectV2.Common.Dtos.Users;
using ProjectV2.Common.Exceptions;
using ProjectV2.Dal.Interfaces;
using ProjectV2.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectV2.Bll.Services
{
    public class SightImageService : ISightImageService
    {
        private IRepository<SightImage> _repository;
        private IMapper _mapper;

        public SightImageService(IRepository<SightImage> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<SightImageDto> GetByIdAsync(int id)
        {
            var sightImage = await _repository.GetByIdAsync(id);
            if (sightImage is null)
            {
                throw new NotExistInDbException();
            }
            return _mapper.Map<SightImageDto>(sightImage);
        }

        public async Task<SightImageDto> CreateSightImageAsync(SightImageUpdateDto sightImageUpdateDto)
        {
            var sightImage = _mapper.Map<SightImage>(sightImageUpdateDto);

            if (_repository.ExistInDbByEntityWithProperties(sightImage, nameof(sightImage.Name), nameof(sightImage.SightId)))
            {
                throw new ExistInDbException();
            }
            sightImage.DirPath = @$"{sightImageUpdateDto.SightId}";
            sightImage.FullPath = @$"{sightImageUpdateDto.SightId}" +
                                  @$"/{sightImageUpdateDto.Name}.{sightImageUpdateDto.Type}";

            await _repository.AddAsync(sightImage);
            await _repository.SaveChangesAsync();
            return _mapper.Map<SightImageDto>(sightImage);
        }

        public async Task DeleteSightImageAsync(int sightId, string sightImageName)
        {
            var sightImage = _repository
                .GetIQueryableAll()
                .Where(sI => sI.Name == sightImageName && sI.SightId == sightId)
                .ToList()
                .FirstOrDefault();

            if (sightImage is null)
            {
                throw new NotExistInDbException();
            }
            await _repository.DeleteAsync(sightImage.Id);
            await _repository.SaveChangesAsync();
        }

        public async Task<IList<SightImageDto>> GetAllOfSightAsync(int sightId)
        {
            var sightImages = _repository
                .GetIQueryableAll()
                .Where(sI => sI.SightId.Equals(sightId))
                .ToListAsync();

            var sightImageDtos = new List<SightImageDto>();
            foreach (var sI in await sightImages)
            {
                sightImageDtos.Add(_mapper.Map<SightImageDto>(sI));
            }
            return sightImageDtos;
        }

        public async Task UpdateSightImageAsync(SightImageUpdateDto sightImageUpdateDto)
        {
            var sightImage = _repository
                .GetIQueryableAll()
                .Where(sI => sI.Name == sightImageUpdateDto.Name && sI.SightId == sightImageUpdateDto.SightId)
                .ToList()
                .FirstOrDefault();

            if (sightImage is null)
            {
                throw new NotExistInDbException();
            }
            _mapper.Map(sightImageUpdateDto, sightImage);
            await _repository.SaveChangesAsync();
        }
    }
}
