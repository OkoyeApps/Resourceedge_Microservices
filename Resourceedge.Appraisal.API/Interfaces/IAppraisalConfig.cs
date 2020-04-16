using MongoDB.Bson;
using Resourceedge.Appraisal.API.ResourceParamters;
using Resourceedge.Appraisal.Domain.Entities;
using Resourceedge.Appraisal.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resourceedge.Appraisal.API.Interfaces
{
    public interface IAppraisalConfig 
    {
        public Task<IEnumerable<AppraisalConfig>> Get(AppraisalConfigParameters param);
        public bool Insert(AppraisalConfig entity);
        public Task<AppraisalConfig> Update(ObjectId Id, AppraisalCycle entity);
        public AppraisalCycleForAppraisal GetActiveCycle();
        public bool ActivateCycle(string cycleId);
    }
}
