﻿using AutoMapper;
using ProjectV2.Common.Dtos.Sights;
using ProjectV2.Domain;

namespace ProjectV2.Bll.Profiles
{
    public class SightProfile : Profile
    {
        public SightProfile()
        {
            CreateMap<RoomUpdateDto, Room>();
            CreateMap<Room, RoomDto>();
        }
    }
}
