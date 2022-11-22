using AutoMapper;
using ProjectV2.Common.Dtos.Reviews;
using ProjectV2.Domain;

namespace ProjectV2.Bll.Profiles
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            CreateMap<ReviewUpdateDto, Review>().ForMember((r) => r.UserId, opt => opt.MapFrom((rUpdateDto) => 0));
            CreateMap<Review, ReviewDto>();
        }
    }
}
