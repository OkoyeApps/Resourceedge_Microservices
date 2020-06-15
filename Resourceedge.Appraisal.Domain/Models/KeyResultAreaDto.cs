using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Resourceedge.Appraisal.Domain.Entities;
using Resourceedge.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Resourceedge.Appraisal.Domain.Models
{
    public class KeyResultAreaDtoForCreation
    {
        public string Name { get; set; }
        public string myId { get; set; }
        public decimal Weight { get; set; }
        public NameEmail HeadOfDepartment { get; set; }
        public NameEmail Appraiser { get; set; }
        public bool? Approved { get; set; }
        public ICollection<KeyOutcomeForCreationDto> keyOutcomes { get; set; } = new List<KeyOutcomeForCreationDto>();
        public ApprovalStatus Status { get; set; } = new ApprovalStatus();
        public BsonDateTime CreatedAt { get; set; } = BsonDateTime.Create(DateTime.Now);
    }

    public class KeyOutcomeForCreationDto : KeyOutcome
    {

        //public string completionperiod { get; set; }
    }


    public class KeyResultAreaForViewDto
    {
        private string currentPosition = "appraiser";
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public int EmployeeId { get; set; }
        public decimal Weight { get; set; }
        public NameEmail HeadOfDepartment { get; set; } = new NameEmail();
        public NameEmail Appraiser { get; set; } = new NameEmail();
        public bool? Approved { get; set; }
        public string whoami { get; set; }
        public IEnumerable<KeyOutcome> keyOutcomes { get; set; } = new List<KeyOutcome>();
        public ApprovalStatus Status { get; set; } = new ApprovalStatus();
        public AppraisalCalculationByKRA EmployeeCalculation { get; set; } = new AppraisalCalculationByKRA();
        public AppraisalCalculationByKRA FinalCalculation { get; set; } = new AppraisalCalculationByKRA();
    }

    public  class  KeyResultAreaSuperviorCliams
    {
        public NameEmail Appraiser { get; set; }
        public NameEmail Hod { get; set; }
    }
}
