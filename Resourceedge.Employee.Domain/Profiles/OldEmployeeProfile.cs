using AutoMapper;
using Resourceedge.Common.Archive;
using Resourceedge.Employee.Domain.Dtos;

namespace Resourceedge.Employee.Domain.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<OldEmployee, OldEmployeeDto>()
                .ForMember(dest => dest.Email, to => to.MapFrom(src => src.EmpEmail))
                .ForMember(dest => dest.StaffId, to => to.MapFrom(src => src.EmpStaffId))
                .ForMember(dest => dest.UnitId, to => to.MapFrom(src => src.BusinessunitId));

            CreateMap<OldEmployeeDto, OldEmployee>()
                .ForMember(dest => dest.EmpEmail, to => to.MapFrom(src => src.Email))
                .ForMember(dest => dest.EmpStaffId, to => to.MapFrom(src => src.StaffId))
                .ForMember(dest => dest.BusinessunitId, to => to.MapFrom(src => src.UnitId));

            CreateMap<OldEmployeeDtoForCreate, OldEmployee>()
              .ForMember(dest => dest.EmployeeId, to => to.MapFrom(src => src.Id));

            CreateMap<OldEmployee, OldEmployeeDtoForCreate>()
                .ForMember(dest => dest.Id, to => to.MapFrom(src => src.EmployeeId));

        }
    }
}
