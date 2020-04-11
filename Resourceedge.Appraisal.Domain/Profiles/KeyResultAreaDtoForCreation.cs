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
            CreateMap<KeyResultArea, Models.KeyResultAreaDtoForCreation>()
                .ForMember(dest => dest.Appraiser, to => to.MapFrom(src => src.AppraiserDetails))
                .ForMember(dest => dest.HeadOfDepartment, to => to.MapFrom(src => src.HodDetails))
                .ForMember(dest => dest.myId, to => to.MapFrom(src => src.EmployeeId))
                .ForMember(dest => dest.CreatedAt, to => to.Ignore());
            CreateMap<Models.KeyResultAreaDtoForCreation, KeyResultArea>()
                .ForMember(dest => dest.HodDetails, to => to.MapFrom(src => src.HeadOfDepartment))
                .ForMember(dest => dest.AppraiserDetails, to => to.MapFrom(src => src.Appraiser))
                .ForMember(dest => dest.EmployeeId, to => to.MapFrom(src => src.myId));
        }
    }
}
