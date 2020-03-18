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

    public class AppraisalCycleClassProfile : Profile
    {
        public AppraisalCycleClassProfile()
        {
            CreateMap<AppraisalCycleClass, AppraisalCycle>().ForMember(dest => dest.StartDate, to => to.MapFrom(src => src.Start))
                .ForMember(dest =>dest.StopDate, to => to.MapFrom(src => src.Stop));
            CreateMap<AppraisalCycle, AppraisalCycleClass>().ForMember(dest => dest.Start, to => to.MapFrom(src => src.StartDate))
                  .ForMember(dest => dest.Stop, to => to.MapFrom(src => src.StartDate));
        }
    }
}
