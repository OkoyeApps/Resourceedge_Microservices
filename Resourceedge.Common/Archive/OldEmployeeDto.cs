using System;
using System.Collections.Generic;
using System.Text;

namespace Resourceedge.Common.Archive
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
}
