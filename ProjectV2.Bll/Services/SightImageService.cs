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

        public async Task<(byte[], string)> GetByIdByteArrayAsync(int id)
        {
            var sightImage = await _repository.GetByIdAsync(id);

            if (sightImage is null)
            {
                throw new NotExistInDbException();
            }
            return (sightImage.File, sightImage.Type);
        }

        public async Task<SightImageDto> CreateSightImageAsync(SightImageUpdateDto sightImageUpdateDto)
        {
            var sightImage = _mapper.Map<SightImage>(sightImageUpdateDto);

            if (_repository.ExistInDbByEntityWithProperties(sightImage, nameof(sightImage.Name), nameof(sightImage.SightId)))
            {
                throw new ExistInDbException();
            }

            await _repository.AddAsync(sightImage);
            await _repository.SaveChangesAsync();
            return _mapper.Map<SightImageDto>(sightImage);
        }

        public async Task DeleteSightImageAsync(int sightId)
        {
            var sightImages = _repository
                .GetIQueryableAll()
                .Where(sI => sI.SightId == sightId)
                .ToList();

            var deletingTasks = new Task[sightImages.Count];

            for (int i = 0; i < sightImages.Count; ++i)
            {
                deletingTasks[i] = _repository.DeleteAsync(sightImages[i].Id);
            }

            Task.WaitAll(deletingTasks);
            await _repository.SaveChangesAsync();
        }

        public async Task<IList<SightImageDto>> GetAllOfSightByteArrayAsync(int sightId)
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

        public async Task<IList<SightImageWithFileUrlDto>> GetAllOfSightFileUrlAsync(int sightId)
        {
            var sightImages = _repository
                .GetIQueryableAll()
                .Where(sI => sI.SightId.Equals(sightId))
                .Select(s => new {s.Id, s.Name, s.SightId, s.Type})
                .ToListAsync();

            var sightImageWithFileUrlDtos = new List<SightImageWithFileUrlDto>();
            foreach (var sI in await sightImages)
            {
                sightImageWithFileUrlDtos.Add(_mapper.Map<SightImageWithFileUrlDto>(new SightImageWithoutFileDto()
                {
                    Id = sI.Id,
                    Name = sI.Name,
                    SightId = sI.SightId,
                    Type = sI.Type
                }));
            }
            return sightImageWithFileUrlDtos;
        }
    }
}
