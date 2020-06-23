using MongoDB.Bson;
using MongoDB.Driver;
using Resourceedge.Appraisal.Domain.Entities;
using Resourceedge.Email.Api.Model;
using System.Collections.Generic;
using System.Linq;

namespace Resourceedge.Appraisal.API.Helpers
{
    public static class AppraisalResultExtension
    {
        public static AppraisalResult CompleteAppraisal(this AppraisalResult result, string reason)
        {
            bool employeeAccept = result.EmployeeAccept.IsAccepted.Value;

            if (employeeAccept)
            {
                result.IsCompleted = true;
            }
            else
            {
                result.IsAccepted = false;
                result.EmployeeAccept.Reason = reason;
            }

            return result;
        }

        public static AppraisalResult HodApproval(this AppraisalResult result, string reason)
        {
            bool hodApproval = result.HodAccept.IsAccepted.Value;
            if (hodApproval)
            {
                result.IsCompleted = true;
                result.NextAppraisee = "Done";
            }
            else
            {
                result.NextAppraisee = "APPRAISER";
                result.IsAccepted = false;
                result.HodAccept.Reason = reason;
            }
            return result;
        }

        public static List<SingleEmailDto> FormatEmailForAppraisal(List<SingleEmailDto> emailDto)
        {
            List<SingleEmailDto> emailDtos = new List<SingleEmailDto>();
            foreach (var item in emailDto)
            {
                if (!emailDtos.Any(x => x.ReceiverEmailAddress == item.ReceiverEmailAddress))
                {
                    emailDtos.Add(item);
                }
            }
            return emailDtos;
        }

        public static AppraisalResult ResetForHod(this AppraisalResult result, IMongoCollection<AppraisalResult> Collection)
        {
            result.IsCompleted = null;
            result.NextAppraisee = "Hod";

            var filter = Builders<AppraisalResult>.Filter.Where(x => x.Id == result.Id);

            var finalResult = result.ToBsonDocument();
            var update = new BsonDocument("$set", finalResult);

            Collection.UpdateOne(filter, update);

            return result;
        }
        
        public static AppraisalResult ResetForAppraiser(this AppraisalResult result, IMongoCollection<AppraisalResult> Collection)
        {
            result.IsAccepted = null;
            result.NextAppraisee = "Appraiser";

            var filter = Builders<AppraisalResult>.Filter.Where(x => x.Id == result.Id);

            var finalResult = result.ToBsonDocument();
            var update = new BsonDocument("$set", finalResult);

            Collection.UpdateOne(filter, update);

            return result;
        }
    }
}
