using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class BusinessUnits
    {
        public BusinessUnits()
        {
            AppraisalConfigurations = new HashSet<AppraisalConfigurations>();
            AppraisalResults = new HashSet<AppraisalResults>();
            DepartmentalSkills = new HashSet<DepartmentalSkills>();
            Departments = new HashSet<Departments>();
            DisciplinaryIncidents = new HashSet<DisciplinaryIncidents>();
            EmployeePromotions = new HashSet<EmployeePromotions>();
            EmployeeUnitDepartments = new HashSet<EmployeeUnitDepartments>();
            Employees = new HashSet<Employees>();
            GeneralQuestions = new HashSet<GeneralQuestions>();
            LeaveManagements = new HashSet<LeaveManagements>();
            LeaveRequests = new HashSet<LeaveRequests>();
            LineManager2 = new HashSet<LineManager2>();
            LocationHeadUnits = new HashSet<LocationHeadUnits>();
            PersonalSkills = new HashSet<PersonalSkills>();
            Questions = new HashSet<Questions>();
            ReportManagers = new HashSet<ReportManagers>();
            Requisitions = new HashSet<Requisitions>();
            Teams = new HashSet<Teams>();
        }

        public int Id { get; set; }
        public int GroupId { get; set; }
        public int SubGroupId { get; set; }
        public string Unitname { get; set; }
        public string Unitcode { get; set; }
        public string Descriptions { get; set; }
        public DateTime? Startdate { get; set; }
        public string ReportManager1 { get; set; }
        public string ReportManager2 { get; set; }
        public string ReportManager3 { get; set; }
        public int? LocationId { get; set; }
        public bool? Primary { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }
        public DateTime? Createddate { get; set; }
        public DateTime? Modifieddate { get; set; }
        public bool? Isactive { get; set; }

        public virtual Locations Location { get; set; }
        public virtual SubGroups SubGroup { get; set; }
        public virtual ICollection<AppraisalConfigurations> AppraisalConfigurations { get; set; }
        public virtual ICollection<AppraisalResults> AppraisalResults { get; set; }
        public virtual ICollection<DepartmentalSkills> DepartmentalSkills { get; set; }
        public virtual ICollection<Departments> Departments { get; set; }
        public virtual ICollection<DisciplinaryIncidents> DisciplinaryIncidents { get; set; }
        public virtual ICollection<EmployeePromotions> EmployeePromotions { get; set; }
        public virtual ICollection<EmployeeUnitDepartments> EmployeeUnitDepartments { get; set; }
        public virtual ICollection<Employees> Employees { get; set; }
        public virtual ICollection<GeneralQuestions> GeneralQuestions { get; set; }
        public virtual ICollection<LeaveManagements> LeaveManagements { get; set; }
        public virtual ICollection<LeaveRequests> LeaveRequests { get; set; }
        public virtual ICollection<LineManager2> LineManager2 { get; set; }
        public virtual ICollection<LocationHeadUnits> LocationHeadUnits { get; set; }
        public virtual ICollection<PersonalSkills> PersonalSkills { get; set; }
        public virtual ICollection<Questions> Questions { get; set; }
        public virtual ICollection<ReportManagers> ReportManagers { get; set; }
        public virtual ICollection<Requisitions> Requisitions { get; set; }
        public virtual ICollection<Teams> Teams { get; set; }
    }
}
