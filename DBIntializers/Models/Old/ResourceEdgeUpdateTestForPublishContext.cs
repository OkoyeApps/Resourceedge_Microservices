using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DBIntializers.Models.Old
{
    public partial class ResourceEdgeUpdateTestForPublishContext : DbContext
    {
        public ResourceEdgeUpdateTestForPublishContext()
        {
        }

        public ResourceEdgeUpdateTestForPublishContext(DbContextOptions<ResourceEdgeUpdateTestForPublishContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ActivityLogs> ActivityLogs { get; set; }
        public virtual DbSet<AdditionalDetails> AdditionalDetails { get; set; }
        public virtual DbSet<AggregatedCounter> AggregatedCounter { get; set; }
        public virtual DbSet<AgreementTypes> AgreementTypes { get; set; }
        public virtual DbSet<AppUserClaims> AppUserClaims { get; set; }
        public virtual DbSet<AppraisalConfigurations> AppraisalConfigurations { get; set; }
        public virtual DbSet<AppraisalCriterias> AppraisalCriterias { get; set; }
        public virtual DbSet<AppraisalInitializations> AppraisalInitializations { get; set; }
        public virtual DbSet<AppraisalModes> AppraisalModes { get; set; }
        public virtual DbSet<AppraisalPeriods> AppraisalPeriods { get; set; }
        public virtual DbSet<AppraisalQuestions> AppraisalQuestions { get; set; }
        public virtual DbSet<AppraisalRatings> AppraisalRatings { get; set; }
        public virtual DbSet<AppraisalResults> AppraisalResults { get; set; }
        public virtual DbSet<AppraisalStatus> AppraisalStatus { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<AssetCategories> AssetCategories { get; set; }
        public virtual DbSet<Assets> Assets { get; set; }
        public virtual DbSet<Birthdays> Birthdays { get; set; }
        public virtual DbSet<BusinessUnits> BusinessUnits { get; set; }
        public virtual DbSet<CandidateInterviews> CandidateInterviews { get; set; }
        public virtual DbSet<CandidateStatus> CandidateStatus { get; set; }
        public virtual DbSet<CandidateWorkDetails> CandidateWorkDetails { get; set; }
        public virtual DbSet<Candidates> Candidates { get; set; }
        public virtual DbSet<CareerPaths> CareerPaths { get; set; }
        public virtual DbSet<Careers> Careers { get; set; }
        public virtual DbSet<ConfiguredDefaultManagers> ConfiguredDefaultManagers { get; set; }
        public virtual DbSet<Consequences> Consequences { get; set; }
        public virtual DbSet<Contacts> Contacts { get; set; }
        public virtual DbSet<CooperateCards> CooperateCards { get; set; }
        public virtual DbSet<Counter> Counter { get; set; }
        public virtual DbSet<DepartmentalSkills> DepartmentalSkills { get; set; }
        public virtual DbSet<Departments> Departments { get; set; }
        public virtual DbSet<Dependencies> Dependencies { get; set; }
        public virtual DbSet<DependencyRelations> DependencyRelations { get; set; }
        public virtual DbSet<Disabilities> Disabilities { get; set; }
        public virtual DbSet<DisciplinaryIncidents> DisciplinaryIncidents { get; set; }
        public virtual DbSet<Documents> Documents { get; set; }
        public virtual DbSet<EducationLevels> EducationLevels { get; set; }
        public virtual DbSet<Educations> Educations { get; set; }
        public virtual DbSet<EmailConfigurations> EmailConfigurations { get; set; }
        public virtual DbSet<EmpHolidays> EmpHolidays { get; set; }
        public virtual DbSet<EmpPayrolls> EmpPayrolls { get; set; }
        public virtual DbSet<EmployeeConfigurations> EmployeeConfigurations { get; set; }
        public virtual DbSet<EmployeeLeaveByLevels> EmployeeLeaveByLevels { get; set; }
        public virtual DbSet<EmployeeLeaveTypes> EmployeeLeaveTypes { get; set; }
        public virtual DbSet<EmployeeLeaves> EmployeeLeaves { get; set; }
        public virtual DbSet<EmployeePromotions> EmployeePromotions { get; set; }
        public virtual DbSet<EmployeeSkills> EmployeeSkills { get; set; }
        public virtual DbSet<EmployeeTeams> EmployeeTeams { get; set; }
        public virtual DbSet<EmployeeUnitDepartments> EmployeeUnitDepartments { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<EmploymentStatus> EmploymentStatus { get; set; }
        public virtual DbSet<EpiresultAreas> EpiresultAreas { get; set; }
        public virtual DbSet<Experiences> Experiences { get; set; }
        public virtual DbSet<Files> Files { get; set; }
        public virtual DbSet<GeneralQuestions> GeneralQuestions { get; set; }
        public virtual DbSet<GeneratedIds> GeneratedIds { get; set; }
        public virtual DbSet<GroupQuestionClassifiers> GroupQuestionClassifiers { get; set; }
        public virtual DbSet<Groups> Groups { get; set; }
        public virtual DbSet<Hash> Hash { get; set; }
        public virtual DbSet<IdentityCodes> IdentityCodes { get; set; }
        public virtual DbSet<InterviewStatus> InterviewStatus { get; set; }
        public virtual DbSet<InterviewTypes> InterviewTypes { get; set; }
        public virtual DbSet<Interviews> Interviews { get; set; }
        public virtual DbSet<Job> Job { get; set; }
        public virtual DbSet<JobHistories> JobHistories { get; set; }
        public virtual DbSet<JobParameter> JobParameter { get; set; }
        public virtual DbSet<JobQueue> JobQueue { get; set; }
        public virtual DbSet<Jobtitles> Jobtitles { get; set; }
        public virtual DbSet<LeaveManagementSummaries> LeaveManagementSummaries { get; set; }
        public virtual DbSet<LeaveManagements> LeaveManagements { get; set; }
        public virtual DbSet<LeaveRequests> LeaveRequests { get; set; }
        public virtual DbSet<LegalMailLists> LegalMailLists { get; set; }
        public virtual DbSet<Levels> Levels { get; set; }
        public virtual DbSet<LineManager1> LineManager1 { get; set; }
        public virtual DbSet<LineManager2> LineManager2 { get; set; }
        public virtual DbSet<List> List { get; set; }
        public virtual DbSet<LocationHeadUnits> LocationHeadUnits { get; set; }
        public virtual DbSet<Locations> Locations { get; set; }
        public virtual DbSet<Logins> Logins { get; set; }
        public virtual DbSet<MailDispatchers> MailDispatchers { get; set; }
        public virtual DbSet<MedicalClaimTypes> MedicalClaimTypes { get; set; }
        public virtual DbSet<MedicalClaims> MedicalClaims { get; set; }
        public virtual DbSet<Menus> Menus { get; set; }
        public virtual DbSet<MigrationHistory> MigrationHistory { get; set; }
        public virtual DbSet<MonthLists> MonthLists { get; set; }
        public virtual DbSet<Months> Months { get; set; }
        public virtual DbSet<Parameters> Parameters { get; set; }
        public virtual DbSet<Patterns> Patterns { get; set; }
        public virtual DbSet<PersonalSkills> PersonalSkills { get; set; }
        public virtual DbSet<Personals> Personals { get; set; }
        public virtual DbSet<Positions> Positions { get; set; }
        public virtual DbSet<Prefixes> Prefixes { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<PromotionClassifications> PromotionClassifications { get; set; }
        public virtual DbSet<Promotions> Promotions { get; set; }
        public virtual DbSet<Questions> Questions { get; set; }
        public virtual DbSet<Ratings> Ratings { get; set; }
        public virtual DbSet<Recommendations> Recommendations { get; set; }
        public virtual DbSet<ReportManagers> ReportManagers { get; set; }
        public virtual DbSet<RequestAgreements> RequestAgreements { get; set; }
        public virtual DbSet<RequestAssets> RequestAssets { get; set; }
        public virtual DbSet<Requisitions> Requisitions { get; set; }
        public virtual DbSet<Schema> Schema { get; set; }
        public virtual DbSet<Server> Server { get; set; }
        public virtual DbSet<Set> Set { get; set; }
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<SubGroups> SubGroups { get; set; }
        public virtual DbSet<SubscribedAppraisals> SubscribedAppraisals { get; set; }
        public virtual DbSet<SupervisorEmployees> SupervisorEmployees { get; set; }
        public virtual DbSet<SystemAdmins> SystemAdmins { get; set; }
        public virtual DbSet<SystemClaims> SystemClaims { get; set; }
        public virtual DbSet<SystemConfigs> SystemConfigs { get; set; }
        public virtual DbSet<TeamHeads> TeamHeads { get; set; }
        public virtual DbSet<Teams> Teams { get; set; }
        public virtual DbSet<Trackings> Trackings { get; set; }
        public virtual DbSet<TrainingAndCertifications> TrainingAndCertifications { get; set; }
        public virtual DbSet<Violations> Violations { get; set; }
        public virtual DbSet<Visas> Visas { get; set; }
        public virtual DbSet<WeekDays> WeekDays { get; set; }
        public virtual DbSet<Weeks> Weeks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:davidson.database.windows.net,1433;Initial Catalog=ResourceEdgeUpdateTestForPublish;Persist Security Info=False;User ID=davidson;Password=@A1234567;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;MultipleActiveResultSets=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActivityLogs>(entity =>
            {
                entity.Property(e => e.Actionname).HasColumnName("actionname");

                entity.Property(e => e.Controllername).HasColumnName("controllername");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Myip).HasColumnName("myip");

                entity.Property(e => e.Parameters).HasColumnName("parameters");

                entity.Property(e => e.Requesturl).HasColumnName("requesturl");
            });

            modelBuilder.Entity<AdditionalDetails>(entity =>
            {
                entity.HasIndex(e => e.EmployeeId)
                    .HasName("IX_EmployeeId");

                entity.HasIndex(e => e.GroupId)
                    .HasName("IX_GroupId");

                entity.HasIndex(e => e.LocationId)
                    .HasName("IX_LocationId");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasColumnName("CreatedBY");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.AdditionalDetails)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.AdditionalDetails_dbo.Employees_EmployeeId");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.AdditionalDetails)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.AdditionalDetails_dbo.Groups_GroupId");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.AdditionalDetails)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.AdditionalDetails_dbo.Locations_LocationId");
            });

            modelBuilder.Entity<AggregatedCounter>(entity =>
            {
                entity.ToTable("AggregatedCounter", "HangFire");

                entity.HasIndex(e => new { e.Value, e.Key })
                    .HasName("UX_HangFire_CounterAggregated_Key")
                    .IsUnique();

                entity.Property(e => e.ExpireAt).HasColumnType("datetime");

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<AgreementTypes>(entity =>
            {
                entity.HasIndex(e => e.GroupId)
                    .HasName("IX_GroupId");

                entity.HasIndex(e => e.TrackingId)
                    .HasName("IX_TrackingId");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.AgreementTypes)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.AgreementTypes_dbo.Groups_GroupId");

                entity.HasOne(d => d.Tracking)
                    .WithMany(p => p.AgreementTypes)
                    .HasForeignKey(d => d.TrackingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.AgreementTypes_dbo.Trackings_TrackingId");
            });

            modelBuilder.Entity<AppUserClaims>(entity =>
            {
                entity.HasIndex(e => e.AppUserId)
                    .HasName("IX_AppUserId");

                entity.HasIndex(e => e.ClaimId)
                    .HasName("IX_ClaimId");

                entity.HasIndex(e => e.EmployeeUnitDepartmentId)
                    .HasName("IX_EmployeeUnitDepartmentId");

                entity.HasIndex(e => e.GroupId)
                    .HasName("IX_GroupId");

                entity.HasIndex(e => e.LocationId)
                    .HasName("IX_LocationId");

                entity.HasIndex(e => e.RoleId)
                    .HasName("IX_RoleId");

                entity.HasIndex(e => e.SubGroupId)
                    .HasName("IX_SubGroupId");

                entity.Property(e => e.AppUserId).HasMaxLength(128);

                entity.Property(e => e.RoleId).HasMaxLength(128);

                entity.HasOne(d => d.AppUser)
                    .WithMany(p => p.AppUserClaims)
                    .HasForeignKey(d => d.AppUserId)
                    .HasConstraintName("FK_dbo.AppUserClaims_dbo.AspNetUsers_AppUserId");

                entity.HasOne(d => d.Claim)
                    .WithMany(p => p.AppUserClaims)
                    .HasForeignKey(d => d.ClaimId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.AppUserClaims_dbo.SystemClaims_ClaimId");

                entity.HasOne(d => d.EmployeeUnitDepartment)
                    .WithMany(p => p.AppUserClaims)
                    .HasForeignKey(d => d.EmployeeUnitDepartmentId)
                    .HasConstraintName("FK_dbo.AppUserClaims_dbo.EmployeeUnitDepartments_EmployeeUnitDepartmentId");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.AppUserClaims)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_dbo.AppUserClaims_dbo.Groups_GroupId");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.AppUserClaims)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK_dbo.AppUserClaims_dbo.Locations_LocationId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AppUserClaims)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_dbo.AppUserClaims_dbo.AspNetRoles_RoleId");

                entity.HasOne(d => d.SubGroup)
                    .WithMany(p => p.AppUserClaims)
                    .HasForeignKey(d => d.SubGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.AppUserClaims_dbo.SubGroups_SubGroupId");
            });

            modelBuilder.Entity<AppraisalConfigurations>(entity =>
            {
                entity.HasIndex(e => e.AppraisalInitializationId)
                    .HasName("IX_AppraisalInitializationId");

                entity.HasIndex(e => e.BusinessUnitId)
                    .HasName("IX_BusinessUnitId");

                entity.HasIndex(e => e.DepartmentId)
                    .HasName("IX_DepartmentId");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.AppraisalInitialization)
                    .WithMany(p => p.AppraisalConfigurations)
                    .HasForeignKey(d => d.AppraisalInitializationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.AppraisalConfigurations_dbo.AppraisalInitializations_AppraisalInitializationId");

                entity.HasOne(d => d.BusinessUnit)
                    .WithMany(p => p.AppraisalConfigurations)
                    .HasForeignKey(d => d.BusinessUnitId)
                    .HasConstraintName("FK_dbo.AppraisalConfigurations_dbo.BusinessUnits_BusinessUnitId");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.AppraisalConfigurations)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_dbo.AppraisalConfigurations_dbo.Departments_DepartmentId");
            });

            modelBuilder.Entity<AppraisalCriterias>(entity =>
            {
                entity.HasIndex(e => e.QuestionId)
                    .HasName("IX_QuestionId");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.AppraisalCriterias)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.AppraisalCriterias_dbo.Questions_QuestionId");
            });

            modelBuilder.Entity<AppraisalInitializations>(entity =>
            {
                entity.HasIndex(e => e.GroupId)
                    .HasName("IX_GroupId");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.AppraisalInitializations)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.AppraisalInitializations_dbo.Groups_GroupId");
            });

            modelBuilder.Entity<AppraisalQuestions>(entity =>
            {
                entity.HasIndex(e => e.AppraisalInitializationId)
                    .HasName("IX_AppraisalInitializationId");

                entity.HasIndex(e => e.ClassificationId)
                    .HasName("IX_ClassificationId");

                entity.HasIndex(e => e.DepartmentQuestionId)
                    .HasName("IX_DepartmentQuestionId");

                entity.HasIndex(e => e.EmployeeId)
                    .HasName("IX_EmployeeId");

                entity.HasIndex(e => e.EpiResultAreaId)
                    .HasName("IX_EpiResultAreaId");

                entity.HasIndex(e => e.GeneralQuestionId)
                    .HasName("IX_GeneralQuestionId");

                entity.HasIndex(e => e.QuestionId)
                    .HasName("IX_QuestionId");

                entity.HasIndex(e => e.SubGroupId)
                    .HasName("IX_SubGroupId");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.ActualCompletionTime).HasColumnType("datetime");

                entity.Property(e => e.Answer).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.AppraiseeRating).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.L1status).HasColumnName("L1Status");

                entity.Property(e => e.L2status).HasColumnName("L2Status");

                entity.Property(e => e.L3status).HasColumnName("L3Status");

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.HasOne(d => d.AppraisalInitialization)
                    .WithMany(p => p.AppraisalQuestions)
                    .HasForeignKey(d => d.AppraisalInitializationId)
                    .HasConstraintName("FK_dbo.AppraisalQuestions_dbo.AppraisalInitializations_AppraisalInitializationId");

                entity.HasOne(d => d.Classification)
                    .WithMany(p => p.AppraisalQuestions)
                    .HasForeignKey(d => d.ClassificationId)
                    .HasConstraintName("FK_dbo.AppraisalQuestions_dbo.GroupQuestionClassifiers_ClassificationId");

                entity.HasOne(d => d.DepartmentQuestion)
                    .WithMany(p => p.AppraisalQuestionsDepartmentQuestion)
                    .HasForeignKey(d => d.DepartmentQuestionId)
                    .HasConstraintName("FK_dbo.AppraisalQuestions_dbo.GeneralQuestions_DepartmentQuestionId");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.AppraisalQuestions)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.AppraisalQuestions_dbo.Employees_EmployeeId");

                entity.HasOne(d => d.EpiResultArea)
                    .WithMany(p => p.AppraisalQuestions)
                    .HasForeignKey(d => d.EpiResultAreaId)
                    .HasConstraintName("FK_dbo.AppraisalQuestions_dbo.EPIResultAreas_EpiResultAreaId");

                entity.HasOne(d => d.GeneralQuestion)
                    .WithMany(p => p.AppraisalQuestionsGeneralQuestion)
                    .HasForeignKey(d => d.GeneralQuestionId)
                    .HasConstraintName("FK_dbo.AppraisalQuestions_dbo.GeneralQuestions_GeneralQuestionId");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.AppraisalQuestions)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("FK_dbo.AppraisalQuestions_dbo.Questions_QuestionId");

                entity.HasOne(d => d.SubGroup)
                    .WithMany(p => p.AppraisalQuestions)
                    .HasForeignKey(d => d.SubGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.AppraisalQuestions_dbo.SubGroups_SubGroupId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AppraisalQuestions)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AppraisalQuestions_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AppraisalResults>(entity =>
            {
                entity.HasIndex(e => e.AppraisalInitializationId)
                    .HasName("IX_AppraisalInitializationId");

                entity.HasIndex(e => e.BusinessUnitId)
                    .HasName("IX_BusinessUnitId");

                entity.HasIndex(e => e.DepartmentId)
                    .HasName("IX_DepartmentId");

                entity.HasIndex(e => e.GroupId)
                    .HasName("IX_GroupId");

                entity.HasIndex(e => e.LineManager1Id)
                    .HasName("IX_LineManager1Id");

                entity.HasIndex(e => e.LineManager2Id)
                    .HasName("IX_LineManager2Id");

                entity.HasIndex(e => e.LineManager3Id)
                    .HasName("IX_LineManager3Id");

                entity.HasIndex(e => e.SubGroupId)
                    .HasName("IX_SubGroupId");

                entity.Property(e => e.AppraiseeAverage).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.AppraiseeTotal).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.AppraiserAverage).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.AppraiserTotal).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.LineManager1Id).HasMaxLength(128);

                entity.Property(e => e.LineManager2Id).HasMaxLength(128);

                entity.Property(e => e.LineManager3Id).HasMaxLength(128);

                entity.Property(e => e.Score).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.AppraisalInitialization)
                    .WithMany(p => p.AppraisalResults)
                    .HasForeignKey(d => d.AppraisalInitializationId)
                    .HasConstraintName("FK_dbo.AppraisalResults_dbo.AppraisalInitializations_AppraisalInitializationId");

                entity.HasOne(d => d.BusinessUnit)
                    .WithMany(p => p.AppraisalResults)
                    .HasForeignKey(d => d.BusinessUnitId)
                    .HasConstraintName("FK_dbo.AppraisalResults_dbo.BusinessUnits_BusinessUnitId");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.AppraisalResults)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_dbo.AppraisalResults_dbo.Departments_DepartmentId");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.AppraisalResults)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_dbo.AppraisalResults_dbo.Groups_GroupId");

                entity.HasOne(d => d.LineManager1)
                    .WithMany(p => p.AppraisalResultsLineManager1)
                    .HasForeignKey(d => d.LineManager1Id)
                    .HasConstraintName("FK_dbo.AppraisalResults_dbo.AspNetUsers_LineManager1Id");

                entity.HasOne(d => d.LineManager2)
                    .WithMany(p => p.AppraisalResultsLineManager2)
                    .HasForeignKey(d => d.LineManager2Id)
                    .HasConstraintName("FK_dbo.AppraisalResults_dbo.AspNetUsers_LineManager2Id");

                entity.HasOne(d => d.LineManager3)
                    .WithMany(p => p.AppraisalResultsLineManager3)
                    .HasForeignKey(d => d.LineManager3Id)
                    .HasConstraintName("FK_dbo.AppraisalResults_dbo.AspNetUsers_LineManager3Id");

                entity.HasOne(d => d.SubGroup)
                    .WithMany(p => p.AppraisalResults)
                    .HasForeignKey(d => d.SubGroupId)
                    .HasConstraintName("FK_dbo.AppraisalResults_dbo.SubGroups_SubGroupId");
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.GroupId)
                    .HasName("IX_GroupId");

                entity.HasIndex(e => e.LocationId)
                    .HasName("IX_LocationId");

                entity.HasIndex(e => e.SubGroupId)
                    .HasName("IX_SubGroupId");

                entity.Property(e => e.Id).HasMaxLength(128);

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.AspNetRoles)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_dbo.AspNetRoles_dbo.Groups_GroupId");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.AspNetRoles)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK_dbo.AspNetRoles_dbo.Locations_LocationId");

                entity.HasOne(d => d.SubGroup)
                    .WithMany(p => p.AspNetRoles)
                    .HasForeignKey(d => d.SubGroupId)
                    .HasConstraintName("FK_dbo.AspNetRoles_dbo.SubGroups_SubGroupId");
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.AppUserId)
                    .HasName("IX_AppUser_Id");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.AppUserId)
                    .HasColumnName("AppUser_Id")
                    .HasMaxLength(128);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.HasOne(d => d.AppUser)
                    .WithMany(p => p.AspNetUserClaimsAppUser)
                    .HasForeignKey(d => d.AppUserId)
                    .HasConstraintName("FK_dbo.AspNetUserClaims_dbo.AspNetUsers_AppUser_Id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaimsUser)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey, e.UserId })
                    .HasName("PK_dbo.AspNetUserLogins");

                entity.HasIndex(e => e.AppUserId)
                    .HasName("IX_AppUser_Id");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.Property(e => e.AppUserId)
                    .HasColumnName("AppUser_Id")
                    .HasMaxLength(128);

                entity.HasOne(d => d.AppUser)
                    .WithMany(p => p.AspNetUserLoginsAppUser)
                    .HasForeignKey(d => d.AppUserId)
                    .HasConstraintName("FK_dbo.AspNetUserLogins_dbo.AspNetUsers_AppUser_Id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLoginsUser)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.RoleId, e.UserId, e.GroupId })
                    .HasName("PK_dbo.AspNetUserRoles");

                entity.HasIndex(e => e.EmployeeUnitDepartmentId)
                    .HasName("IX_EmployeeUnitDepartmentId");

                entity.HasIndex(e => e.GroupId)
                    .HasName("IX_GroupId");

                entity.HasIndex(e => e.LocationId)
                    .HasName("IX_LocationId");

                entity.HasIndex(e => e.RoleId)
                    .HasName("IX_RoleId");

                entity.HasIndex(e => e.SubGroupId)
                    .HasName("IX_SubGroupId");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.RoleId).HasMaxLength(128);

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.Property(e => e.GroupId).HasDefaultValueSql("((1))");

                entity.Property(e => e.SubGroupId).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.EmployeeUnitDepartment)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.EmployeeUnitDepartmentId)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.EmployeeUnitDepartments_EmployeeUnitDepartmentId");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.Groups_GroupId");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.Locations_LocationId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId");

                entity.HasOne(d => d.SubGroup)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.SubGroupId)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.SubGroups_SubGroupId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.GroupId)
                    .HasName("IX_GroupId");

                entity.HasIndex(e => e.SubGroupId)
                    .HasName("IX_SubGroupId");

                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.LockoutEndDateUtc).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.SelectedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.AspNetUsers)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_dbo.AspNetUsers_dbo.Groups_GroupId");

                entity.HasOne(d => d.SubGroup)
                    .WithMany(p => p.AspNetUsers)
                    .HasForeignKey(d => d.SubGroupId)
                    .HasConstraintName("FK_dbo.AspNetUsers_dbo.SubGroups_SubGroupId");
            });

            modelBuilder.Entity<AssetCategories>(entity =>
            {
                entity.HasIndex(e => e.SubGroupId)
                    .HasName("IX_SubGroupId");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.HasOne(d => d.SubGroup)
                    .WithMany(p => p.AssetCategories)
                    .HasForeignKey(d => d.SubGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.AssetCategories_dbo.SubGroups_SubGroupId");
            });

            modelBuilder.Entity<Assets>(entity =>
            {
                entity.HasIndex(e => e.AssetCategoryId)
                    .HasName("IX_AssetCategoryId");

                entity.HasIndex(e => e.GroupId)
                    .HasName("IX_GroupId");

                entity.HasIndex(e => e.LocationId)
                    .HasName("IX_LocationId");

                entity.HasIndex(e => e.SubGroupId)
                    .HasName("IX_SubGroupId");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.HasOne(d => d.AssetCategory)
                    .WithMany(p => p.Assets)
                    .HasForeignKey(d => d.AssetCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Assets_dbo.AssetCategories_AssetCategoryId");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Assets)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Assets_dbo.Groups_GroupId");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Assets)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Assets_dbo.Locations_LocationId");

                entity.HasOne(d => d.SubGroup)
                    .WithMany(p => p.Assets)
                    .HasForeignKey(d => d.SubGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Assets_dbo.SubGroups_SubGroupId");
            });

            modelBuilder.Entity<Birthdays>(entity =>
            {
                entity.HasIndex(e => e.GroupId)
                    .HasName("IX_GroupId");

                entity.HasIndex(e => e.LocationId)
                    .HasName("IX_LocationId");

                entity.HasIndex(e => e.SubGroupId)
                    .HasName("IX_SubGroupId");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DateofBirth).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Birthdays)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Birthdays_dbo.Groups_GroupId");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Birthdays)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Birthdays_dbo.Locations_LocationId");

                entity.HasOne(d => d.SubGroup)
                    .WithMany(p => p.Birthdays)
                    .HasForeignKey(d => d.SubGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Birthdays_dbo.SubGroups_SubGroupId");
            });

            modelBuilder.Entity<BusinessUnits>(entity =>
            {
                entity.HasIndex(e => e.LocationId)
                    .HasName("IX_LocationId");

                entity.HasIndex(e => e.SubGroupId)
                    .HasName("IX_SubGroupId");

                entity.Property(e => e.Createdby).HasColumnName("createdby");

                entity.Property(e => e.Createddate)
                    .HasColumnName("createddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Descriptions).HasColumnName("descriptions");

                entity.Property(e => e.Isactive).HasColumnName("isactive");

                entity.Property(e => e.Modifiedby).HasColumnName("modifiedby");

                entity.Property(e => e.Modifieddate)
                    .HasColumnName("modifieddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ReportManager1).HasColumnName("reportManager1");

                entity.Property(e => e.ReportManager2).HasColumnName("reportManager2");

                entity.Property(e => e.ReportManager3).HasColumnName("reportManager3");

                entity.Property(e => e.Startdate)
                    .HasColumnName("startdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Unitcode).HasColumnName("unitcode");

                entity.Property(e => e.Unitname).HasColumnName("unitname");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.BusinessUnits)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK_dbo.BusinessUnits_dbo.Locations_LocationId");

                entity.HasOne(d => d.SubGroup)
                    .WithMany(p => p.BusinessUnits)
                    .HasForeignKey(d => d.SubGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.BusinessUnits_dbo.SubGroups_SubGroupId");
            });

            modelBuilder.Entity<CandidateInterviews>(entity =>
            {
                entity.HasIndex(e => e.CandidateId)
                    .HasName("IX_CandidateId");

                entity.HasIndex(e => e.InterviewId)
                    .HasName("IX_InterviewId");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.HasOne(d => d.Candidate)
                    .WithMany(p => p.CandidateInterviews)
                    .HasForeignKey(d => d.CandidateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.CandidateInterviews_dbo.Candidates_CandidateId");

                entity.HasOne(d => d.Interview)
                    .WithMany(p => p.CandidateInterviews)
                    .HasForeignKey(d => d.InterviewId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.CandidateInterviews_dbo.Interviews_InterviewId");
            });

            modelBuilder.Entity<CandidateWorkDetails>(entity =>
            {
                entity.HasIndex(e => e.CandidateId)
                    .HasName("IX_CandidateId");

                entity.Property(e => e.CompanyFrom).HasColumnType("datetime");

                entity.Property(e => e.CompanyTo).HasColumnType("datetime");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Candidate)
                    .WithMany(p => p.CandidateWorkDetails)
                    .HasForeignKey(d => d.CandidateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.CandidateWorkDetails_dbo.Candidates_CandidateId");
            });

            modelBuilder.Entity<Candidates>(entity =>
            {
                entity.HasIndex(e => e.RequisitionId)
                    .HasName("IX_RequisitionId");

                entity.HasIndex(e => e.SubGroupId)
                    .HasName("IX_SubGroupId");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Requisition)
                    .WithMany(p => p.Candidates)
                    .HasForeignKey(d => d.RequisitionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Candidates_dbo.Requisitions_RequisitionId");

                entity.HasOne(d => d.SubGroup)
                    .WithMany(p => p.Candidates)
                    .HasForeignKey(d => d.SubGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Candidates_dbo.SubGroups_SubGroupId");
            });

            modelBuilder.Entity<CareerPaths>(entity =>
            {
                entity.HasIndex(e => e.CarrierNameId)
                    .HasName("IX_CarrierName_Id");

                entity.HasIndex(e => e.LevelId)
                    .HasName("IX_LevelId");

                entity.Property(e => e.CarrierNameId).HasColumnName("CarrierName_Id");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.HasOne(d => d.CarrierName)
                    .WithMany(p => p.CareerPaths)
                    .HasForeignKey(d => d.CarrierNameId)
                    .HasConstraintName("FK_dbo.CareerPaths_dbo.Careers_CarrierName_Id");

                entity.HasOne(d => d.Level)
                    .WithMany(p => p.CareerPaths)
                    .HasForeignKey(d => d.LevelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.CareerPaths_dbo.Levels_LevelId");
            });

            modelBuilder.Entity<Careers>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<ConfiguredDefaultManagers>(entity =>
            {
                entity.HasIndex(e => e.GroupId)
                    .HasName("IX_GroupId");

                entity.HasIndex(e => e.LineManager1Id)
                    .HasName("IX_LineManager1Id");

                entity.HasIndex(e => e.LineManager2Id)
                    .HasName("IX_LineManager2Id");

                entity.HasIndex(e => e.LocationId)
                    .HasName("IX_LocationId");

                entity.HasIndex(e => e.SubGroupId)
                    .HasName("IX_SubGroupId");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.LineManager1Id).HasMaxLength(128);

                entity.Property(e => e.LineManager2Id).HasMaxLength(128);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.ConfiguredDefaultManagers)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.ConfiguredDefaultManagers_dbo.Groups_GroupId");

                entity.HasOne(d => d.LineManager1)
                    .WithMany(p => p.ConfiguredDefaultManagersLineManager1)
                    .HasForeignKey(d => d.LineManager1Id)
                    .HasConstraintName("FK_dbo.ConfiguredDefaultManagers_dbo.AspNetUsers_LineManager1Id");

                entity.HasOne(d => d.LineManager2)
                    .WithMany(p => p.ConfiguredDefaultManagersLineManager2)
                    .HasForeignKey(d => d.LineManager2Id)
                    .HasConstraintName("FK_dbo.ConfiguredDefaultManagers_dbo.AspNetUsers_LineManager2Id");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.ConfiguredDefaultManagers)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.ConfiguredDefaultManagers_dbo.Locations_LocationId");

                entity.HasOne(d => d.SubGroup)
                    .WithMany(p => p.ConfiguredDefaultManagers)
                    .HasForeignKey(d => d.SubGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.ConfiguredDefaultManagers_dbo.SubGroups_SubGroupId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ConfiguredDefaultManagersUser)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.ConfiguredDefaultManagers_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<Consequences>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<Contacts>(entity =>
            {
                entity.HasIndex(e => e.EmployeeId)
                    .HasName("IX_EmployeeId");

                entity.HasIndex(e => e.GroupId)
                    .HasName("IX_GroupId");

                entity.HasIndex(e => e.LocationId)
                    .HasName("IX_LocationId");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasColumnName("CreatedBY");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Contacts)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Contacts_dbo.Employees_EmployeeId");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Contacts)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Contacts_dbo.Groups_GroupId");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Contacts)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Contacts_dbo.Locations_LocationId");
            });

            modelBuilder.Entity<CooperateCards>(entity =>
            {
                entity.HasIndex(e => e.EmployeeId)
                    .HasName("IX_EmployeeId");

                entity.HasIndex(e => e.GroupId)
                    .HasName("IX_GroupId");

                entity.HasIndex(e => e.LocationId)
                    .HasName("IX_LocationId");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasColumnName("CreatedBY");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.CooperateCards)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.CooperateCards_dbo.Employees_EmployeeId");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.CooperateCards)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.CooperateCards_dbo.Groups_GroupId");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.CooperateCards)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.CooperateCards_dbo.Locations_LocationId");
            });

            modelBuilder.Entity<Counter>(entity =>
            {
                entity.ToTable("Counter", "HangFire");

                entity.HasIndex(e => new { e.Value, e.Key })
                    .HasName("IX_HangFire_Counter_Key");

                entity.Property(e => e.ExpireAt).HasColumnType("datetime");

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<DepartmentalSkills>(entity =>
            {
                entity.HasIndex(e => e.BusinessUnitId)
                    .HasName("IX_BusinessUnitId");

                entity.HasIndex(e => e.DepartmentId)
                    .HasName("IX_DepartmentId");

                entity.HasIndex(e => e.GroupId)
                    .HasName("IX_GroupId");

                entity.HasIndex(e => e.SubGroupId)
                    .HasName("IX_SubGroupId");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Createdby).HasColumnName("createdby");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.BusinessUnit)
                    .WithMany(p => p.DepartmentalSkills)
                    .HasForeignKey(d => d.BusinessUnitId)
                    .HasConstraintName("FK_dbo.DepartmentalSkills_dbo.BusinessUnits_BusinessUnitId");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.DepartmentalSkills)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_dbo.DepartmentalSkills_dbo.Departments_DepartmentId");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.DepartmentalSkills)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_dbo.DepartmentalSkills_dbo.Groups_GroupId");

                entity.HasOne(d => d.SubGroup)
                    .WithMany(p => p.DepartmentalSkills)
                    .HasForeignKey(d => d.SubGroupId)
                    .HasConstraintName("FK_dbo.DepartmentalSkills_dbo.SubGroups_SubGroupId");
            });

            modelBuilder.Entity<Departments>(entity =>
            {
                entity.HasIndex(e => e.BusinessUnitsId)
                    .HasName("IX_BusinessUnitsId");

                entity.HasIndex(e => e.GroupId)
                    .HasName("IX_GroupId");

                entity.HasIndex(e => e.LocationId)
                    .HasName("IX_LocationId");

                entity.HasIndex(e => e.SubGroupId)
                    .HasName("IX_SubGroupId");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Deptcode).HasColumnName("deptcode");

                entity.Property(e => e.Depthead).HasColumnName("depthead");

                entity.Property(e => e.Deptname).HasColumnName("deptname");

                entity.Property(e => e.Descriptions).HasColumnName("descriptions");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ReportManager1).HasColumnName("reportManager1");

                entity.Property(e => e.ReportManager2).HasColumnName("reportManager2");

                entity.Property(e => e.Startdate)
                    .HasColumnName("startdate")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.BusinessUnits)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.BusinessUnitsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Departments_dbo.BusinessUnits_BusinessUnitsId");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_dbo.Departments_dbo.Groups_GroupId");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK_dbo.Departments_dbo.Locations_LocationId");

                entity.HasOne(d => d.SubGroup)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.SubGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Departments_dbo.SubGroups_SubGroupId");
            });

            modelBuilder.Entity<Dependencies>(entity =>
            {
                entity.HasIndex(e => e.DependencyRelationId)
                    .HasName("IX_DependencyRelation_ID");

                entity.HasIndex(e => e.EmployeeId)
                    .HasName("IX_EmployeeId");

                entity.HasIndex(e => e.GroupId)
                    .HasName("IX_GroupId");

                entity.HasIndex(e => e.LocationId)
                    .HasName("IX_LocationId");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasColumnName("CreatedBY");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DependencyRelationId).HasColumnName("DependencyRelation_ID");

                entity.Property(e => e.DependentAge).HasColumnName("dependentAge");

                entity.Property(e => e.DobofDependent)
                    .HasColumnName("DOBOfDependent")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.HasOne(d => d.DependencyRelation)
                    .WithMany(p => p.Dependencies)
                    .HasForeignKey(d => d.DependencyRelationId)
                    .HasConstraintName("FK_dbo.Dependencies_dbo.DependencyRelations_DependencyRelation_ID");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Dependencies)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Dependencies_dbo.Employees_EmployeeId");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Dependencies)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Dependencies_dbo.Groups_GroupId");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Dependencies)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Dependencies_dbo.Locations_LocationId");
            });

            modelBuilder.Entity<DependencyRelations>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasColumnName("CreatedBY");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<Disabilities>(entity =>
            {
                entity.HasIndex(e => e.EmployeeId)
                    .HasName("IX_EmployeeId");

                entity.HasIndex(e => e.GroupId)
                    .HasName("IX_GroupId");

                entity.HasIndex(e => e.LocationId)
                    .HasName("IX_LocationId");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasColumnName("CreatedBY");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Disabilities)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Disabilities_dbo.Employees_EmployeeId");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Disabilities)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Disabilities_dbo.Groups_GroupId");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Disabilities)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Disabilities_dbo.Locations_LocationId");
            });

            modelBuilder.Entity<DisciplinaryIncidents>(entity =>
            {
                entity.HasIndex(e => e.BusinessUnitId)
                    .HasName("IX_BusinessUnitId");

                entity.HasIndex(e => e.CorrectiveActionId)
                    .HasName("IX_CorrectiveActionId");

                entity.HasIndex(e => e.DepartmentId)
                    .HasName("IX_DepartmentId");

                entity.HasIndex(e => e.GroupId)
                    .HasName("IX_GroupId");

                entity.HasIndex(e => e.LocationId)
                    .HasName("IX_LocationId");

                entity.HasIndex(e => e.SubGroupId)
                    .HasName("IX_SubGroupId");

                entity.HasIndex(e => e.ViolationId)
                    .HasName("IX_ViolationId");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DateOfOccurence).HasColumnType("datetime");

                entity.Property(e => e.ExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.HasOne(d => d.BusinessUnit)
                    .WithMany(p => p.DisciplinaryIncidents)
                    .HasForeignKey(d => d.BusinessUnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.DisciplinaryIncidents_dbo.BusinessUnits_BusinessUnitId");

                entity.HasOne(d => d.CorrectiveAction)
                    .WithMany(p => p.DisciplinaryIncidents)
                    .HasForeignKey(d => d.CorrectiveActionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.DisciplinaryIncidents_dbo.Consequences_CorrectiveActionId");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.DisciplinaryIncidents)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.DisciplinaryIncidents_dbo.Departments_DepartmentId");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.DisciplinaryIncidents)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.DisciplinaryIncidents_dbo.Groups_GroupId");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.DisciplinaryIncidents)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.DisciplinaryIncidents_dbo.Locations_LocationId");

                entity.HasOne(d => d.SubGroup)
                    .WithMany(p => p.DisciplinaryIncidents)
                    .HasForeignKey(d => d.SubGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.DisciplinaryIncidents_dbo.SubGroups_SubGroupId");

                entity.HasOne(d => d.Violation)
                    .WithMany(p => p.DisciplinaryIncidents)
                    .HasForeignKey(d => d.ViolationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.DisciplinaryIncidents_dbo.Violations_ViolationId");
            });

            modelBuilder.Entity<Documents>(entity =>
            {
                entity.HasIndex(e => e.EmployeeId)
                    .HasName("IX_EmployeeId");

                entity.HasIndex(e => e.GroupId)
                    .HasName("IX_GroupId");

                entity.HasIndex(e => e.LocationId)
                    .HasName("IX_LocationId");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasColumnName("CreatedBY");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Documents)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Documents_dbo.Employees_EmployeeId");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Documents)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Documents_dbo.Groups_GroupId");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Documents)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Documents_dbo.Locations_LocationId");
            });

            modelBuilder.Entity<EducationLevels>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasColumnName("CreatedBY");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<Educations>(entity =>
            {
                entity.HasIndex(e => e.EducationlevelId)
                    .HasName("IX_EducationlevelId");

                entity.HasIndex(e => e.EmployeeId)
                    .HasName("IX_EmployeeId");

                entity.HasIndex(e => e.GroupId)
                    .HasName("IX_GroupId");

                entity.HasIndex(e => e.LocationId)
                    .HasName("IX_LocationId");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasColumnName("CreatedBY");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.From).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.To).HasColumnType("datetime");

                entity.HasOne(d => d.Educationlevel)
                    .WithMany(p => p.Educations)
                    .HasForeignKey(d => d.EducationlevelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Educations_dbo.EducationLevels_EducationlevelId");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Educations)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Educations_dbo.Employees_EmployeeId");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Educations)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Educations_dbo.Groups_GroupId");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Educations)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Educations_dbo.Locations_LocationId");
            });

            modelBuilder.Entity<EmailConfigurations>(entity =>
            {
                entity.HasIndex(e => e.GroupId)
                    .HasName("IX_GroupId");

                entity.HasIndex(e => e.LocationId)
                    .HasName("IX_LocationId");

                entity.HasIndex(e => e.SubGroupId)
                    .HasName("IX_SubGroupId");

                entity.HasIndex(e => e.TrackingId)
                    .HasName("IX_TrackingId");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.EmailConfigurations)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.EmailConfigurations_dbo.Groups_GroupId");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.EmailConfigurations)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.EmailConfigurations_dbo.Locations_LocationId");

                entity.HasOne(d => d.SubGroup)
                    .WithMany(p => p.EmailConfigurations)
                    .HasForeignKey(d => d.SubGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.EmailConfigurations_dbo.SubGroups_SubGroupId");

                entity.HasOne(d => d.Tracking)
                    .WithMany(p => p.EmailConfigurations)
                    .HasForeignKey(d => d.TrackingId)
                    .HasConstraintName("FK_dbo.EmailConfigurations_dbo.Trackings_TrackingId");
            });

            modelBuilder.Entity<EmpHolidays>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Createdby).HasColumnName("createdby");

                entity.Property(e => e.Createddate)
                    .HasColumnName("createddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.HolidayGroupId).HasColumnName("holiday_group_id");

                entity.Property(e => e.Isactive).HasColumnName("isactive");

                entity.Property(e => e.Modifiedby).HasColumnName("modifiedby");

                entity.Property(e => e.Modifieddate)
                    .HasColumnName("modifieddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<EmpPayrolls>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ResignationDate).HasColumnType("datetime");

                entity.Property(e => e.ResumptionDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<EmployeeConfigurations>(entity =>
            {
                entity.HasIndex(e => e.EmployeeId)
                    .HasName("IX_EmployeeID");

                entity.HasIndex(e => e.GroupId)
                    .HasName("IX_GroupID");

                entity.HasIndex(e => e.LocationId)
                    .HasName("IX_LocationID");

                entity.HasIndex(e => e.SubGroupId)
                    .HasName("IX_SubGroupID");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.SubGroupId).HasColumnName("SubGroupID");

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .HasMaxLength(128);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeConfigurations)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_dbo.EmployeeConfigurations_dbo.Employees_EmployeeID");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.EmployeeConfigurations)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.EmployeeConfigurations_dbo.Groups_GroupID");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.EmployeeConfigurations)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK_dbo.EmployeeConfigurations_dbo.Locations_LocationID");

                entity.HasOne(d => d.SubGroup)
                    .WithMany(p => p.EmployeeConfigurations)
                    .HasForeignKey(d => d.SubGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.EmployeeConfigurations_dbo.SubGroups_SubGroupID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.EmployeeConfigurations)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.EmployeeConfigurations_dbo.AspNetUsers_UserID");
            });

            modelBuilder.Entity<EmployeeLeaveByLevels>(entity =>
            {
                entity.HasIndex(e => e.GroupId)
                    .HasName("IX_GroupId");

                entity.HasIndex(e => e.LevelId)
                    .HasName("IX_LevelId");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.EmployeeLeaveByLevels)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.EmployeeLeaveByLevels_dbo.Groups_GroupId");

                entity.HasOne(d => d.Level)
                    .WithMany(p => p.EmployeeLeaveByLevels)
                    .HasForeignKey(d => d.LevelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.EmployeeLeaveByLevels_dbo.Levels_LevelId");
            });

            modelBuilder.Entity<EmployeeLeaveTypes>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Createdby).HasColumnName("createdby");

                entity.Property(e => e.Createddate)
                    .HasColumnName("createddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Isactive).HasColumnName("isactive");

                entity.Property(e => e.Leavecode).HasColumnName("leavecode");

                entity.Property(e => e.Leavepreallocated).HasColumnName("leavepreallocated");

                entity.Property(e => e.Leavepredeductable).HasColumnName("leavepredeductable");

                entity.Property(e => e.Leavetype).HasColumnName("leavetype");

                entity.Property(e => e.Modifiedby).HasColumnName("modifiedby");

                entity.Property(e => e.Modifieddate)
                    .HasColumnName("modifieddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Numberofdays).HasColumnName("numberofdays");
            });

            modelBuilder.Entity<EmployeeLeaves>(entity =>
            {
                entity.HasIndex(e => e.GroupId)
                    .HasName("IX_GroupId");

                entity.HasIndex(e => e.HrId)
                    .HasName("IX_HrId");

                entity.HasIndex(e => e.LocationId)
                    .HasName("IX_LocationId");

                entity.HasIndex(e => e.SubGroupId)
                    .HasName("IX_SubGroupId");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.HrId).HasMaxLength(128);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.EmployeeLeaves)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.EmployeeLeaves_dbo.Groups_GroupId");

                entity.HasOne(d => d.Hr)
                    .WithMany(p => p.EmployeeLeaves)
                    .HasForeignKey(d => d.HrId)
                    .HasConstraintName("FK_dbo.EmployeeLeaves_dbo.AspNetUsers_HrId");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.EmployeeLeaves)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.EmployeeLeaves_dbo.Locations_LocationId");

                entity.HasOne(d => d.SubGroup)
                    .WithMany(p => p.EmployeeLeaves)
                    .HasForeignKey(d => d.SubGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.EmployeeLeaves_dbo.SubGroups_SubGroupId");
            });

            modelBuilder.Entity<EmployeePromotions>(entity =>
            {
                entity.HasIndex(e => e.BusinessUnitId)
                    .HasName("IX_BusinessUnitId");

                entity.HasIndex(e => e.DepartmentId)
                    .HasName("IX_DepartmentId");

                entity.HasIndex(e => e.EmployeeId)
                    .HasName("IX_EmployeeId");

                entity.HasIndex(e => e.GroupId)
                    .HasName("IX_GroupId");

                entity.HasIndex(e => e.PromotionId)
                    .HasName("IX_PromotionId");

                entity.HasIndex(e => e.SubGroupId)
                    .HasName("IX_SubGroupId");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.HasOne(d => d.BusinessUnit)
                    .WithMany(p => p.EmployeePromotions)
                    .HasForeignKey(d => d.BusinessUnitId)
                    .HasConstraintName("FK_dbo.EmployeePromotions_dbo.BusinessUnits_BusinessUnitId");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.EmployeePromotions)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_dbo.EmployeePromotions_dbo.Departments_DepartmentId");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeePromotions)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_dbo.EmployeePromotions_dbo.Employees_EmployeeId");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.EmployeePromotions)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.EmployeePromotions_dbo.Groups_GroupId");

                entity.HasOne(d => d.Promotion)
                    .WithMany(p => p.EmployeePromotions)
                    .HasForeignKey(d => d.PromotionId)
                    .HasConstraintName("FK_dbo.EmployeePromotions_dbo.Promotions_PromotionId");

                entity.HasOne(d => d.SubGroup)
                    .WithMany(p => p.EmployeePromotions)
                    .HasForeignKey(d => d.SubGroupId)
                    .HasConstraintName("FK_dbo.EmployeePromotions_dbo.SubGroups_SubGroupId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.EmployeePromotions)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.EmployeePromotions_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<EmployeeSkills>(entity =>
            {
                entity.HasIndex(e => e.DepartmentSkillId)
                    .HasName("IX_DepartmentSkillId");

                entity.HasIndex(e => e.PersonalSkillId)
                    .HasName("IX_PersonalSkillId");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.Property(e => e.YearAcquired).HasColumnType("datetime");

                entity.HasOne(d => d.DepartmentSkill)
                    .WithMany(p => p.EmployeeSkills)
                    .HasForeignKey(d => d.DepartmentSkillId)
                    .HasConstraintName("FK_dbo.EmployeeSkills_dbo.DepartmentalSkills_DepartmentSkillId");

                entity.HasOne(d => d.PersonalSkill)
                    .WithMany(p => p.EmployeeSkills)
                    .HasForeignKey(d => d.PersonalSkillId)
                    .HasConstraintName("FK_dbo.EmployeeSkills_dbo.PersonalSkills_PersonalSkillId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.EmployeeSkills)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.EmployeeSkills_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<EmployeeTeams>(entity =>
            {
                entity.HasIndex(e => e.EmployeeId)
                    .HasName("IX_EmployeeId");

                entity.HasIndex(e => e.TeamId)
                    .HasName("IX_TeamId");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DateLeft).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeTeams)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.EmployeeTeams_dbo.Employees_EmployeeId");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.EmployeeTeams)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.EmployeeTeams_dbo.Teams_TeamId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.EmployeeTeams)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.EmployeeTeams_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<EmployeeUnitDepartments>(entity =>
            {
                entity.HasIndex(e => e.DepartmentId)
                    .HasName("IX_DepartmentId");

                entity.HasIndex(e => e.EmployeeConfigurationId)
                    .HasName("IX_EmployeeConfigurationId");

                entity.HasIndex(e => e.EmployeeId)
                    .HasName("IX_EmployeeID");

                entity.HasIndex(e => e.LocationId)
                    .HasName("IX_LocationID");

                entity.HasIndex(e => e.SubGroupId)
                    .HasName("IX_SubGroupID");

                entity.HasIndex(e => e.TeamId)
                    .HasName("IX_TeamId");

                entity.HasIndex(e => e.UnitId)
                    .HasName("IX_UnitID");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.SubGroupId).HasColumnName("SubGroupID");

                entity.Property(e => e.UnitId).HasColumnName("UnitID");

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .HasMaxLength(128);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.EmployeeUnitDepartments)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.EmployeeUnitDepartments_dbo.Departments_DepartmentId");

                entity.HasOne(d => d.EmployeeConfiguration)
                    .WithMany(p => p.EmployeeUnitDepartments)
                    .HasForeignKey(d => d.EmployeeConfigurationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.EmployeeUnitDepartments_dbo.EmployeeConfigurations_EmployeeConfigurationId");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeUnitDepartments)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_dbo.EmployeeUnitDepartments_dbo.Employees_EmployeeID");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.EmployeeUnitDepartments)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK_dbo.EmployeeUnitDepartments_dbo.Locations_LocationID");

                entity.HasOne(d => d.SubGroup)
                    .WithMany(p => p.EmployeeUnitDepartments)
                    .HasForeignKey(d => d.SubGroupId)
                    .HasConstraintName("FK_dbo.EmployeeUnitDepartments_dbo.SubGroups_SubGroupID");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.EmployeeUnitDepartments)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK_dbo.EmployeeUnitDepartments_dbo.Teams_TeamId");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.EmployeeUnitDepartments)
                    .HasForeignKey(d => d.UnitId)
                    .HasConstraintName("FK_dbo.EmployeeUnitDepartments_dbo.BusinessUnits_UnitID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.EmployeeUnitDepartments)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.EmployeeUnitDepartments_dbo.AspNetUsers_UserID");
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.HasIndex(e => e.BusinessunitId)
                    .HasName("IX_BusinessunitId");

                entity.HasIndex(e => e.DepartmentId)
                    .HasName("IX_DepartmentId");

                entity.HasIndex(e => e.GroupId)
                    .HasName("IX_GroupId");

                entity.HasIndex(e => e.JobTitleId)
                    .HasName("IX_JobTitleId");

                entity.HasIndex(e => e.LevelId)
                    .HasName("IX_LevelId");

                entity.HasIndex(e => e.LocationId)
                    .HasName("IX_LocationId");

                entity.HasIndex(e => e.PositionId)
                    .HasName("IX_PositionId");

                entity.HasIndex(e => e.SubGroupId)
                    .HasName("IX_SubGroupId");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Createdby).HasColumnName("createdby");

                entity.Property(e => e.Createddate)
                    .HasColumnName("createddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateOfJoining)
                    .HasColumnName("dateOfJoining")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateOfLeaving)
                    .HasColumnName("dateOfLeaving")
                    .HasColumnType("datetime");

                entity.Property(e => e.EmpEmail).HasColumnName("empEmail");

                entity.Property(e => e.EmpRoleId).HasColumnName("empRoleId");

                entity.Property(e => e.EmpStaffId).HasColumnName("empStaffId");

                entity.Property(e => e.EmpStatusId).HasColumnName("empStatusId");

                entity.Property(e => e.IsOrghead).HasColumnName("isOrghead");

                entity.Property(e => e.Isactive).HasColumnName("isactive");

                entity.Property(e => e.ModeofEmployement).HasColumnName("modeofEmployement");

                entity.Property(e => e.Modifiedby).HasColumnName("modifiedby");

                entity.Property(e => e.Modifieddate)
                    .HasColumnName("modifieddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.OfficeNumber).HasColumnName("officeNumber");

                entity.Property(e => e.PrefixId).HasColumnName("prefixId");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.YearsExp).HasColumnName("yearsExp");

                entity.HasOne(d => d.Businessunit)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.BusinessunitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Employees_dbo.BusinessUnits_BusinessunitId");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Employees_dbo.Departments_DepartmentId");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Employees_dbo.Groups_GroupId");

                entity.HasOne(d => d.JobTitle)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.JobTitleId)
                    .HasConstraintName("FK_dbo.Employees_dbo.Jobtitles_JobTitleId");

                entity.HasOne(d => d.Level)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.LevelId)
                    .HasConstraintName("FK_dbo.Employees_dbo.Levels_LevelId");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK_dbo.Employees_dbo.Locations_LocationId");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.PositionId)
                    .HasConstraintName("FK_dbo.Employees_dbo.Positions_PositionId");

                entity.HasOne(d => d.SubGroup)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.SubGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Employees_dbo.SubGroups_SubGroupId");
            });

            modelBuilder.Entity<EmploymentStatus>(entity =>
            {
                entity.HasKey(e => e.EmpstId)
                    .HasName("PK_dbo.EmploymentStatus");

                entity.Property(e => e.EmpstId).HasColumnName("empstId");

                entity.Property(e => e.Createdby).HasColumnName("createdby");

                entity.Property(e => e.Createddate)
                    .HasColumnName("createddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.EmployemntStatus).HasColumnName("employemntStatus");

                entity.Property(e => e.Isactive).HasColumnName("isactive");

                entity.Property(e => e.Modifiedby).HasColumnName("modifiedby");

                entity.Property(e => e.Modifieddate)
                    .HasColumnName("modifieddate")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<EpiresultAreas>(entity =>
            {
                entity.ToTable("EPIResultAreas");

                entity.HasIndex(e => e.EmployeeId)
                    .HasName("IX_EmployeeId");

                entity.HasIndex(e => e.GroupId)
                    .HasName("IX_GroupId");

                entity.HasIndex(e => e.LocationId)
                    .HasName("IX_LocationId");

                entity.HasIndex(e => e.SubGroupId)
                    .HasName("IX_SubGroupId");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.IsSubGroupId).HasColumnName("isSubGroupId");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EpiresultAreas)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_dbo.EPIResultAreas_dbo.Employees_EmployeeId");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.EpiresultAreas)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_dbo.EPIResultAreas_dbo.Groups_GroupId");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.EpiresultAreas)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK_dbo.EPIResultAreas_dbo.Locations_LocationId");

                entity.HasOne(d => d.SubGroup)
                    .WithMany(p => p.EpiresultAreas)
                    .HasForeignKey(d => d.SubGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.EPIResultAreas_dbo.SubGroups_SubGroupId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.EpiresultAreas)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.EPIResultAreas_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<Experiences>(entity =>
            {
                entity.HasIndex(e => e.EmployeeId)
                    .HasName("IX_EmployeeId");

                entity.HasIndex(e => e.GroupId)
                    .HasName("IX_GroupId");

                entity.HasIndex(e => e.LocationId)
                    .HasName("IX_LocationId");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasColumnName("CreatedBY");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.From).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.To).HasColumnType("datetime");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Experiences)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Experiences_dbo.Employees_EmployeeId");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Experiences)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Experiences_dbo.Groups_GroupId");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Experiences)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Experiences_dbo.Locations_LocationId");
            });

            modelBuilder.Entity<GeneralQuestions>(entity =>
            {
                entity.HasIndex(e => e.BusinessUnitId)
                    .HasName("IX_BusinessUnitId");

                entity.HasIndex(e => e.ClassificationId)
                    .HasName("IX_ClassificationId");

                entity.HasIndex(e => e.DepartmentId)
                    .HasName("IX_DepartmentId");

                entity.HasIndex(e => e.EpiresultAreaId)
                    .HasName("IX_EPIResultAreaId");

                entity.HasIndex(e => e.GroupId)
                    .HasName("IX_GroupId");

                entity.HasIndex(e => e.LocationId)
                    .HasName("IX_LocationId");

                entity.HasIndex(e => e.SubGroupId)
                    .HasName("IX_SubGroupId");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.EpiresultAreaId).HasColumnName("EPIResultAreaId");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.HasOne(d => d.BusinessUnit)
                    .WithMany(p => p.GeneralQuestions)
                    .HasForeignKey(d => d.BusinessUnitId)
                    .HasConstraintName("FK_dbo.GeneralQuestions_dbo.BusinessUnits_BusinessUnitId");

                entity.HasOne(d => d.Classification)
                    .WithMany(p => p.GeneralQuestions)
                    .HasForeignKey(d => d.ClassificationId)
                    .HasConstraintName("FK_dbo.GeneralQuestions_dbo.GroupQuestionClassifiers_ClassificationId");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.GeneralQuestions)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_dbo.GeneralQuestions_dbo.Departments_DepartmentId");

                entity.HasOne(d => d.EpiresultArea)
                    .WithMany(p => p.GeneralQuestions)
                    .HasForeignKey(d => d.EpiresultAreaId)
                    .HasConstraintName("FK_dbo.GeneralQuestions_dbo.EPIResultAreas_EPIResultAreaId");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.GeneralQuestions)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.GeneralQuestions_dbo.Groups_GroupId");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.GeneralQuestions)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK_dbo.GeneralQuestions_dbo.Locations_LocationId");

                entity.HasOne(d => d.SubGroup)
                    .WithMany(p => p.GeneralQuestions)
                    .HasForeignKey(d => d.SubGroupId)
                    .HasConstraintName("FK_dbo.GeneralQuestions_dbo.SubGroups_SubGroupId");
            });

            modelBuilder.Entity<GeneratedIds>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("datetime");
            });

            modelBuilder.Entity<GroupQuestionClassifiers>(entity =>
            {
                entity.HasIndex(e => e.GroupId)
                    .HasName("IX_GroupId");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CalculationPercentage).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.GroupQuestionClassifiers)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.GroupQuestionClassifiers_dbo.Groups_GroupId");
            });

            modelBuilder.Entity<Groups>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Hash>(entity =>
            {
                entity.ToTable("Hash", "HangFire");

                entity.HasIndex(e => new { e.ExpireAt, e.Key })
                    .HasName("IX_HangFire_Hash_Key");

                entity.HasIndex(e => new { e.Id, e.ExpireAt })
                    .HasName("IX_HangFire_Hash_ExpireAt");

                entity.HasIndex(e => new { e.Key, e.Field })
                    .HasName("UX_HangFire_Hash_Key_Field")
                    .IsUnique();

                entity.Property(e => e.Field)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<IdentityCodes>(entity =>
            {
                entity.HasIndex(e => e.GroupId)
                    .HasName("IX_GroupId");

                entity.HasIndex(e => e.SubGroupId)
                    .HasName("IX_SubGroupId");

                entity.Property(e => e.BackgroundagencyCode).HasColumnName("backgroundagency_code");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.Createddate)
                    .HasColumnName("createddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.EmployeeCode).HasColumnName("employee_code");

                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.Modifieddate)
                    .HasColumnName("modifieddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.RequisitionCode).HasColumnName("requisition_code");

                entity.Property(e => e.StaffingCode).HasColumnName("staffing_code");

                entity.Property(e => e.UsersCode).HasColumnName("users_code");

                entity.Property(e => e.VendorsCode).HasColumnName("vendors_code");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.IdentityCodes)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.IdentityCodes_dbo.Groups_GroupId");

                entity.HasOne(d => d.SubGroup)
                    .WithMany(p => p.IdentityCodes)
                    .HasForeignKey(d => d.SubGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.IdentityCodes_dbo.SubGroups_SubGroupId");
            });

            modelBuilder.Entity<Interviews>(entity =>
            {
                entity.HasIndex(e => e.InterviewStatusId)
                    .HasName("IX_InterviewStatusId");

                entity.HasIndex(e => e.InterviewTypeId)
                    .HasName("IX_InterviewTypeId");

                entity.HasIndex(e => e.RequisitionId)
                    .HasName("IX_RequisitionId");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.InterviewDate).HasColumnType("datetime");

                entity.Property(e => e.InterviewTime).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.HasOne(d => d.InterviewStatus)
                    .WithMany(p => p.Interviews)
                    .HasForeignKey(d => d.InterviewStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Interviews_dbo.InterviewStatus_InterviewStatusId");

                entity.HasOne(d => d.InterviewType)
                    .WithMany(p => p.Interviews)
                    .HasForeignKey(d => d.InterviewTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Interviews_dbo.InterviewTypes_InterviewTypeId");

                entity.HasOne(d => d.Requisition)
                    .WithMany(p => p.Interviews)
                    .HasForeignKey(d => d.RequisitionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Interviews_dbo.Requisitions_RequisitionId");
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.ToTable("Job", "HangFire");

                entity.HasIndex(e => e.StateName)
                    .HasName("IX_HangFire_Job_StateName");

                entity.HasIndex(e => new { e.Id, e.ExpireAt })
                    .HasName("IX_HangFire_Job_ExpireAt");

                entity.Property(e => e.Arguments).IsRequired();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.ExpireAt).HasColumnType("datetime");

                entity.Property(e => e.InvocationData).IsRequired();

                entity.Property(e => e.StateName).HasMaxLength(20);
            });

            modelBuilder.Entity<JobHistories>(entity =>
            {
                entity.HasIndex(e => e.DepartmentId)
                    .HasName("IX_DepartmentId");

                entity.HasIndex(e => e.EmployeeId)
                    .HasName("IX_EmployeeId");

                entity.HasIndex(e => e.GroupId)
                    .HasName("IX_GroupId");

                entity.HasIndex(e => e.JobId)
                    .HasName("IX_JobId");

                entity.HasIndex(e => e.LocationId)
                    .HasName("IX_LocationId");

                entity.HasIndex(e => e.PositionId)
                    .HasName("IX_positionId");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasColumnName("CreatedBY");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.From).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.PositionId).HasColumnName("positionId");

                entity.Property(e => e.To).HasColumnType("datetime");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.JobHistories)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.JobHistories_dbo.Departments_DepartmentId");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.JobHistories)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.JobHistories_dbo.Employees_EmployeeId");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.JobHistories)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.JobHistories_dbo.Groups_GroupId");

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.JobHistories)
                    .HasForeignKey(d => d.JobId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.JobHistories_dbo.Jobtitles_JobId");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.JobHistories)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.JobHistories_dbo.Locations_LocationId");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.JobHistories)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.JobHistories_dbo.Positions_positionId");
            });

            modelBuilder.Entity<JobParameter>(entity =>
            {
                entity.ToTable("JobParameter", "HangFire");

                entity.HasIndex(e => new { e.JobId, e.Name })
                    .HasName("IX_HangFire_JobParameter_JobIdAndName");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.JobParameter)
                    .HasForeignKey(d => d.JobId)
                    .HasConstraintName("FK_HangFire_JobParameter_Job");
            });

            modelBuilder.Entity<JobQueue>(entity =>
            {
                entity.ToTable("JobQueue", "HangFire");

                entity.HasIndex(e => new { e.Queue, e.FetchedAt })
                    .HasName("IX_HangFire_JobQueue_QueueAndFetchedAt");

                entity.Property(e => e.FetchedAt).HasColumnType("datetime");

                entity.Property(e => e.Queue)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Jobtitles>(entity =>
            {
                entity.HasIndex(e => e.GroupId)
                    .HasName("IX_GroupId");

                entity.HasIndex(e => e.LocationId)
                    .HasName("IX_LocationId");

                entity.HasIndex(e => e.SubGroupId)
                    .HasName("IX_SubGroupId");

                entity.Property(e => e.Comments).HasColumnName("comments");

                entity.Property(e => e.Createdby).HasColumnName("createdby");

                entity.Property(e => e.Createddate)
                    .HasColumnName("createddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Isactive).HasColumnName("isactive");

                entity.Property(e => e.Jobdescription).HasColumnName("jobdescription");

                entity.Property(e => e.Jobpayfrequency).HasColumnName("jobpayfrequency");

                entity.Property(e => e.Jobpaygradecode).HasColumnName("jobpaygradecode");

                entity.Property(e => e.Jobtitlecode).HasColumnName("jobtitlecode");

                entity.Property(e => e.Jobtitlename).HasColumnName("jobtitlename");

                entity.Property(e => e.Minexperiencerequired).HasColumnName("minexperiencerequired");

                entity.Property(e => e.Modifiedby).HasColumnName("modifiedby");

                entity.Property(e => e.Modifieddate)
                    .HasColumnName("modifieddate")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Jobtitles)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Jobtitles_dbo.Groups_GroupId");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Jobtitles)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK_dbo.Jobtitles_dbo.Locations_LocationId");

                entity.HasOne(d => d.SubGroup)
                    .WithMany(p => p.Jobtitles)
                    .HasForeignKey(d => d.SubGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Jobtitles_dbo.SubGroups_SubGroupId");
            });

            modelBuilder.Entity<LeaveManagementSummaries>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BusinessunitId).HasColumnName("businessunit_id");

                entity.Property(e => e.BusinessunitName).HasColumnName("businessunit_name");

                entity.Property(e => e.CalStartmonth).HasColumnName("cal_startmonth");

                entity.Property(e => e.CalStartmonthname).HasColumnName("cal_startmonthname");

                entity.Property(e => e.Createdby).HasColumnName("createdby");

                entity.Property(e => e.Createddate)
                    .HasColumnName("createddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DepartmentId).HasColumnName("department_id");

                entity.Property(e => e.DepartmentName).HasColumnName("department_name");

                entity.Property(e => e.Descriptions).HasColumnName("descriptions");

                entity.Property(e => e.HoursDay).HasColumnName("hours_day");

                entity.Property(e => e.IsHalfday).HasColumnName("is_halfday");

                entity.Property(e => e.IsLeavetransfer).HasColumnName("is_leavetransfer");

                entity.Property(e => e.IsSatholiday).HasColumnName("is_satholiday");

                entity.Property(e => e.IsSkipholidays).HasColumnName("is_skipholidays");

                entity.Property(e => e.Isactive).HasColumnName("isactive");

                entity.Property(e => e.LeavemgmtId).HasColumnName("leavemgmt_id");

                entity.Property(e => e.Modifiedby).HasColumnName("modifiedby");

                entity.Property(e => e.Modifieddate)
                    .HasColumnName("modifieddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.WeekendEndday).HasColumnName("weekend_endday");

                entity.Property(e => e.WeekendEnddayname).HasColumnName("weekend_enddayname");

                entity.Property(e => e.WeekendStartday).HasColumnName("weekend_startday");

                entity.Property(e => e.WeekendStartdayname).HasColumnName("weekend_startdayname");
            });

            modelBuilder.Entity<LeaveManagements>(entity =>
            {
                entity.HasIndex(e => e.BusinessunitId)
                    .HasName("IX_businessunitId");

                entity.HasIndex(e => e.HrId)
                    .HasName("IX_HrId");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BusinessunitId).HasColumnName("businessunitId");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Createdby).HasColumnName("createdby");

                entity.Property(e => e.DepartmentId).HasColumnName("departmentId");

                entity.Property(e => e.HrId).HasMaxLength(128);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Modifiedby).HasColumnName("modifiedby");

                entity.HasOne(d => d.Businessunit)
                    .WithMany(p => p.LeaveManagements)
                    .HasForeignKey(d => d.BusinessunitId)
                    .HasConstraintName("FK_dbo.LeaveManagements_dbo.BusinessUnits_businessunitId");

                entity.HasOne(d => d.Hr)
                    .WithMany(p => p.LeaveManagements)
                    .HasForeignKey(d => d.HrId)
                    .HasConstraintName("FK_dbo.LeaveManagements_dbo.ReportManagers_HrId");
            });

            modelBuilder.Entity<LeaveRequests>(entity =>
            {
                entity.HasIndex(e => e.DeptId)
                    .HasName("IX_DeptId");

                entity.HasIndex(e => e.EmployeeLeaveId)
                    .HasName("IX_EmployeeLeaveId");

                entity.HasIndex(e => e.GroupId)
                    .HasName("IX_GroupId");

                entity.HasIndex(e => e.HrId)
                    .HasName("IX_HrId");

                entity.HasIndex(e => e.LeavetypeId)
                    .HasName("IX_LeavetypeId");

                entity.HasIndex(e => e.LocationId)
                    .HasName("IX_LocationId");

                entity.HasIndex(e => e.ReliefStaffId)
                    .HasName("IX_ReliefStaffId");

                entity.HasIndex(e => e.RepmangId)
                    .HasName("IX_RepmangId");

                entity.HasIndex(e => e.SubGroupId)
                    .HasName("IX_SubGroupId");

                entity.HasIndex(e => e.UnitId)
                    .HasName("IX_UnitId");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Createdby).HasColumnName("createdby");

                entity.Property(e => e.Createddate)
                    .HasColumnName("createddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateOfResumption).HasColumnType("datetime");

                entity.Property(e => e.FromDate).HasColumnType("datetime");

                entity.Property(e => e.HrId).HasMaxLength(128);

                entity.Property(e => e.Isactive).HasColumnName("isactive");

                entity.Property(e => e.Modifiedby).HasColumnName("modifiedby");

                entity.Property(e => e.Modifieddate)
                    .HasColumnName("modifieddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.RepmangId).HasMaxLength(128);

                entity.Property(e => e.RequestDaysNo).HasColumnName("requestDaysNo");

                entity.Property(e => e.ToDate).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.Property(e => e.Year).HasColumnName("year");

                entity.HasOne(d => d.Dept)
                    .WithMany(p => p.LeaveRequests)
                    .HasForeignKey(d => d.DeptId)
                    .HasConstraintName("FK_dbo.LeaveRequests_dbo.Departments_DeptId");

                entity.HasOne(d => d.EmployeeLeave)
                    .WithMany(p => p.LeaveRequests)
                    .HasForeignKey(d => d.EmployeeLeaveId)
                    .HasConstraintName("FK_dbo.LeaveRequests_dbo.EmployeeLeaves_EmployeeLeaveId");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.LeaveRequests)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.LeaveRequests_dbo.Groups_GroupId");

                entity.HasOne(d => d.Hr)
                    .WithMany(p => p.LeaveRequestsHr)
                    .HasForeignKey(d => d.HrId)
                    .HasConstraintName("FK_dbo.LeaveRequests_dbo.AspNetUsers_HrId");

                entity.HasOne(d => d.Leavetype)
                    .WithMany(p => p.LeaveRequests)
                    .HasForeignKey(d => d.LeavetypeId)
                    .HasConstraintName("FK_dbo.LeaveRequests_dbo.EmployeeLeaveTypes_LeavetypeId");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.LeaveRequests)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.LeaveRequests_dbo.Locations_LocationId");

                entity.HasOne(d => d.ReliefStaff)
                    .WithMany(p => p.LeaveRequests)
                    .HasForeignKey(d => d.ReliefStaffId)
                    .HasConstraintName("FK_dbo.LeaveRequests_dbo.Employees_ReliefStaffId");

                entity.HasOne(d => d.Repmang)
                    .WithMany(p => p.LeaveRequestsRepmang)
                    .HasForeignKey(d => d.RepmangId)
                    .HasConstraintName("FK_dbo.LeaveRequests_dbo.AspNetUsers_RepmangId");

                entity.HasOne(d => d.SubGroup)
                    .WithMany(p => p.LeaveRequests)
                    .HasForeignKey(d => d.SubGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.LeaveRequests_dbo.SubGroups_SubGroupId");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.LeaveRequests)
                    .HasForeignKey(d => d.UnitId)
                    .HasConstraintName("FK_dbo.LeaveRequests_dbo.BusinessUnits_UnitId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.LeaveRequestsUser)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.LeaveRequests_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<LegalMailLists>(entity =>
            {
                entity.HasIndex(e => e.RequestAgreementId)
                    .HasName("IX_RequestAgreementId");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.HasOne(d => d.RequestAgreement)
                    .WithMany(p => p.LegalMailLists)
                    .HasForeignKey(d => d.RequestAgreementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.LegalMailLists_dbo.RequestAgreements_RequestAgreementId");
            });

            modelBuilder.Entity<Levels>(entity =>
            {
                entity.HasIndex(e => e.GroupId)
                    .HasName("IX_GroupId");

                entity.HasIndex(e => e.SubGroupId)
                    .HasName("IX_SubGroupId");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.LevelNo).HasColumnName("levelNo");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Levels)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Levels_dbo.Groups_GroupId");

                entity.HasOne(d => d.SubGroup)
                    .WithMany(p => p.Levels)
                    .HasForeignKey(d => d.SubGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Levels_dbo.SubGroups_SubGroupId");
            });

            modelBuilder.Entity<LineManager1>(entity =>
            {
                entity.HasIndex(e => e.GroupId)
                    .HasName("IX_GroupId");

                entity.HasIndex(e => e.LocationId)
                    .HasName("IX_LocationId");

                entity.HasIndex(e => e.SubGroupId)
                    .HasName("IX_SubGroupId");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.LineManager1)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.LineManager1_dbo.Groups_GroupId");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.LineManager1)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.LineManager1_dbo.Locations_LocationId");

                entity.HasOne(d => d.SubGroup)
                    .WithMany(p => p.LineManager1)
                    .HasForeignKey(d => d.SubGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.LineManager1_dbo.SubGroups_SubGroupId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.LineManager1)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.LineManager1_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<LineManager2>(entity =>
            {
                entity.HasIndex(e => e.DepartmentId)
                    .HasName("IX_DepartmentId");

                entity.HasIndex(e => e.GroupId)
                    .HasName("IX_GroupId");

                entity.HasIndex(e => e.LocationId)
                    .HasName("IX_LocationId");

                entity.HasIndex(e => e.SubGroupId)
                    .HasName("IX_SubGroupId");

                entity.HasIndex(e => e.UnitId)
                    .HasName("IX_UnitId");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.LineManager2)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_dbo.LineManager2_dbo.Departments_DepartmentId");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.LineManager2)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.LineManager2_dbo.Groups_GroupId");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.LineManager2)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.LineManager2_dbo.Locations_LocationId");

                entity.HasOne(d => d.SubGroup)
                    .WithMany(p => p.LineManager2)
                    .HasForeignKey(d => d.SubGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.LineManager2_dbo.SubGroups_SubGroupId");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.LineManager2)
                    .HasForeignKey(d => d.UnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.LineManager2_dbo.BusinessUnits_UnitId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.LineManager2)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.LineManager2_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<List>(entity =>
            {
                entity.ToTable("List", "HangFire");

                entity.HasIndex(e => new { e.Id, e.ExpireAt })
                    .HasName("IX_HangFire_List_ExpireAt");

                entity.HasIndex(e => new { e.ExpireAt, e.Value, e.Key })
                    .HasName("IX_HangFire_List_Key");

                entity.Property(e => e.ExpireAt).HasColumnType("datetime");

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Value).HasColumnType("nvarchar(max)");
            });

            modelBuilder.Entity<LocationHeadUnits>(entity =>
            {
                entity.HasIndex(e => e.BusinessUnitId)
                    .HasName("IX_BusinessUnitId");

                entity.HasIndex(e => e.LineManagerId)
                    .HasName("IX_LineManagerId");

                entity.HasIndex(e => e.LocationId)
                    .HasName("IX_LocationId");

                entity.HasIndex(e => e.SubGroupId)
                    .HasName("IX_SubGroupId");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.HasOne(d => d.BusinessUnit)
                    .WithMany(p => p.LocationHeadUnits)
                    .HasForeignKey(d => d.BusinessUnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.LocationHeadUnits_dbo.BusinessUnits_BusinessUnitId");

                entity.HasOne(d => d.LineManager)
                    .WithMany(p => p.LocationHeadUnits)
                    .HasForeignKey(d => d.LineManagerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.LocationHeadUnits_dbo.LineManager1_LineManagerId");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.LocationHeadUnits)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.LocationHeadUnits_dbo.Locations_LocationId");

                entity.HasOne(d => d.SubGroup)
                    .WithMany(p => p.LocationHeadUnits)
                    .HasForeignKey(d => d.SubGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.LocationHeadUnits_dbo.SubGroups_SubGroupId");
            });

            modelBuilder.Entity<Locations>(entity =>
            {
                entity.HasIndex(e => e.GroupId)
                    .HasName("IX_GroupId");

                entity.HasIndex(e => e.SubGroupId)
                    .HasName("IX_SubGroupId");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Locations)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Locations_dbo.Groups_GroupId");

                entity.HasOne(d => d.SubGroup)
                    .WithMany(p => p.Locations)
                    .HasForeignKey(d => d.SubGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Locations_dbo.SubGroups_SubGroupId");
            });

            modelBuilder.Entity<Logins>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.LogOutTime).HasColumnType("datetime");

                entity.Property(e => e.LoginTime).HasColumnType("datetime");

                entity.Property(e => e.SessionId).HasColumnName("SessionID");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<MailDispatchers>(entity =>
            {
                entity.Property(e => e.TimeToSend).HasColumnType("datetime");
            });

            modelBuilder.Entity<MedicalClaimTypes>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasColumnName("CreatedBY");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<MedicalClaims>(entity =>
            {
                entity.HasIndex(e => e.EmployeeId)
                    .HasName("IX_EmployeeId");

                entity.HasIndex(e => e.GroupId)
                    .HasName("IX_GroupId");

                entity.HasIndex(e => e.LocationId)
                    .HasName("IX_LocationId");

                entity.HasIndex(e => e.MedicalClaimId)
                    .HasName("IX_medicalClaimId");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasColumnName("CreatedBY");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DateOfClaim).HasColumnType("datetime");

                entity.Property(e => e.MedicalClaimId).HasColumnName("medicalClaimId");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.MedicalClaims)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.MedicalClaims_dbo.Employees_EmployeeId");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.MedicalClaims)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.MedicalClaims_dbo.Groups_GroupId");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.MedicalClaims)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.MedicalClaims_dbo.Locations_LocationId");

                entity.HasOne(d => d.MedicalClaim)
                    .WithMany(p => p.MedicalClaims)
                    .HasForeignKey(d => d.MedicalClaimId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.MedicalClaims_dbo.MedicalClaimTypes_medicalClaimId");
            });

            modelBuilder.Entity<Menus>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey })
                    .HasName("PK_dbo.__MigrationHistory");

                entity.ToTable("__MigrationHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ContextKey).HasMaxLength(300);

                entity.Property(e => e.Model).IsRequired();

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<MonthLists>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Months>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Parameters>(entity =>
            {
                entity.Property(e => e.Createdby).HasColumnName("createdby");

                entity.Property(e => e.Createddate)
                    .HasColumnName("createddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Isactive).HasColumnName("isactive");

                entity.Property(e => e.Modifiedby).HasColumnName("modifiedby");

                entity.Property(e => e.Modifieddate)
                    .HasColumnName("modifieddate")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Patterns>(entity =>
            {
                entity.Property(e => e.Pattern).HasColumnName("pattern");
            });

            modelBuilder.Entity<PersonalSkills>(entity =>
            {
                entity.HasIndex(e => e.BusinessUnitId)
                    .HasName("IX_BusinessUnitId");

                entity.HasIndex(e => e.DepartmentId)
                    .HasName("IX_DepartmentId");

                entity.HasIndex(e => e.EmployeeId)
                    .HasName("IX_EmployeeId");

                entity.HasIndex(e => e.GroupId)
                    .HasName("IX_GroupId");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Createdby).HasColumnName("createdby");

                entity.Property(e => e.LastUsedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.Property(e => e.YearAcquired).HasColumnType("datetime");

                entity.HasOne(d => d.BusinessUnit)
                    .WithMany(p => p.PersonalSkills)
                    .HasForeignKey(d => d.BusinessUnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.PersonalSkills_dbo.BusinessUnits_BusinessUnitId");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.PersonalSkills)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.PersonalSkills_dbo.Departments_DepartmentId");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.PersonalSkills)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.PersonalSkills_dbo.Employees_EmployeeId");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.PersonalSkills)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.PersonalSkills_dbo.Groups_GroupId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PersonalSkills)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.PersonalSkills_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<Personals>(entity =>
            {
                entity.HasIndex(e => e.EmployeeId)
                    .HasName("IX_EmployeeId");

                entity.HasIndex(e => e.GroupId)
                    .HasName("IX_GroupId");

                entity.HasIndex(e => e.LocationId)
                    .HasName("IX_LocationId");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasColumnName("CreatedBY");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Personals)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Personals_dbo.Employees_EmployeeId");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Personals)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Personals_dbo.Groups_GroupId");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Personals)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Personals_dbo.Locations_LocationId");
            });

            modelBuilder.Entity<Positions>(entity =>
            {
                entity.HasIndex(e => e.JobtitleId)
                    .HasName("IX_JobtitleId");

                entity.Property(e => e.Createdby).HasColumnName("createdby");

                entity.Property(e => e.Createddate)
                    .HasColumnName("createddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Isactive).HasColumnName("isactive");

                entity.Property(e => e.Modifiedby).HasColumnName("modifiedby");

                entity.Property(e => e.Modifieddate)
                    .HasColumnName("modifieddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Positionname).HasColumnName("positionname");

                entity.HasOne(d => d.Jobtitle)
                    .WithMany(p => p.Positions)
                    .HasForeignKey(d => d.JobtitleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Positions_dbo.Jobtitles_JobtitleId");
            });

            modelBuilder.Entity<Prefixes>(entity =>
            {
                entity.Property(e => e.Createdby).HasColumnName("createdby");

                entity.Property(e => e.Createddate)
                    .HasColumnName("createddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Isactive).HasColumnName("isactive");

                entity.Property(e => e.Modifiedby).HasColumnName("modifiedby");

                entity.Property(e => e.Modifieddate)
                    .HasColumnName("modifieddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.PrefixName).HasColumnName("prefixName");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.ToTable("products");

                entity.Property(e => e.Descriptions).HasColumnName("descriptions");
            });

            modelBuilder.Entity<PromotionClassifications>(entity =>
            {
                entity.HasIndex(e => e.GroupId)
                    .HasName("IX_GroupId");

                entity.HasIndex(e => e.SubGroupId)
                    .HasName("IX_SubGroupId");

                entity.Property(e => e.Createdon).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.PromotionClassifications)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.PromotionClassifications_dbo.Groups_GroupId");

                entity.HasOne(d => d.SubGroup)
                    .WithMany(p => p.PromotionClassifications)
                    .HasForeignKey(d => d.SubGroupId)
                    .HasConstraintName("FK_dbo.PromotionClassifications_dbo.SubGroups_SubGroupId");
            });

            modelBuilder.Entity<Promotions>(entity =>
            {
                entity.HasIndex(e => e.GroupId)
                    .HasName("IX_GroupId");

                entity.HasIndex(e => e.PromotionClasssificationId)
                    .HasName("IX_PromotionClasssificationId");

                entity.HasIndex(e => e.SubgroupId)
                    .HasName("IX_SubgroupId");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Promotions)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Promotions_dbo.Groups_GroupId");

                entity.HasOne(d => d.PromotionClasssification)
                    .WithMany(p => p.Promotions)
                    .HasForeignKey(d => d.PromotionClasssificationId)
                    .HasConstraintName("FK_dbo.Promotions_dbo.PromotionClassifications_PromotionClasssificationId");

                entity.HasOne(d => d.Subgroup)
                    .WithMany(p => p.Promotions)
                    .HasForeignKey(d => d.SubgroupId)
                    .HasConstraintName("FK_dbo.Promotions_dbo.SubGroups_SubgroupId");
            });

            modelBuilder.Entity<Questions>(entity =>
            {
                entity.HasIndex(e => e.BusinessUnitId)
                    .HasName("IX_BusinessUnitId");

                entity.HasIndex(e => e.EpiresultAreaId)
                    .HasName("IX_EPIResultAreaId");

                entity.HasIndex(e => e.GroupId)
                    .HasName("IX_GroupId");

                entity.HasIndex(e => e.LocationId)
                    .HasName("IX_LocationId");

                entity.HasIndex(e => e.SubGroupId)
                    .HasName("IX_SubGroupId");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.ActualCompletionTime).HasColumnType("datetime");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EpiresultAreaId).HasColumnName("EPIResultAreaId");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.HasOne(d => d.BusinessUnit)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.BusinessUnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Questions_dbo.BusinessUnits_BusinessUnitId");

                entity.HasOne(d => d.EpiresultArea)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.EpiresultAreaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Questions_dbo.EPIResultAreas_EPIResultAreaId");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Questions_dbo.Groups_GroupId");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Questions_dbo.Locations_LocationId");

                entity.HasOne(d => d.SubGroup)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.SubGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Questions_dbo.SubGroups_SubGroupId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.Questions_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<Ratings>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Recommendations>(entity =>
            {
                entity.HasIndex(e => e.AppraisalInitializationId)
                    .HasName("IX_AppraisalInitializationId");

                entity.HasIndex(e => e.EmployeeId)
                    .HasName("IX_EmployeeId");

                entity.HasIndex(e => e.GroupId)
                    .HasName("IX_GroupId");

                entity.HasIndex(e => e.SubGroupId)
                    .HasName("IX_SubGroupId");

                entity.HasIndex(e => e.SubscriptionId)
                    .HasName("IX_SubscriptionId");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.HasOne(d => d.AppraisalInitialization)
                    .WithMany(p => p.Recommendations)
                    .HasForeignKey(d => d.AppraisalInitializationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Recommendations_dbo.AppraisalInitializations_AppraisalInitializationId");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Recommendations)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Recommendations_dbo.Employees_EmployeeId");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Recommendations)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Recommendations_dbo.Groups_GroupId");

                entity.HasOne(d => d.SubGroup)
                    .WithMany(p => p.Recommendations)
                    .HasForeignKey(d => d.SubGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Recommendations_dbo.SubGroups_SubGroupId");

                entity.HasOne(d => d.Subscription)
                    .WithMany(p => p.Recommendations)
                    .HasForeignKey(d => d.SubscriptionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Recommendations_dbo.SubscribedAppraisals_SubscriptionId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Recommendations)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.Recommendations_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<ReportManagers>(entity =>
            {
                entity.HasKey(e => e.ManagerUserId)
                    .HasName("PK_dbo.ReportManagers");

                entity.HasIndex(e => e.BusinessUnitId)
                    .HasName("IX_BusinessUnitId");

                entity.HasIndex(e => e.DepartmentId)
                    .HasName("IX_DepartmentId");

                entity.HasIndex(e => e.EmployeeId)
                    .HasName("IX_employeeId");

                entity.HasIndex(e => e.GroupId)
                    .HasName("IX_GroupId");

                entity.HasIndex(e => e.LocationId)
                    .HasName("IX_LocationId");

                entity.HasIndex(e => e.SubGroupId)
                    .HasName("IX_SubGroupId");

                entity.Property(e => e.ManagerUserId).HasMaxLength(128);

                entity.Property(e => e.EmployeeId).HasColumnName("employeeId");

                entity.HasOne(d => d.BusinessUnit)
                    .WithMany(p => p.ReportManagers)
                    .HasForeignKey(d => d.BusinessUnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.ReportManagers_dbo.BusinessUnits_BusinessUnitId");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.ReportManagers)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.ReportManagers_dbo.Departments_DepartmentId");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.ReportManagers)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.ReportManagers_dbo.Employees_employeeId");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.ReportManagers)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.ReportManagers_dbo.Groups_GroupId");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.ReportManagers)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.ReportManagers_dbo.Locations_LocationId");

                entity.HasOne(d => d.SubGroup)
                    .WithMany(p => p.ReportManagers)
                    .HasForeignKey(d => d.SubGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.ReportManagers_dbo.SubGroups_SubGroupId");
            });

            modelBuilder.Entity<RequestAgreements>(entity =>
            {
                entity.HasIndex(e => e.AgreementTypeId)
                    .HasName("IX_AgreementTypeId");

                entity.HasIndex(e => e.FileId)
                    .HasName("IX_FileId");

                entity.HasIndex(e => e.GroupId)
                    .HasName("IX_GroupId");

                entity.HasIndex(e => e.RequestingStaffId)
                    .HasName("IX_RequestingStaffId");

                entity.HasIndex(e => e.SubGroupId)
                    .HasName("IX_SubGroupId");

                entity.HasIndex(e => e.TrackingId)
                    .HasName("IX_TrackingId");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DateofRequest).HasColumnType("datetime");

                entity.Property(e => e.ExpirationDate).HasColumnType("datetime");

                entity.Property(e => e.RequestSignDate).HasColumnType("datetime");

                entity.Property(e => e.ReturnDateofSignedCopy).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.HasOne(d => d.AgreementType)
                    .WithMany(p => p.RequestAgreements)
                    .HasForeignKey(d => d.AgreementTypeId)
                    .HasConstraintName("FK_dbo.RequestAgreements_dbo.AgreementTypes_AgreementTypeId");

                entity.HasOne(d => d.File)
                    .WithMany(p => p.RequestAgreements)
                    .HasForeignKey(d => d.FileId)
                    .HasConstraintName("FK_dbo.RequestAgreements_dbo.Files_FileId");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.RequestAgreements)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_dbo.RequestAgreements_dbo.Groups_GroupId");

                entity.HasOne(d => d.RequestingStaff)
                    .WithMany(p => p.RequestAgreements)
                    .HasForeignKey(d => d.RequestingStaffId)
                    .HasConstraintName("FK_dbo.RequestAgreements_dbo.Employees_RequestingStaffId");

                entity.HasOne(d => d.SubGroup)
                    .WithMany(p => p.RequestAgreements)
                    .HasForeignKey(d => d.SubGroupId)
                    .HasConstraintName("FK_dbo.RequestAgreements_dbo.SubGroups_SubGroupId");

                entity.HasOne(d => d.Tracking)
                    .WithMany(p => p.RequestAgreements)
                    .HasForeignKey(d => d.TrackingId)
                    .HasConstraintName("FK_dbo.RequestAgreements_dbo.Trackings_TrackingId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.RequestAgreements)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.RequestAgreements_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<RequestAssets>(entity =>
            {
                entity.HasIndex(e => e.AssetCategoryId)
                    .HasName("IX_AssetCategoryId");

                entity.HasIndex(e => e.AssetId)
                    .HasName("IX_AssetId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DueTime).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.HasOne(d => d.AssetCategory)
                    .WithMany(p => p.RequestAssets)
                    .HasForeignKey(d => d.AssetCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.RequestAssets_dbo.AssetCategories_AssetCategoryId");

                entity.HasOne(d => d.Asset)
                    .WithMany(p => p.RequestAssets)
                    .HasForeignKey(d => d.AssetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.RequestAssets_dbo.Assets_AssetId");
            });

            modelBuilder.Entity<Requisitions>(entity =>
            {
                entity.HasIndex(e => e.BusinessUnitId)
                    .HasName("IX_BusinessUnitId");

                entity.HasIndex(e => e.DepartmentId)
                    .HasName("IX_DepartmentId");

                entity.HasIndex(e => e.GroupId)
                    .HasName("IX_GroupId");

                entity.HasIndex(e => e.JobTitleId)
                    .HasName("IX_JobTitleId");

                entity.HasIndex(e => e.LocationId)
                    .HasName("IX_LocationId");

                entity.HasIndex(e => e.PositionId)
                    .HasName("IX_PositionId");

                entity.HasIndex(e => e.SubGroupId)
                    .HasName("IX_SubGroupId");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.OnboardDate).HasColumnType("datetime");

                entity.HasOne(d => d.BusinessUnit)
                    .WithMany(p => p.Requisitions)
                    .HasForeignKey(d => d.BusinessUnitId)
                    .HasConstraintName("FK_dbo.Requisitions_dbo.BusinessUnits_BusinessUnitId");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Requisitions)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_dbo.Requisitions_dbo.Departments_DepartmentId");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Requisitions)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Requisitions_dbo.Groups_GroupId");

                entity.HasOne(d => d.JobTitle)
                    .WithMany(p => p.Requisitions)
                    .HasForeignKey(d => d.JobTitleId)
                    .HasConstraintName("FK_dbo.Requisitions_dbo.Jobtitles_JobTitleId");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Requisitions)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Requisitions_dbo.Locations_LocationId");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Requisitions)
                    .HasForeignKey(d => d.PositionId)
                    .HasConstraintName("FK_dbo.Requisitions_dbo.Positions_PositionId");

                entity.HasOne(d => d.SubGroup)
                    .WithMany(p => p.Requisitions)
                    .HasForeignKey(d => d.SubGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Requisitions_dbo.SubGroups_SubGroupId");
            });

            modelBuilder.Entity<Schema>(entity =>
            {
                entity.HasKey(e => e.Version)
                    .HasName("PK_HangFire_Schema");

                entity.ToTable("Schema", "HangFire");

                entity.Property(e => e.Version).ValueGeneratedNever();
            });

            modelBuilder.Entity<Server>(entity =>
            {
                entity.ToTable("Server", "HangFire");

                entity.Property(e => e.Id).HasMaxLength(100);

                entity.Property(e => e.LastHeartbeat).HasColumnType("datetime");
            });

            modelBuilder.Entity<Set>(entity =>
            {
                entity.ToTable("Set", "HangFire");

                entity.HasIndex(e => new { e.Id, e.ExpireAt })
                    .HasName("IX_HangFire_Set_ExpireAt");

                entity.HasIndex(e => new { e.Key, e.Value })
                    .HasName("UX_HangFire_Set_KeyAndValue")
                    .IsUnique();

                entity.HasIndex(e => new { e.ExpireAt, e.Value, e.Key })
                    .HasName("IX_HangFire_Set_Key");

                entity.Property(e => e.ExpireAt).HasColumnType("datetime");

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.ToTable("State", "HangFire");

                entity.HasIndex(e => e.JobId)
                    .HasName("IX_HangFire_State_JobId");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Reason).HasMaxLength(100);

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.State)
                    .HasForeignKey(d => d.JobId)
                    .HasConstraintName("FK_HangFire_State_Job");
            });

            modelBuilder.Entity<SubGroups>(entity =>
            {
                entity.HasIndex(e => e.GroupId)
                    .HasName("IX_GroupId");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.SubGroups)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.SubGroups_dbo.Groups_GroupId");
            });

            modelBuilder.Entity<SubscribedAppraisals>(entity =>
            {
                entity.HasIndex(e => e.AppraisalInitializationId)
                    .HasName("IX_AppraisalInitializationId");

                entity.HasIndex(e => e.GroupId)
                    .HasName("IX_GroupId");

                entity.HasIndex(e => e.SubGroupId)
                    .HasName("IX_SubGroupId");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Start).HasColumnType("datetime");

                entity.Property(e => e.Stop).HasColumnType("datetime");

                entity.HasOne(d => d.AppraisalInitialization)
                    .WithMany(p => p.SubscribedAppraisals)
                    .HasForeignKey(d => d.AppraisalInitializationId)
                    .HasConstraintName("FK_dbo.SubscribedAppraisals_dbo.AppraisalInitializations_AppraisalInitializationId");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.SubscribedAppraisals)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_dbo.SubscribedAppraisals_dbo.Groups_GroupId");

                entity.HasOne(d => d.SubGroup)
                    .WithMany(p => p.SubscribedAppraisals)
                    .HasForeignKey(d => d.SubGroupId)
                    .HasConstraintName("FK_dbo.SubscribedAppraisals_dbo.SubGroups_SubGroupId");
            });

            modelBuilder.Entity<SupervisorEmployees>(entity =>
            {
                entity.HasIndex(e => e.GroupId)
                    .HasName("IX_GroupId");

                entity.HasIndex(e => e.LocationId)
                    .HasName("IX_LocationId");

                entity.HasIndex(e => e.SubGroupId)
                    .HasName("IX_SubGroupId");

                entity.HasIndex(e => e.SuperviseeId)
                    .HasName("IX_SuperviseeId");

                entity.HasIndex(e => e.SupervisorId)
                    .HasName("IX_SupervisorId");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.SuperviseeId).HasMaxLength(128);

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.SupervisorEmployees)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.SupervisorEmployees_dbo.Groups_GroupId");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.SupervisorEmployees)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.SupervisorEmployees_dbo.Locations_LocationId");

                entity.HasOne(d => d.SubGroup)
                    .WithMany(p => p.SupervisorEmployees)
                    .HasForeignKey(d => d.SubGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.SupervisorEmployees_dbo.SubGroups_SubGroupId");

                entity.HasOne(d => d.Supervisee)
                    .WithMany(p => p.SupervisorEmployees)
                    .HasForeignKey(d => d.SuperviseeId)
                    .HasConstraintName("FK_dbo.SupervisorEmployees_dbo.AspNetUsers_SuperviseeId");

                entity.HasOne(d => d.Supervisor)
                    .WithMany(p => p.SupervisorEmployees)
                    .HasForeignKey(d => d.SupervisorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.SupervisorEmployees_dbo.LineManager2_SupervisorId");
            });

            modelBuilder.Entity<SystemAdmins>(entity =>
            {
                entity.HasIndex(e => e.GroupId)
                    .HasName("IX_GroupId");

                entity.HasIndex(e => e.LocationId)
                    .HasName("IX_LocationId");

                entity.HasIndex(e => e.SubGroupId)
                    .HasName("IX_SubGroupId");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.SystemAdmins)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.SystemAdmins_dbo.Groups_GroupId");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.SystemAdmins)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK_dbo.SystemAdmins_dbo.Locations_LocationId");

                entity.HasOne(d => d.SubGroup)
                    .WithMany(p => p.SystemAdmins)
                    .HasForeignKey(d => d.SubGroupId)
                    .HasConstraintName("FK_dbo.SystemAdmins_dbo.SubGroups_SubGroupId");
            });

            modelBuilder.Entity<SystemClaims>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<SystemConfigs>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("datetime");
            });

            modelBuilder.Entity<TeamHeads>(entity =>
            {
                entity.HasIndex(e => e.EmployeeId)
                    .HasName("IX_EmployeeId");

                entity.HasIndex(e => e.GroupId)
                    .HasName("IX_GroupId");

                entity.HasIndex(e => e.LocationId)
                    .HasName("IX_LocationId");

                entity.HasIndex(e => e.SubGroupId)
                    .HasName("IX_SubGroupId");

                entity.HasIndex(e => e.TeamId)
                    .HasName("IX_TeamId");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Modified).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.TeamHeads)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_dbo.TeamHeads_dbo.Employees_EmployeeId");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.TeamHeads)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.TeamHeads_dbo.Groups_GroupId");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.TeamHeads)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK_dbo.TeamHeads_dbo.Locations_LocationId");

                entity.HasOne(d => d.SubGroup)
                    .WithMany(p => p.TeamHeads)
                    .HasForeignKey(d => d.SubGroupId)
                    .HasConstraintName("FK_dbo.TeamHeads_dbo.SubGroups_SubGroupId");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.TeamHeads)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.TeamHeads_dbo.Teams_TeamId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TeamHeads)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.TeamHeads_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<Teams>(entity =>
            {
                entity.HasIndex(e => e.BusinessUnitId)
                    .HasName("IX_BusinessUnitId");

                entity.HasIndex(e => e.DepartmentId)
                    .HasName("IX_DepartmentId");

                entity.HasIndex(e => e.GroupId)
                    .HasName("IX_GroupId");

                entity.HasIndex(e => e.LocationId)
                    .HasName("IX_LocationId");

                entity.HasIndex(e => e.SubGroupId)
                    .HasName("IX_SubGroupId");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.HasOne(d => d.BusinessUnit)
                    .WithMany(p => p.Teams)
                    .HasForeignKey(d => d.BusinessUnitId)
                    .HasConstraintName("FK_dbo.Teams_dbo.BusinessUnits_BusinessUnitId");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Teams)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_dbo.Teams_dbo.Departments_DepartmentId");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Teams)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Teams_dbo.Groups_GroupId");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Teams)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK_dbo.Teams_dbo.Locations_LocationId");

                entity.HasOne(d => d.SubGroup)
                    .WithMany(p => p.Teams)
                    .HasForeignKey(d => d.SubGroupId)
                    .HasConstraintName("FK_dbo.Teams_dbo.SubGroups_SubGroupId");
            });

            modelBuilder.Entity<Trackings>(entity =>
            {
                entity.HasIndex(e => e.CreatedId)
                    .HasName("IX_CreatedID");

                entity.HasIndex(e => e.DeletedId)
                    .HasName("IX_DeletedID");

                entity.HasIndex(e => e.EmployeeId)
                    .HasName("IX_EmployeeID");

                entity.HasIndex(e => e.GroupId)
                    .HasName("IX_GroupID");

                entity.HasIndex(e => e.ModifiedId)
                    .HasName("IX_ModifiedID");

                entity.HasIndex(e => e.SubGroupId)
                    .HasName("IX_SubGroupId");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedId)
                    .HasColumnName("CreatedID")
                    .HasMaxLength(128);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DeletedId)
                    .HasColumnName("DeletedID")
                    .HasMaxLength(128);

                entity.Property(e => e.DeletedOn).HasColumnType("datetime");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.ModifiedId)
                    .HasColumnName("ModifiedID")
                    .HasMaxLength(128);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.HasOne(d => d.Created)
                    .WithMany(p => p.TrackingsCreated)
                    .HasForeignKey(d => d.CreatedId)
                    .HasConstraintName("FK_dbo.Trackings_dbo.AspNetUsers_CreatedID");

                entity.HasOne(d => d.Deleted)
                    .WithMany(p => p.TrackingsDeleted)
                    .HasForeignKey(d => d.DeletedId)
                    .HasConstraintName("FK_dbo.Trackings_dbo.AspNetUsers_DeletedID");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Trackings)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_dbo.Trackings_dbo.Employees_EmployeeID");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Trackings)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_dbo.Trackings_dbo.Groups_GroupID");

                entity.HasOne(d => d.Modified)
                    .WithMany(p => p.TrackingsModified)
                    .HasForeignKey(d => d.ModifiedId)
                    .HasConstraintName("FK_dbo.Trackings_dbo.AspNetUsers_ModifiedID");

                entity.HasOne(d => d.SubGroup)
                    .WithMany(p => p.Trackings)
                    .HasForeignKey(d => d.SubGroupId)
                    .HasConstraintName("FK_dbo.Trackings_dbo.SubGroups_SubGroupId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TrackingsUser)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.Trackings_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<TrainingAndCertifications>(entity =>
            {
                entity.HasIndex(e => e.EmployeeId)
                    .HasName("IX_EmployeeId");

                entity.HasIndex(e => e.GroupId)
                    .HasName("IX_GroupId");

                entity.HasIndex(e => e.LocationId)
                    .HasName("IX_LocationId");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasColumnName("CreatedBY");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.IssuedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.TrainingAndCertifications)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.TrainingAndCertifications_dbo.Employees_EmployeeId");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.TrainingAndCertifications)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.TrainingAndCertifications_dbo.Groups_GroupId");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.TrainingAndCertifications)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.TrainingAndCertifications_dbo.Locations_LocationId");
            });

            modelBuilder.Entity<Violations>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<Visas>(entity =>
            {
                entity.HasIndex(e => e.EmployeeId)
                    .HasName("IX_EmployeeId");

                entity.HasIndex(e => e.GroupId)
                    .HasName("IX_GroupId");

                entity.HasIndex(e => e.LocationId)
                    .HasName("IX_LocationId");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasColumnName("CreatedBY");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.IssuedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.OneToNightyFourExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.OneToNineReviewDate)
                    .HasColumnName("oneToNineReviewDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.OneToNineStatus).HasColumnName("oneToNineStatus");

                entity.Property(e => e.VisaExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.VisaIssuedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Visas)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Visas_dbo.Employees_EmployeeId");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Visas)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Visas_dbo.Groups_GroupId");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Visas)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Visas_dbo.Locations_LocationId");
            });

            modelBuilder.Entity<WeekDays>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Weeks>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
