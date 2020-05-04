using System;
using System.Collections.Generic;

namespace DBIntializers.Models.Old
{
    public partial class AspNetUsers
    {
        public AspNetUsers()
        {
            AppUserClaims = new HashSet<AppUserClaims>();
            AppraisalQuestions = new HashSet<AppraisalQuestions>();
            AppraisalResultsLineManager1 = new HashSet<AppraisalResults>();
            AppraisalResultsLineManager2 = new HashSet<AppraisalResults>();
            AppraisalResultsLineManager3 = new HashSet<AppraisalResults>();
            AspNetUserClaimsAppUser = new HashSet<AspNetUserClaims>();
            AspNetUserClaimsUser = new HashSet<AspNetUserClaims>();
            AspNetUserLoginsAppUser = new HashSet<AspNetUserLogins>();
            AspNetUserLoginsUser = new HashSet<AspNetUserLogins>();
            AspNetUserRoles = new HashSet<AspNetUserRoles>();
            ConfiguredDefaultManagersLineManager1 = new HashSet<ConfiguredDefaultManagers>();
            ConfiguredDefaultManagersLineManager2 = new HashSet<ConfiguredDefaultManagers>();
            ConfiguredDefaultManagersUser = new HashSet<ConfiguredDefaultManagers>();
            EmployeeConfigurations = new HashSet<EmployeeConfigurations>();
            EmployeeLeaves = new HashSet<EmployeeLeaves>();
            EmployeePromotions = new HashSet<EmployeePromotions>();
            EmployeeSkills = new HashSet<EmployeeSkills>();
            EmployeeTeams = new HashSet<EmployeeTeams>();
            EmployeeUnitDepartments = new HashSet<EmployeeUnitDepartments>();
            EpiresultAreas = new HashSet<EpiresultAreas>();
            LeaveRequestsHr = new HashSet<LeaveRequests>();
            LeaveRequestsRepmang = new HashSet<LeaveRequests>();
            LeaveRequestsUser = new HashSet<LeaveRequests>();
            LineManager1 = new HashSet<LineManager1>();
            LineManager2 = new HashSet<LineManager2>();
            PersonalSkills = new HashSet<PersonalSkills>();
            Questions = new HashSet<Questions>();
            Recommendations = new HashSet<Recommendations>();
            RequestAgreements = new HashSet<RequestAgreements>();
            SupervisorEmployees = new HashSet<SupervisorEmployees>();
            TeamHeads = new HashSet<TeamHeads>();
            TrackingsCreated = new HashSet<Trackings>();
            TrackingsDeleted = new HashSet<Trackings>();
            TrackingsModified = new HashSet<Trackings>();
            TrackingsUser = new HashSet<Trackings>();
        }

        public string Id { get; set; }
        public string EmpRole { get; set; }
        public string UserStatus { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserfullName { get; set; }
        public int? GroupId { get; set; }
        public int? SubGroupId { get; set; }
        public int? LocationId { get; set; }
        public string BusinessunitId { get; set; }
        public string DepartmentId { get; set; }
        public string EmployeeId { get; set; }
        public string ModeofEntry { get; set; }
        public string EntryComments { get; set; }
        public DateTime? SelectedDate { get; set; }
        public string Candidatereferredby { get; set; }
        public int? JobtitleId { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? Isactive { get; set; }
        public bool? IsDefault { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTime? LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string UserName { get; set; }

        public virtual Groups Group { get; set; }
        public virtual SubGroups SubGroup { get; set; }
        public virtual ICollection<AppUserClaims> AppUserClaims { get; set; }
        public virtual ICollection<AppraisalQuestions> AppraisalQuestions { get; set; }
        public virtual ICollection<AppraisalResults> AppraisalResultsLineManager1 { get; set; }
        public virtual ICollection<AppraisalResults> AppraisalResultsLineManager2 { get; set; }
        public virtual ICollection<AppraisalResults> AppraisalResultsLineManager3 { get; set; }
        public virtual ICollection<AspNetUserClaims> AspNetUserClaimsAppUser { get; set; }
        public virtual ICollection<AspNetUserClaims> AspNetUserClaimsUser { get; set; }
        public virtual ICollection<AspNetUserLogins> AspNetUserLoginsAppUser { get; set; }
        public virtual ICollection<AspNetUserLogins> AspNetUserLoginsUser { get; set; }
        public virtual ICollection<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual ICollection<ConfiguredDefaultManagers> ConfiguredDefaultManagersLineManager1 { get; set; }
        public virtual ICollection<ConfiguredDefaultManagers> ConfiguredDefaultManagersLineManager2 { get; set; }
        public virtual ICollection<ConfiguredDefaultManagers> ConfiguredDefaultManagersUser { get; set; }
        public virtual ICollection<EmployeeConfigurations> EmployeeConfigurations { get; set; }
        public virtual ICollection<EmployeeLeaves> EmployeeLeaves { get; set; }
        public virtual ICollection<EmployeePromotions> EmployeePromotions { get; set; }
        public virtual ICollection<EmployeeSkills> EmployeeSkills { get; set; }
        public virtual ICollection<EmployeeTeams> EmployeeTeams { get; set; }
        public virtual ICollection<EmployeeUnitDepartments> EmployeeUnitDepartments { get; set; }
        public virtual ICollection<EpiresultAreas> EpiresultAreas { get; set; }
        public virtual ICollection<LeaveRequests> LeaveRequestsHr { get; set; }
        public virtual ICollection<LeaveRequests> LeaveRequestsRepmang { get; set; }
        public virtual ICollection<LeaveRequests> LeaveRequestsUser { get; set; }
        public virtual ICollection<LineManager1> LineManager1 { get; set; }
        public virtual ICollection<LineManager2> LineManager2 { get; set; }
        public virtual ICollection<PersonalSkills> PersonalSkills { get; set; }
        public virtual ICollection<Questions> Questions { get; set; }
        public virtual ICollection<Recommendations> Recommendations { get; set; }
        public virtual ICollection<RequestAgreements> RequestAgreements { get; set; }
        public virtual ICollection<SupervisorEmployees> SupervisorEmployees { get; set; }
        public virtual ICollection<TeamHeads> TeamHeads { get; set; }
        public virtual ICollection<Trackings> TrackingsCreated { get; set; }
        public virtual ICollection<Trackings> TrackingsDeleted { get; set; }
        public virtual ICollection<Trackings> TrackingsModified { get; set; }
        public virtual ICollection<Trackings> TrackingsUser { get; set; }
    }
}
