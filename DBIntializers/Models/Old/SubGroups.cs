using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class SubGroups
    {
        public SubGroups()
        {
            AppUserClaims = new HashSet<AppUserClaims>();
            AppraisalQuestions = new HashSet<AppraisalQuestions>();
            AppraisalResults = new HashSet<AppraisalResults>();
            AspNetRoles = new HashSet<AspNetRoles>();
            AspNetUserRoles = new HashSet<AspNetUserRoles>();
            AspNetUsers = new HashSet<AspNetUsers>();
            AssetCategories = new HashSet<AssetCategories>();
            Assets = new HashSet<Assets>();
            Birthdays = new HashSet<Birthdays>();
            BusinessUnits = new HashSet<BusinessUnits>();
            Candidates = new HashSet<Candidates>();
            ConfiguredDefaultManagers = new HashSet<ConfiguredDefaultManagers>();
            DepartmentalSkills = new HashSet<DepartmentalSkills>();
            Departments = new HashSet<Departments>();
            DisciplinaryIncidents = new HashSet<DisciplinaryIncidents>();
            EmailConfigurations = new HashSet<EmailConfigurations>();
            EmployeeConfigurations = new HashSet<EmployeeConfigurations>();
            EmployeeLeaves = new HashSet<EmployeeLeaves>();
            EmployeePromotions = new HashSet<EmployeePromotions>();
            EmployeeUnitDepartments = new HashSet<EmployeeUnitDepartments>();
            Employees = new HashSet<Employees>();
            EpiresultAreas = new HashSet<EpiresultAreas>();
            GeneralQuestions = new HashSet<GeneralQuestions>();
            IdentityCodes = new HashSet<IdentityCodes>();
            Jobtitles = new HashSet<Jobtitles>();
            LeaveRequests = new HashSet<LeaveRequests>();
            Levels = new HashSet<Levels>();
            LineManager1 = new HashSet<LineManager1>();
            LineManager2 = new HashSet<LineManager2>();
            LocationHeadUnits = new HashSet<LocationHeadUnits>();
            Locations = new HashSet<Locations>();
            PromotionClassifications = new HashSet<PromotionClassifications>();
            Promotions = new HashSet<Promotions>();
            Questions = new HashSet<Questions>();
            Recommendations = new HashSet<Recommendations>();
            ReportManagers = new HashSet<ReportManagers>();
            RequestAgreements = new HashSet<RequestAgreements>();
            Requisitions = new HashSet<Requisitions>();
            SubscribedAppraisals = new HashSet<SubscribedAppraisals>();
            SupervisorEmployees = new HashSet<SupervisorEmployees>();
            SystemAdmins = new HashSet<SystemAdmins>();
            TeamHeads = new HashSet<TeamHeads>();
            Teams = new HashSet<Teams>();
            Trackings = new HashSet<Trackings>();
        }

        public int Id { get; set; }
        public int GroupId { get; set; }
        public string Name { get; set; }
        public string Descriptions { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        public virtual Groups Group { get; set; }
        public virtual ICollection<AppUserClaims> AppUserClaims { get; set; }
        public virtual ICollection<AppraisalQuestions> AppraisalQuestions { get; set; }
        public virtual ICollection<AppraisalResults> AppraisalResults { get; set; }
        public virtual ICollection<AspNetRoles> AspNetRoles { get; set; }
        public virtual ICollection<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual ICollection<AspNetUsers> AspNetUsers { get; set; }
        public virtual ICollection<AssetCategories> AssetCategories { get; set; }
        public virtual ICollection<Assets> Assets { get; set; }
        public virtual ICollection<Birthdays> Birthdays { get; set; }
        public virtual ICollection<BusinessUnits> BusinessUnits { get; set; }
        public virtual ICollection<Candidates> Candidates { get; set; }
        public virtual ICollection<ConfiguredDefaultManagers> ConfiguredDefaultManagers { get; set; }
        public virtual ICollection<DepartmentalSkills> DepartmentalSkills { get; set; }
        public virtual ICollection<Departments> Departments { get; set; }
        public virtual ICollection<DisciplinaryIncidents> DisciplinaryIncidents { get; set; }
        public virtual ICollection<EmailConfigurations> EmailConfigurations { get; set; }
        public virtual ICollection<EmployeeConfigurations> EmployeeConfigurations { get; set; }
        public virtual ICollection<EmployeeLeaves> EmployeeLeaves { get; set; }
        public virtual ICollection<EmployeePromotions> EmployeePromotions { get; set; }
        public virtual ICollection<EmployeeUnitDepartments> EmployeeUnitDepartments { get; set; }
        public virtual ICollection<Employees> Employees { get; set; }
        public virtual ICollection<EpiresultAreas> EpiresultAreas { get; set; }
        public virtual ICollection<GeneralQuestions> GeneralQuestions { get; set; }
        public virtual ICollection<IdentityCodes> IdentityCodes { get; set; }
        public virtual ICollection<Jobtitles> Jobtitles { get; set; }
        public virtual ICollection<LeaveRequests> LeaveRequests { get; set; }
        public virtual ICollection<Levels> Levels { get; set; }
        public virtual ICollection<LineManager1> LineManager1 { get; set; }
        public virtual ICollection<LineManager2> LineManager2 { get; set; }
        public virtual ICollection<LocationHeadUnits> LocationHeadUnits { get; set; }
        public virtual ICollection<Locations> Locations { get; set; }
        public virtual ICollection<PromotionClassifications> PromotionClassifications { get; set; }
        public virtual ICollection<Promotions> Promotions { get; set; }
        public virtual ICollection<Questions> Questions { get; set; }
        public virtual ICollection<Recommendations> Recommendations { get; set; }
        public virtual ICollection<ReportManagers> ReportManagers { get; set; }
        public virtual ICollection<RequestAgreements> RequestAgreements { get; set; }
        public virtual ICollection<Requisitions> Requisitions { get; set; }
        public virtual ICollection<SubscribedAppraisals> SubscribedAppraisals { get; set; }
        public virtual ICollection<SupervisorEmployees> SupervisorEmployees { get; set; }
        public virtual ICollection<SystemAdmins> SystemAdmins { get; set; }
        public virtual ICollection<TeamHeads> TeamHeads { get; set; }
        public virtual ICollection<Teams> Teams { get; set; }
        public virtual ICollection<Trackings> Trackings { get; set; }
    }
}
