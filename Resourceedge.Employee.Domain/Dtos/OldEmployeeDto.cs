using Resourceedge.Employee.Domain.ArchiveEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Resourceedge.Employee.Domain.Dtos
{
    public class OldEmployeeDto 
    {
        public int EmployeeId { get; set; }
        public string UserId { get; set; }
        public string StaffId { get; set; }
        public string Email { get; set; }
        public int SubGroupId { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public int UnitId { get; set; }
        public int DepartmentId { get; set; }
        public bool? Isactive { get; set; }
        public Subgroup Subgroup { get; set; }
    }

    public class EmployeeResourceParameter
    {
        const int maxPageSize = 20;
        public string SearchQuery { get; set; }
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 10;
        public int PageSize
        {
            get => _pageSize;

            set => _pageSize = (value > maxPageSize) ? maxPageSize : value;
        }

        public string OrderBy { get; set; }
        public string Fields { get; set; }
    }
}
