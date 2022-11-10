using AutoMapper;
using ProjectV2.Common.Dtos.Roles;
using ProjectV2.Domain;

namespace ProjectV2.Bll.Profiles
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<RoleUpdateDto, Role>();
            CreateMap<Role, RoleDto>();
        }
    }
}
