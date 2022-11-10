using AutoMapper;
using ProjectV2.Common.Dtos.Reviews;
using ProjectV2.Domain;

namespace ProjectV2.Bll.Profiles
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            CreateMap<ReviewUpdateDto, Review>();
            CreateMap<ReviewDto, ReviewDto>();
        }
    }
}
