using ProjectV2.Common.Dtos.Reviews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectV2.Bll.Interfaces
{
    public interface IReviewService
    {
        public Task<ReviewDto> GetByIdAsync(int id);
        public Task<IList<ReviewDto>> GetAllAsync();
        public Task<IList<ReviewDto>> GetAllOfSightAsync(int sightId);
        public Task<ReviewDto> CreateReviewAsync(ReviewUpdateDto reviewUpdateDto);
        public Task UpdateReviewAsync(int id, ReviewUpdateDto reviewUpdateDto);
        public Task DeleteReviewAsync(int id);
    }
}
