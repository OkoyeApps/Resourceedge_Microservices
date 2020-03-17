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
            CreateMap<KeyResultAreas, KeyResultAreaDto>();
        }
    }
}
