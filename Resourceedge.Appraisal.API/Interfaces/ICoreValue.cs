using MongoDB.Bson;
using Resourceedge.Appraisal.Domain.Entities;
using Resourceedge.Appraisal.Domain.Models;
using Resourceedge.Common.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resourceedge.Appraisal.API.Interfaces
{
    public interface ICoreValue 
    {
        IEnumerable<CoreValuesKRA> Get(PaginationResourceParameter param);
        CoreValuesKRA GetSingle(ObjectId Id);
        void Insert(CoreValuesKRA coreValue);
        void Insert(IEnumerable<CoreValuesKRA> coreValues);
        Task<CoreValuesKRA> UpdateCoreValue(ObjectId Id, CoreValueForUpdateDto coreValues);
        Task<long> UpdateCoreValueKeyOutcome(ObjectId Id, ObjectId keyOutcomeId, KeyOutcomeForUpdateDto coreValue);
        PagedList<CoreValuesKRA> GetCoreValuesSearch(PaginationResourceParameter resourceParam);
    }
}
