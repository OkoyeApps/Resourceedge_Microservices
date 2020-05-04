using AutoMapper;
using Resourceedge.Appraisal.Domain.Entities;
using Resourceedge.Appraisal.Domain.Models;

namespace Resourceedge.Appraisal.Domain.Profiles
{
    public class CoreValueProfile : Profile
    {
        public CoreValueProfile()
        {
            CreateMap<CoreValueKRAForViewDto, CoreValuesKRA>();
            CreateMap<CoreValuesKRA, CoreValueKRAForViewDto>();
            CreateMap<CoreValuesKRA, CoreValueForCreationDto>();
            CreateMap<CoreValueForCreationDto, CoreValuesKRA>();
            CreateMap<CoreValuesKRA, CoreValueForCreationDto>();
            CreateMap<CoreValueForCreationDto, CoreValuesKRA>();
        }
    }
}
