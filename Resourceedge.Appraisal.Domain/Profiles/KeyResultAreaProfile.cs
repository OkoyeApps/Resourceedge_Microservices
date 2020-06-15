using AutoMapper;
using AutoMapper.QueryableExtensions;
using Resourceedge.Appraisal.Domain.Entities;
using Resourceedge.Appraisal.Domain.Models;
using System;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

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

            Func<KeyOutcomeForCreationDto, KeyOutcome, object> convert = (src, dest) =>
            {
                var regex = new Regex("(continuously)|(yearly)|(annually)|(weekly)|(quaterly)|(continuous)|(ongoing)");
                if(src.TimeLimit is null)
                {
                    return "continuously";
                }
                var passedRegex = regex.IsMatch((src.TimeLimit.ToLower()));
                if (passedRegex)
                {
                    return src.TimeLimit;
                }
                var posixTime = DateTime.SpecifyKind(new DateTime(1970, 1, 1), DateTimeKind.Utc);
                var isdouble = double.TryParse(src.TimeLimit, out double parsedDate);
                if (isdouble)
                {
                    var time = posixTime.AddMilliseconds(double.Parse(src.TimeLimit));
                    return time;
                }
                return "continuously";
            };
            CreateMap<KeyOutcomeForCreationDto, KeyOutcome>()
                .ForMember(dest => dest.TimeLimit, to => to.MapFrom(convert));
       
        }
    }
}
