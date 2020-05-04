using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class Groups
    {
        public Groups()
        {
            AdditionalDetails = new HashSet<AdditionalDetails>();
            AgreementTypes = new HashSet<AgreementTypes>();
            AppUserClaims = new HashSet<AppUserClaims>();
            AppraisalInitializations = new HashSet<AppraisalInitializations>();
            AppraisalResults = new HashSet<AppraisalResults>();
            AspNetRoles = new HashSet<AspNetRoles>();
            AspNetUserRoles = new HashSet<AspNetUserRoles>();
            AspNetUsers = new HashSet<AspNetUsers>();
            Assets = new HashSet<Assets>();
            Birthdays = new HashSet<Birthdays>();
            ConfiguredDefaultManagers = new HashSet<ConfiguredDefaultManagers>();
            Contacts = new HashSet<Contacts>();
            CooperateCards = new HashSet<CooperateCards>();
            DepartmentalSkills = new HashSet<DepartmentalSkills>();
            Departments = new HashSet<Departments>();
            Dependencies = new HashSet<Dependencies>();
            Disabilities = new HashSet<Disabilities>();
            DisciplinaryIncidents = new HashSet<DisciplinaryIncidents>();
            Documents = new HashSet<Documents>();
            Educations = new HashSet<Educations>();
            EmailConfigurations = new HashSet<EmailConfigurations>();
            EmployeeConfigurations = new HashSet<EmployeeConfigurations>();
            EmployeeLeaveByLevels = new HashSet<EmployeeLeaveByLevels>();
            EmployeeLeaves = new HashSet<EmployeeLeaves>();
            EmployeePromotions = new HashSet<EmployeePromotions>();
            Employees = new HashSet<Employees>();
            EpiresultAreas = new HashSet<EpiresultAreas>();
            Experiences = new HashSet<Experiences>();
            GeneralQuestions = new HashSet<GeneralQuestions>();
            GroupQuestionClassifiers = new HashSet<GroupQuestionClassifiers>();
            IdentityCodes = new HashSet<IdentityCodes>();
            JobHistories = new HashSet<JobHistories>();
            Jobtitles = new HashSet<Jobtitles>();
            LeaveRequests = new HashSet<LeaveRequests>();
            Levels = new HashSet<Levels>();
            LineManager1 = new HashSet<LineManager1>();
            LineManager2 = new HashSet<LineManager2>();
            Locations = new HashSet<Locations>();
            MedicalClaims = new HashSet<MedicalClaims>();
            PersonalSkills = new HashSet<PersonalSkills>();
            Personals = new HashSet<Personals>();
            PromotionClassifications = new HashSet<PromotionClassifications>();
            Promotions = new HashSet<Promotions>();
            Questions = new HashSet<Questions>();
            Recommendations = new HashSet<Recommendations>();
            ReportManagers = new HashSet<ReportManagers>();
            RequestAgreements = new HashSet<RequestAgreements>();
            Requisitions = new HashSet<Requisitions>();
            SubGroups = new HashSet<SubGroups>();
            SubscribedAppraisals = new HashSet<SubscribedAppraisals>();
            SupervisorEmployees = new HashSet<SupervisorEmployees>();
            SystemAdmins = new HashSet<SystemAdmins>();
            TeamHeads = new HashSet<TeamHeads>();
            Teams = new HashSet<Teams>();
            Trackings = new HashSet<Trackings>();
            TrainingAndCertifications = new HashSet<TrainingAndCertifications>();
            Visas = new HashSet<Visas>();
        }

        public int Id { get; set; }
        public string GroupName { get; set; }
        public string Descriptions { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        public virtual ICollection<AdditionalDetails> AdditionalDetails { get; set; }
        public virtual ICollection<AgreementTypes> AgreementTypes { get; set; }
        public virtual ICollection<AppUserClaims> AppUserClaims { get; set; }
        public virtual ICollection<AppraisalInitializations> AppraisalInitializations { get; set; }
        public virtual ICollection<AppraisalResults> AppraisalResults { get; set; }
        public virtual ICollection<AspNetRoles> AspNetRoles { get; set; }
        public virtual ICollection<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual ICollection<AspNetUsers> AspNetUsers { get; set; }
        public virtual ICollection<Assets> Assets { get; set; }
        public virtual ICollection<Birthdays> Birthdays { get; set; }
        public virtual ICollection<ConfiguredDefaultManagers> ConfiguredDefaultManagers { get; set; }
        public virtual ICollection<Contacts> Contacts { get; set; }
        public virtual ICollection<CooperateCards> CooperateCards { get; set; }
        public virtual ICollection<DepartmentalSkills> DepartmentalSkills { get; set; }
        public virtual ICollection<Departments> Departments { get; set; }
        public virtual ICollection<Dependencies> Dependencies { get; set; }
        public virtual ICollection<Disabilities> Disabilities { get; set; }
        public virtual ICollection<DisciplinaryIncidents> DisciplinaryIncidents { get; set; }
        public virtual ICollection<Documents> Documents { get; set; }
        public virtual ICollection<Educations> Educations { get; set; }
        public virtual ICollection<EmailConfigurations> EmailConfigurations { get; set; }
        public virtual ICollection<EmployeeConfigurations> EmployeeConfigurations { get; set; }
        public virtual ICollection<EmployeeLeaveByLevels> EmployeeLeaveByLevels { get; set; }
        public virtual ICollection<EmployeeLeaves> EmployeeLeaves { get; set; }
        public virtual ICollection<EmployeePromotions> EmployeePromotions { get; set; }
        public virtual ICollection<Employees> Employees { get; set; }
        public virtual ICollection<EpiresultAreas> EpiresultAreas { get; set; }
        public virtual ICollection<Experiences> Experiences { get; set; }
        public virtual ICollection<GeneralQuestions> GeneralQuestions { get; set; }
        public virtual ICollection<GroupQuestionClassifiers> GroupQuestionClassifiers { get; set; }
        public virtual ICollection<IdentityCodes> IdentityCodes { get; set; }
        public virtual ICollection<JobHistories> JobHistories { get; set; }
        public virtual ICollection<Jobtitles> Jobtitles { get; set; }
        public virtual ICollection<LeaveRequests> LeaveRequests { get; set; }
        public virtual ICollection<Levels> Levels { get; set; }
        public virtual ICollection<LineManager1> LineManager1 { get; set; }
        public virtual ICollection<LineManager2> LineManager2 { get; set; }
        public virtual ICollection<Locations> Locations { get; set; }
        public virtual ICollection<MedicalClaims> MedicalClaims { get; set; }
        public virtual ICollection<PersonalSkills> PersonalSkills { get; set; }
        public virtual ICollection<Personals> Personals { get; set; }
        public virtual ICollection<PromotionClassifications> PromotionClassifications { get; set; }
        public virtual ICollection<Promotions> Promotions { get; set; }
        public virtual ICollection<Questions> Questions { get; set; }
        public virtual ICollection<Recommendations> Recommendations { get; set; }
        public virtual ICollection<ReportManagers> ReportManagers { get; set; }
        public virtual ICollection<RequestAgreements> RequestAgreements { get; set; }
        public virtual ICollection<Requisitions> Requisitions { get; set; }
        public virtual ICollection<SubGroups> SubGroups { get; set; }
        public virtual ICollection<SubscribedAppraisals> SubscribedAppraisals { get; set; }
        public virtual ICollection<SupervisorEmployees> SupervisorEmployees { get; set; }
        public virtual ICollection<SystemAdmins> SystemAdmins { get; set; }
        public virtual ICollection<TeamHeads> TeamHeads { get; set; }
        public virtual ICollection<Teams> Teams { get; set; }
        public virtual ICollection<Trackings> Trackings { get; set; }
        public virtual ICollection<TrainingAndCertifications> TrainingAndCertifications { get; set; }
        public virtual ICollection<Visas> Visas { get; set; }
    }
}
