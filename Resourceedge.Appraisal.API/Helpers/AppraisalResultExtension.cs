﻿using Resourceedge.Appraisal.Domain.Entities;
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
                result.IsAccepted = true;
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
            result.NextAppraisee = "Done";
            bool hodApproval = result.HodAccept.IsAccepted.Value;
            if (hodApproval)
            {
                //result.KeyOutcomeScore.ToList().ForEach(x => x.HodScore = x.AppraisalScore);
                result.IsCompleted = true;
            }
            else
            {
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
    }
}
