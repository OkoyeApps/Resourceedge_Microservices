﻿using AutoMapper;
using Resourceedge.Appraisal.Domain.Entities;
using Resourceedge.Appraisal.Domain.Models;
using System;

namespace Resourceedge.Appraisal.Domain.Profiles
{
    class KeyResultAreaProfile : Profile
    {
        public KeyResultAreaProfile()
        {
            CreateMap<KeyResultArea, KeyResultAreaForUpdateDto>()
               .ForMember(dest => dest.HeadOfDepartment, opt => opt.MapFrom(src => src.HodDetails))
               .ForMember(dest => dest.Appraiser, opt => opt.MapFrom(src => src.AppraiserDetails))
               .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());
            CreateMap<KeyResultAreaForUpdateDto, KeyResultArea>()
               .ForMember(dest => dest.HodDetails, opt => opt.MapFrom(src => src.HeadOfDepartment))
               .ForMember(dest => dest.AppraiserDetails, opt => opt.MapFrom(src => src.Appraiser));
            CreateMap<KeyResultAreaForViewDto, KeyResultArea>()
               .ForMember(dest => dest.HodDetails, opt => opt.MapFrom(src => src.HeadOfDepartment))
               .ForMember(dest => dest.AppraiserDetails, opt => opt.MapFrom(src => src.Appraiser));
            CreateMap<KeyResultArea, KeyResultAreaForViewDto>()
               .ForMember(dest => dest.HeadOfDepartment, opt => opt.MapFrom(src => src.HodDetails))
               .ForMember(dest => dest.Appraiser, opt => opt.MapFrom(src => src.AppraiserDetails));
            CreateMap<KeyResultAreaForUpdateMainDto, KeyResultAreaForUpdateDto>()
                .ForMember(dest => dest.HeadOfDepartment, to => to.MapFrom(src => src.HodDetails))
                .ForMember(dest => dest.Appraiser, to => to.MapFrom(src => src.AppraiserDetails));
            CreateMap<KeyResultAreaForUpdateDto, KeyResultAreaForUpdateMainDto>()
             .ForMember(dest => dest.HodDetails, to => to.MapFrom(src => src.HeadOfDepartment))
             .ForMember(dest => dest.AppraiserDetails, to => to.MapFrom(src => src.Appraiser));

            CreateMap<KeyOutcomeForUpdate, KeyOutcome>();
        }
    }
}
