using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Resourceedge.Common.Archive
{
    [BsonIgnoreExtraElements]
    public class OldEmployee
    {
        public int EmployeeId { get; set; }
        public string UserId { get; set; }
        public string EmpStaffId { get; set; }
        public string EmpEmail { get; set; }
        public int EmpRoleId { get; set; }
        public int GroupId { get; set; }
        public int SubGroupId { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? DateOfJoining { get; set; }
        public DateTime? DateOfLeaving { get; set; }
        public string EmpStatusId { get; set; }
        public int BusinessunitId { get; set; }
        public int DepartmentId { get; set; }
        public int? JobTitleId { get; set; }
        public int? PositionId { get; set; }
        public string YearsExp { get; set; }
        public int? LevelId { get; set; }
        public int? LocationId { get; set; }
        public int PrefixId { get; set; }
        public string OfficeNumber { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }
        public DateTime? Createddate { get; set; }
        public DateTime? Modifieddate { get; set; }
        public bool? Isactive { get; set; }
        public bool? IsOrghead { get; set; }
        public int? ModeofEmployement { get; set; }
        public bool? IsUnithead { get; set; }
        public bool? IsDepthead { get; set; }
        public Subgroup Subgroup { get; set; }
    }
}
