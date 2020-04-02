using DBIntializers.Models.New;
using DBIntializers.Models.Old;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace DBIntializers
{
    class Program
    {
        static void Main(string[] args)
        {


            var OldApplicationContext = new ResourceEdgeUpdateTestForPublishContext();
            var newDbContext = new EdgeUserDBContext();

            var seed1 = newDbContext.AspNetUsers.Where(X => X.UserName == "seed1@test.com").FirstOrDefault();
            var seed2 = newDbContext.AspNetUsers.Where(x => x.UserName == "seed2@test.com").FirstOrDefault();

            //newDbContext.Database.ExecuteSqlRaw("TRUNCATE TABLE AspNetUsers");

            var OldUsers = OldApplicationContext.AspNetUsers.Select(x => new DBIntializers.Models.New.AspNetUsers
            {
                Email = x.Email,
                PasswordHash = x.PasswordHash,
                FirstName = x.FirstName,
                LastName = x.LastName,
                FullName = x.UserfullName,
                PhoneNumber = x.PhoneNumber,
                UserName = x.Email,
                Id = x.Id,
                NormalizedEmail = x.Email.ToLowerInvariant(),
                NormalizedUserName= x.Email.ToLowerInvariant()
            }).Distinct();

            //newDbContext.AspNetUsers.Add(seed1);
            //newDbContext.AspNetUsers.Add(seed2);
            newDbContext.AspNetUsers.AddRange(OldUsers);
            newDbContext.SaveChanges();

            Console.WriteLine("Old and New Authentication database synchronized");
        }
    }
}
