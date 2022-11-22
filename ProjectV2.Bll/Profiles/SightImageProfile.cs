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
            CreateMap<SightImage, SightImageDto>().ForMember(sID => sID.File, opt => opt.MapFrom(sI => Convert.ToBase64String(sI.File)));
            CreateMap<SightImageWithoutFileDto, SightImageWithFileUrlDto>()
                .ForMember(sIWD => sIWD.FileUrl, opt => opt
                    .MapFrom(sI => $"http://localhost:4200/api/sights/{sI.SightId}/images/{sI.Id}"));
        }
    }
}
