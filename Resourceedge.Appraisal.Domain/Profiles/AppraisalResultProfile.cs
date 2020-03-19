using AutoMapper;
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
                    
        }
    }
}
