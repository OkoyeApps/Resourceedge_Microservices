using AutoMapper;
using Resourceedge.Employee.Domain.ArchiveEntity;
using Resourceedge.Employee.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Resourceedge.Employee.Domain.Profiles
{
    public class OldEmployeeProfile : Profile
    {
        public OldEmployeeProfile()
        {
            CreateMap<OldEmployee, OldEmployeeDto>()
                .ForMember(dest => dest.Email, to => to.MapFrom(src => src.EmpEmail))
                .ForMember(dest => dest.StaffId, to => to.MapFrom(src => src.EmpStaffId))
                .ForMember(dest => dest.UnitId, to => to.MapFrom(src => src.BusinessunitId));

            CreateMap<OldEmployeeDto, OldEmployee > ()
                .ForMember(dest => dest.EmpEmail, to => to.MapFrom(src => src.Email))
                .ForMember(dest => dest.EmpStaffId, to => to.MapFrom(src => src.StaffId))
                .ForMember(dest => dest.BusinessunitId, to => to.MapFrom(src => src.UnitId));

        }
    }
}
