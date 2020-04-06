# Resource Edge Microservice soultion 

#Script to run

dotnet ef migrations add InitialIdentityServerPersistedGrantDbMigration -c PersistedGrantDbContext -o Data/Migrations/IdentityServer/PersistedGrantDb
dotnet ef migrations add InitialIdentityServerConfigurationDbMigration -c ConfigurationDbContext -o Data/Migrations/IdentityServer/ConfigurationDb
dotnet ef migrations add <name> -c EdgeDbContext -o Data/Migrations/IdentityDbContext

dotnet ef database update -c EdgeDbContext

dotnet ef database update -c PersistedGrantDbContext

dotnet ef database update -c ConfigurationDbContext


##Test Database

##Appraisal Database
mongodb+srv://chocksy:ewZg5URqMNyal7Xs@lawyerpp-cluster-5faak.mongodb.net/EdgeAppraisal?retryWrites=true

##Employee Database
mongodb+srv://chocksy:ewZg5URqMNyal7Xs@lawyerpp-cluster-5faak.mongodb.net/EdgeEmployee?retryWrites=true