using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class Departments
    {
        public Departments()
        {
            AppraisalConfigurations = new HashSet<AppraisalConfigurations>();
            AppraisalResults = new HashSet<AppraisalResults>();
            DepartmentalSkills = new HashSet<DepartmentalSkills>();
            DisciplinaryIncidents = new HashSet<DisciplinaryIncidents>();
            EmployeePromotions = new HashSet<EmployeePromotions>();
            EmployeeUnitDepartments = new HashSet<EmployeeUnitDepartments>();
            Employees = new HashSet<Employees>();
            GeneralQuestions = new HashSet<GeneralQuestions>();
            JobHistories = new HashSet<JobHistories>();
            LeaveRequests = new HashSet<LeaveRequests>();
            LineManager2 = new HashSet<LineManager2>();
            PersonalSkills = new HashSet<PersonalSkills>();
            ReportManagers = new HashSet<ReportManagers>();
            Requisitions = new HashSet<Requisitions>();
            Teams = new HashSet<Teams>();
        }

        public int Id { get; set; }
        public string Deptname { get; set; }
        public string Deptcode { get; set; }
        public string Descriptions { get; set; }
        public int? LocationId { get; set; }
        public int? GroupId { get; set; }
        public DateTime? Startdate { get; set; }
        public string ReportManager1 { get; set; }
        public string ReportManager2 { get; set; }
        public string Depthead { get; set; }
        public int BusinessUnitsId { get; set; }
        public bool? Primary { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? Isactive { get; set; }
        public int SubGroupId { get; set; }

        public virtual BusinessUnits BusinessUnits { get; set; }
        public virtual Groups Group { get; set; }
        public virtual Locations Location { get; set; }
        public virtual SubGroups SubGroup { get; set; }
        public virtual ICollection<AppraisalConfigurations> AppraisalConfigurations { get; set; }
        public virtual ICollection<AppraisalResults> AppraisalResults { get; set; }
        public virtual ICollection<DepartmentalSkills> DepartmentalSkills { get; set; }
        public virtual ICollection<DisciplinaryIncidents> DisciplinaryIncidents { get; set; }
        public virtual ICollection<EmployeePromotions> EmployeePromotions { get; set; }
        public virtual ICollection<EmployeeUnitDepartments> EmployeeUnitDepartments { get; set; }
        public virtual ICollection<Employees> Employees { get; set; }
        public virtual ICollection<GeneralQuestions> GeneralQuestions { get; set; }
        public virtual ICollection<JobHistories> JobHistories { get; set; }
        public virtual ICollection<LeaveRequests> LeaveRequests { get; set; }
        public virtual ICollection<LineManager2> LineManager2 { get; set; }
        public virtual ICollection<PersonalSkills> PersonalSkills { get; set; }
        public virtual ICollection<ReportManagers> ReportManagers { get; set; }
        public virtual ICollection<Requisitions> Requisitions { get; set; }
        public virtual ICollection<Teams> Teams { get; set; }
    }
}
