using Resourceedge.Appraisal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Resourceedge.Appraisal.Domain.DBContexts
{
    public static class Seed
    {      
        public static void  SeedData(this IDbContext context)
        {
            var collection = context.Database.GetCollection<KeyResultArea>($"{nameof(KeyResultArea)}s");
            collection.InsertMany(
                new List<KeyResultArea>()
                {
                    new KeyResultArea {
                        Name = "Feedback",
                        Weight = 20,
                        AppraiserDetails = new NameEmail { Email = "dav@gmai.com", Name = "Ekeme" },
                        HodDetails = new NameEmail
                        {
                            Email = "Emma#tenece.com",
                            Name = "Emmanuel"
                        },
                        keyOutcomes = new List<KeyOutcome>()
                        {
                            new KeyOutcome {
                                Question = "School Manager",
                                TimeLimit = DateTime.Now.ToString(),
                                Status = new KeyOutcomeApprovalStatus { Employee = null, Hod = true, IsAccepted = null }
                            },
                            new KeyOutcome
                            {
                                      Question = "School Manager",
                                TimeLimit = DateTime.Now.ToString(),
                                Status = new KeyOutcomeApprovalStatus { Employee = null, Hod = true, IsAccepted = null }
                            }
                        },
                        Approved = true
                    },
                            new KeyResultArea {
                        Name = "Feedback",
                        Weight = 20,
                        AppraiserDetails = new NameEmail { Email = "dav@gmai.com", Name = "Ekeme" },
                        HodDetails = new NameEmail
                        {
                            Email = "Emma#tenece.com",
                            Name = "Emmanuel"
                        },
                        keyOutcomes = new List<KeyOutcome>()
                        {
                            new KeyOutcome {
                                Question = "School Manager",
                                TimeLimit = DateTime.Now.ToString(),
                                Status = new KeyOutcomeApprovalStatus { Employee = null, Hod = true, IsAccepted = null }
                            },
                            new KeyOutcome
                            {
                                      Question = "School Manager",
                                TimeLimit = DateTime.Now.ToString(),
                                Status = new KeyOutcomeApprovalStatus { Employee = null, Hod = true, IsAccepted = null }
                            }
                        },
                        Approved = true
                    },
                    new KeyResultArea {
                        Name = "Feedback",
                        Weight = 20,
                        AppraiserDetails = new NameEmail { Email = "dav@gmai.com", Name = "Ekeme" },
                        HodDetails = new NameEmail
                        {
                            Email = "Emma#tenece.com",
                            Name = "Emmanuel"
                        },
                        keyOutcomes = new List<KeyOutcome>()
                        {
                            new KeyOutcome {
                                Question = "School Manager",
                                TimeLimit = DateTime.Now.ToString(),
                                Status = new KeyOutcomeApprovalStatus { Employee = null, Hod = true, IsAccepted = null }
                            },
                            new KeyOutcome
                            {
                                      Question = "School Manager",
                                TimeLimit = DateTime.Now.ToString(),
                                Status = new KeyOutcomeApprovalStatus { Employee = null, Hod = true, IsAccepted = null }
                            }
                        },
                        Approved = true
                    }
                }

            );
        }



    }
}
