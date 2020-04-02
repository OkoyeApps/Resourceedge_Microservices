using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class Locations
    {
        public Locations()
        {
            AdditionalDetails = new HashSet<AdditionalDetails>();
            AppUserClaims = new HashSet<AppUserClaims>();
            AspNetRoles = new HashSet<AspNetRoles>();
            AspNetUserRoles = new HashSet<AspNetUserRoles>();
            Assets = new HashSet<Assets>();
            Birthdays = new HashSet<Birthdays>();
            BusinessUnits = new HashSet<BusinessUnits>();
            ConfiguredDefaultManagers = new HashSet<ConfiguredDefaultManagers>();
            Contacts = new HashSet<Contacts>();
            CooperateCards = new HashSet<CooperateCards>();
            Departments = new HashSet<Departments>();
            Dependencies = new HashSet<Dependencies>();
            Disabilities = new HashSet<Disabilities>();
            DisciplinaryIncidents = new HashSet<DisciplinaryIncidents>();
            Documents = new HashSet<Documents>();
            Educations = new HashSet<Educations>();
            EmailConfigurations = new HashSet<EmailConfigurations>();
            EmployeeConfigurations = new HashSet<EmployeeConfigurations>();
            EmployeeLeaves = new HashSet<EmployeeLeaves>();
            EmployeeUnitDepartments = new HashSet<EmployeeUnitDepartments>();
            Employees = new HashSet<Employees>();
            EpiresultAreas = new HashSet<EpiresultAreas>();
            Experiences = new HashSet<Experiences>();
            GeneralQuestions = new HashSet<GeneralQuestions>();
            JobHistories = new HashSet<JobHistories>();
            Jobtitles = new HashSet<Jobtitles>();
            LeaveRequests = new HashSet<LeaveRequests>();
            LineManager1 = new HashSet<LineManager1>();
            LineManager2 = new HashSet<LineManager2>();
            LocationHeadUnits = new HashSet<LocationHeadUnits>();
            MedicalClaims = new HashSet<MedicalClaims>();
            Personals = new HashSet<Personals>();
            Questions = new HashSet<Questions>();
            ReportManagers = new HashSet<ReportManagers>();
            Requisitions = new HashSet<Requisitions>();
            SupervisorEmployees = new HashSet<SupervisorEmployees>();
            SystemAdmins = new HashSet<SystemAdmins>();
            TeamHeads = new HashSet<TeamHeads>();
            Teams = new HashSet<Teams>();
            TrainingAndCertifications = new HashSet<TrainingAndCertifications>();
            Visas = new HashSet<Visas>();
        }

        public int Id { get; set; }
        public int GroupId { get; set; }
        public int SubGroupId { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string LocationHead1 { get; set; }
        public string LocationHead2 { get; set; }
        public string LocationHead3 { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual Groups Group { get; set; }
        public virtual SubGroups SubGroup { get; set; }
        public virtual ICollection<AdditionalDetails> AdditionalDetails { get; set; }
        public virtual ICollection<AppUserClaims> AppUserClaims { get; set; }
        public virtual ICollection<AspNetRoles> AspNetRoles { get; set; }
        public virtual ICollection<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual ICollection<Assets> Assets { get; set; }
        public virtual ICollection<Birthdays> Birthdays { get; set; }
        public virtual ICollection<BusinessUnits> BusinessUnits { get; set; }
        public virtual ICollection<ConfiguredDefaultManagers> ConfiguredDefaultManagers { get; set; }
        public virtual ICollection<Contacts> Contacts { get; set; }
        public virtual ICollection<CooperateCards> CooperateCards { get; set; }
        public virtual ICollection<Departments> Departments { get; set; }
        public virtual ICollection<Dependencies> Dependencies { get; set; }
        public virtual ICollection<Disabilities> Disabilities { get; set; }
        public virtual ICollection<DisciplinaryIncidents> DisciplinaryIncidents { get; set; }
        public virtual ICollection<Documents> Documents { get; set; }
        public virtual ICollection<Educations> Educations { get; set; }
        public virtual ICollection<EmailConfigurations> EmailConfigurations { get; set; }
        public virtual ICollection<EmployeeConfigurations> EmployeeConfigurations { get; set; }
        public virtual ICollection<EmployeeLeaves> EmployeeLeaves { get; set; }
        public virtual ICollection<EmployeeUnitDepartments> EmployeeUnitDepartments { get; set; }
        public virtual ICollection<Employees> Employees { get; set; }
        public virtual ICollection<EpiresultAreas> EpiresultAreas { get; set; }
        public virtual ICollection<Experiences> Experiences { get; set; }
        public virtual ICollection<GeneralQuestions> GeneralQuestions { get; set; }
        public virtual ICollection<JobHistories> JobHistories { get; set; }
        public virtual ICollection<Jobtitles> Jobtitles { get; set; }
        public virtual ICollection<LeaveRequests> LeaveRequests { get; set; }
        public virtual ICollection<LineManager1> LineManager1 { get; set; }
        public virtual ICollection<LineManager2> LineManager2 { get; set; }
        public virtual ICollection<LocationHeadUnits> LocationHeadUnits { get; set; }
        public virtual ICollection<MedicalClaims> MedicalClaims { get; set; }
        public virtual ICollection<Personals> Personals { get; set; }
        public virtual ICollection<Questions> Questions { get; set; }
        public virtual ICollection<ReportManagers> ReportManagers { get; set; }
        public virtual ICollection<Requisitions> Requisitions { get; set; }
        public virtual ICollection<SupervisorEmployees> SupervisorEmployees { get; set; }
        public virtual ICollection<SystemAdmins> SystemAdmins { get; set; }
        public virtual ICollection<TeamHeads> TeamHeads { get; set; }
        public virtual ICollection<Teams> Teams { get; set; }
        public virtual ICollection<TrainingAndCertifications> TrainingAndCertifications { get; set; }
        public virtual ICollection<Visas> Visas { get; set; }
    }
}
