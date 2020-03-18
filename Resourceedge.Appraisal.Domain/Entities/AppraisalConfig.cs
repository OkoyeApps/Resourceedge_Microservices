using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace Resourceedge.Appraisal.Domain.Entities
{
    public class AppraisalConfig
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public int Cycles { get; set; } = DateTime.Now.Year;
        public List<AppraisalCycle> Periods { get; set; }
    }

    public class AppraisalCycle
    {
        public DateTime StartDate { get; set; }
        public DateTime StopDate { get; set; }

    }
}
