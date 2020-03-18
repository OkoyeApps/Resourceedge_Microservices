using AutoMapper;
using Resourceedge.Appraisal.Domain.Entities;
using Resourceedge.Appraisal.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Resourceedge.Appraisal.Domain.Profiles
{
    class KeyResultAreaProfile : Profile
    {
        public KeyResultAreaProfile()
        {
            CreateMap<KeyResultArea, KeyResultAreaForUpdateDto>()
               .ForMember(dest => dest.HeadOfDepartment, opt => opt.MapFrom(src => src.HodDetails))
               .ForMember(dest => dest.Appraiser, opt => opt.MapFrom(src => src.AppraiserDetails));

        }
    }
}
