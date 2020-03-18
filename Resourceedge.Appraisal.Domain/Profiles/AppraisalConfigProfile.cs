using AutoMapper;
using Resourceedge.Appraisal.Domain.Entities;
using Resourceedge.Appraisal.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Resourceedge.Appraisal.Domain.Profiles
{
    public class AppraisalConfigProfile : Profile
    {
        public AppraisalConfigProfile()
        {
            CreateMap<AppraisalConfigForCreationDto, AppraisalConfig>()
                .ForMember(dest => dest.TotalCycle, to => to.MapFrom(src => src.Total));
            CreateMap<AppraisalConfig, AppraisalConfigForCreationDto>()
                .ForMember(dest => dest.Total, to => to.MapFrom(src => src.TotalCycle));
        }
    }
}
