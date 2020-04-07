using AutoMapper;
using MongoDB.Bson;
using Resourceedge.Appraisal.Domain.Entities;
using Resourceedge.Appraisal.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Resourceedge.Appraisal.Domain.Profiles
{
    class AppraisalResultProfile : Profile
    {
        public AppraisalResultProfile()
        {
            CreateMap<AppraisalResultForCreationDto, AppraisalResult>();
            CreateMap<AppraisalResult, AppraisalResultForCreationDto>();
            CreateMap<AppraisalKeyOutcome, AppraisalKeyOutcomeDto>();
            CreateMap<AppraisalKeyOutcomeDto, AppraisalKeyOutcome>();

            CreateMap<AppraisalResultForCreationDtoString, AppraisalResultForCreationDto>()
                .ForMember(des => des.AppraisalConfigId, opt => opt.MapFrom(src => ObjectId.Parse(src.AppraisalConfigId)))
                .ForMember(des => des.AppraisalCycleId, opt => opt.MapFrom(src => ObjectId.Parse(src.AppraisalCycleId)))
                .ForMember(des => des.KeyResultAreaId, opt => opt.MapFrom(src => ObjectId.Parse(src.KeyResultAreaId)))
                .ForMember(des => des.KeyOutcomeScore, opt => opt.MapFrom(src => src.KeyOutcomeScore));
            CreateMap<AppraisalResultForCreationDto, AppraisalResultForCreationDtoString>()
                .ForMember(des => des.AppraisalConfigId, opt => opt.MapFrom(src => src.KeyOutcomeScore.ToString()))
                .ForMember(des => des.AppraisalCycleId, opt => opt.MapFrom(src => src.AppraisalCycleId.ToString()))
                .ForMember(des => des.KeyResultAreaId, opt => opt.MapFrom(src => src.KeyResultAreaId.ToString()))
                .ForMember(des => des.KeyOutcomeScore, opt => opt.MapFrom(src => src.KeyOutcomeScore));
            CreateMap<AppraisalKeyOutcomeDtoString, AppraisalKeyOutcomeDto>()
                .ForMember(des => des.EmployeeScore, opt => opt.MapFrom(src => src.EmployeeScore))
                .ForMember(des => des.KeyOutcomeId, opt => opt.MapFrom(src => ObjectId.Parse(src.KeyOutcomeId)));
            CreateMap< AppraisalKeyOutcomeDto, AppraisalKeyOutcomeDtoString>()
                .ForMember(des => des.EmployeeScore, opt => opt.MapFrom(src => src.EmployeeScore))
                .ForMember(des => des.KeyOutcomeId, opt => opt.MapFrom(src => src.KeyOutcomeId.ToString()));
        }
    }
}
