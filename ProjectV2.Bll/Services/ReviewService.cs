using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectV2.Bll.Interfaces;
using ProjectV2.Common.Dtos.Reviews;
using ProjectV2.Common.Exceptions;
using ProjectV2.Dal.Interfaces;
using ProjectV2.Domain;

namespace ProjectV2.Bll.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IRepository<Review> _repository;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Sight> _sightRepository;
        private readonly IMapper _mapper;

        public ReviewService(
            IRepository<Review> repository,
            IRepository<User> userRepository,
            IRepository<Sight> sightRepository,
            IMapper mapper)
        {
            _repository = repository;
            _userRepository = userRepository;
            _sightRepository = sightRepository;
            _mapper = mapper;
        }

        public async Task<ReviewDto> GetByIdAsync(int id)
        {
            var review = await _repository.GetByIdAsync(id);
            if (review is null)
            {
                throw new NotExistInDbException();
            }
            return _mapper.Map<ReviewDto>(review);
        }

        public async Task<IList<ReviewDto>> GetAllAsync()
        {
            var reviews = _repository.GetAllAsync();
            var reviewDtos = new List<ReviewDto>();
            foreach (var r in await reviews)
            {
                reviewDtos.Add(_mapper.Map<ReviewDto>(r));
            }
            return reviewDtos;
        }

        public async Task<IList<ReviewDto>> GetAllOfSightAsync(int sightId)
        {
            var reviews = _repository.GetIQueryableAll()
                .Where(r => r.SightId == sightId)
                .Include(r => r.User)
                .ToListAsync();
            var reviewDtos = new List<ReviewDto>();
            foreach (var r in await reviews)
            {
                reviewDtos.Add(_mapper.Map<ReviewDto>(r));
            }
            return reviewDtos;
        }

        public async Task<ReviewDto> CreateReviewAsync(ReviewUpdateDto reviewUpdateDto)
        {
            var user = _userRepository.GetIQueryableAll()
                .FirstOrDefault(u => u.Username == reviewUpdateDto.Username);

            if (user == null)
            {
                throw new NotExistInDbException();
            }

            var review = _mapper.Map<Review>(reviewUpdateDto);
            review.UserId = user.Id;
            review.User = user;

            await _repository.AddAsync(review);

            var sight = await _sightRepository.GetByIdAsync(reviewUpdateDto.SightId);

            sight.VisitPriority = (int)Math.Round(_repository.GetIQueryableAll()
                .Where(r => r.SightId == sight.Id)
                .Average(r => r.Rating));

            await _repository.SaveChangesAsync();

            var reviewDto = _mapper.Map<ReviewDto>(review);

            return reviewDto;
        }

        public async Task UpdateReviewAsync(int id, ReviewUpdateDto reviewUpdateDto)
        {
            var review = await _repository.GetByIdAsync(id);
            if (review is null)
            {
                throw new NotExistInDbException();
            }
            _mapper.Map(reviewUpdateDto, review);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteReviewAsync(int id)
        {
            var review = await _repository.GetByIdAsync(id);
            if (review is null)
            {
                throw new NotExistInDbException();
            }
            await _repository.DeleteAsync(id);
            await _repository.SaveChangesAsync();
        }
    }
}
