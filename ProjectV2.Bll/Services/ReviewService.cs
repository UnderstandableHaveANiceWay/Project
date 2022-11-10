using AutoMapper;
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
        private readonly IMapper _mapper;

        public ReviewService(IRepository<Review> repository, IMapper mapper)
        {
            _repository = repository;
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

        public async Task<ReviewDto> CreateReviewAsync(ReviewUpdateDto reviewUpdateDto)
        {
            var review = _mapper.Map<Review>(reviewUpdateDto);
            if (_repository.ExistInDbByEntityWithProperties(review, nameof(review.UserId), nameof(review.SightId)))
            {
                throw new ExistInDbException();
            }
            await _repository.AddAsync(review);
            await _repository.SaveChangesAsync();
            return _mapper.Map<ReviewDto>(review);
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
