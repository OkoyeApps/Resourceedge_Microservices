using AutoMapper;
using Resourceedge.Appraisal.Domain.Entities;
using Resourceedge.Appraisal.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Resourceedge.Appraisal.Domain.Profiles
{
    public class FinalResultProfile : Profile
    {
        public FinalResultProfile()
        {
            CreateMap<FinalAppraisalResult, FinalResultDtoForView>();
            CreateMap<FinalResultDtoForView, FinalAppraisalResult>();
        }
    }
}
