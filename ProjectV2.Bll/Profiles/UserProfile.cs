using AutoMapper;
using ProjectV2.Domain;
using ProjectV2.Common.Dtos.Users;

namespace ProjectV2.Bll.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserUpdateDto, User>();
            CreateMap<User, UserDto>();
        }
    }
}
