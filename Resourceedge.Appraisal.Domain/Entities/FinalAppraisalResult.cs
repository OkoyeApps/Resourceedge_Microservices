using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace Resourceedge.Appraisal.Domain.Entities
{
    public class FinalAppraisalResult
    {
        public ObjectId Id { get; set; }
        public ObjectId AppraisalConfigId { get; set; }
        public ObjectId AppraisalCycleId { get; set; }
        public int EmployeeId { get; set; }
        public double EmployeeResult { get; set; }
        public double AppraiseeResult { get; set; }
        public double FinalResult { get; set; }
        public string Year { get; set; } = DateTime.Now.Year.ToString();
    }
    
}
