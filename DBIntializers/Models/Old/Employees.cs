using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class Employees
    {
        public Employees()
        {
            AdditionalDetails = new HashSet<AdditionalDetails>();
            AppraisalQuestions = new HashSet<AppraisalQuestions>();
            Contacts = new HashSet<Contacts>();
            CooperateCards = new HashSet<CooperateCards>();
            Dependencies = new HashSet<Dependencies>();
            Disabilities = new HashSet<Disabilities>();
            Documents = new HashSet<Documents>();
            Educations = new HashSet<Educations>();
            EmployeeConfigurations = new HashSet<EmployeeConfigurations>();
            EmployeePromotions = new HashSet<EmployeePromotions>();
            EmployeeTeams = new HashSet<EmployeeTeams>();
            EmployeeUnitDepartments = new HashSet<EmployeeUnitDepartments>();
            EpiresultAreas = new HashSet<EpiresultAreas>();
            Experiences = new HashSet<Experiences>();
            JobHistories = new HashSet<JobHistories>();
            LeaveRequests = new HashSet<LeaveRequests>();
            MedicalClaims = new HashSet<MedicalClaims>();
            PersonalSkills = new HashSet<PersonalSkills>();
            Personals = new HashSet<Personals>();
            Recommendations = new HashSet<Recommendations>();
            ReportManagers = new HashSet<ReportManagers>();
            RequestAgreements = new HashSet<RequestAgreements>();
            TeamHeads = new HashSet<TeamHeads>();
            Trackings = new HashSet<Trackings>();
            TrainingAndCertifications = new HashSet<TrainingAndCertifications>();
            Visas = new HashSet<Visas>();
        }

        public int Id { get; set; }
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

        public virtual BusinessUnits Businessunit { get; set; }
        public virtual Departments Department { get; set; }
        public virtual Groups Group { get; set; }
        public virtual Jobtitles JobTitle { get; set; }
        public virtual Levels Level { get; set; }
        public virtual Locations Location { get; set; }
        public virtual Positions Position { get; set; }
        public virtual SubGroups SubGroup { get; set; }
        public virtual ICollection<AdditionalDetails> AdditionalDetails { get; set; }
        public virtual ICollection<AppraisalQuestions> AppraisalQuestions { get; set; }
        public virtual ICollection<Contacts> Contacts { get; set; }
        public virtual ICollection<CooperateCards> CooperateCards { get; set; }
        public virtual ICollection<Dependencies> Dependencies { get; set; }
        public virtual ICollection<Disabilities> Disabilities { get; set; }
        public virtual ICollection<Documents> Documents { get; set; }
        public virtual ICollection<Educations> Educations { get; set; }
        public virtual ICollection<EmployeeConfigurations> EmployeeConfigurations { get; set; }
        public virtual ICollection<EmployeePromotions> EmployeePromotions { get; set; }
        public virtual ICollection<EmployeeTeams> EmployeeTeams { get; set; }
        public virtual ICollection<EmployeeUnitDepartments> EmployeeUnitDepartments { get; set; }
        public virtual ICollection<EpiresultAreas> EpiresultAreas { get; set; }
        public virtual ICollection<Experiences> Experiences { get; set; }
        public virtual ICollection<JobHistories> JobHistories { get; set; }
        public virtual ICollection<LeaveRequests> LeaveRequests { get; set; }
        public virtual ICollection<MedicalClaims> MedicalClaims { get; set; }
        public virtual ICollection<PersonalSkills> PersonalSkills { get; set; }
        public virtual ICollection<Personals> Personals { get; set; }
        public virtual ICollection<Recommendations> Recommendations { get; set; }
        public virtual ICollection<ReportManagers> ReportManagers { get; set; }
        public virtual ICollection<RequestAgreements> RequestAgreements { get; set; }
        public virtual ICollection<TeamHeads> TeamHeads { get; set; }
        public virtual ICollection<Trackings> Trackings { get; set; }
        public virtual ICollection<TrainingAndCertifications> TrainingAndCertifications { get; set; }
        public virtual ICollection<Visas> Visas { get; set; }
    }
}
