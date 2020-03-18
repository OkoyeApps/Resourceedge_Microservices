using AutoMapper;
using Resourceedge.Appraisal.Domain.Entities;
using Resourceedge.Appraisal.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Resourceedge.Appraisal.Domain.Profiles
{
    class KeyResultAreaDtoForCreation : Profile
    {
        public KeyResultAreaDtoForCreation()
        {
            CreateMap<KeyResultAreas, Models.KeyResultAreaDtoForCreation>()
                .ForMember( dest => dest.Appraiser, to => to.MapFrom(src => src.AppraiserDetails))
                .ForMember(dest => dest.HeadOfDepartment,to => to.MapFrom(src => src.HodDetails))
                .ForMember(dest =>dest.myId, to =>to.MapFrom(src =>src.UserId));
            CreateMap<Models.KeyResultAreaDtoForCreation, KeyResultAreas>()
                .ForMember(dest => dest.HodDetails, to => to.MapFrom(src => src.HeadOfDepartment))
                .ForMember(dest => dest.AppraiserDetails, to => to.MapFrom(src => src.Appraiser))
                .ForMember(dest =>dest.UserId, to => to.MapFrom(src =>src.myId));
        }
    }
}
