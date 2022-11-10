using AutoMapper;
using ProjectV2.Common.Dtos.SightImages;
using ProjectV2.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectV2.Bll.Profiles
{
    internal class SightImageProfile : Profile
    {
        public SightImageProfile()
        {
            CreateMap<SightImageUpdateDto, SightImage>();
            CreateMap<SightImage, SightImageDto>();
        }
    }
}
