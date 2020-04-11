using DBIntializers.Models.New;
using DBIntializers.Models.Old;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBIntializers.Services
{
    public class UserService
    {
        private ResourceEdgeUpdateTestForPublishContext OldDB = new ResourceEdgeUpdateTestForPublishContext();
        private EdgeUserDBContext newDbContext = new EdgeUserDBContext();

        public UserService()
        {
                
        }

        public List<string> AddNewUsers()
        {
            try
            {
                List<string> UserIds = newDbContext.AspNetUsers.Select(x => x.Id).ToList();

                var newUsers = OldDB.AspNetUsers.Where(x => !UserIds.Contains(x.Id)).Select(x => new DBIntializers.Models.New.AspNetUsers
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
                    NormalizedUserName = x.Email.ToLowerInvariant(),
                    SecurityStamp = x.SecurityStamp
                }).Distinct();

                newDbContext.AspNetUsers.AddRange(newUsers);
                newDbContext.SaveChanges();

                return newUsers.Select(x => x.Id).ToList();
            }
            catch (Exception)
            {
                return null;
            }
            
        }
    }
}
