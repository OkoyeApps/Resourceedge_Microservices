using Resourceedge.Appraisal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resourceedge.Appraisal.API.Interfaces
{
    public interface IKeyResultArea : IGenericRepository<KeyResultArea>
    {
        void AddKeyOutcomes(KeyResultArea entity);
        public void AddKeyOutcomes(IEnumerable<KeyResultArea> entity);
        public IEnumerable<KeyResultArea> GetPersonalkpis(int employeeId);
        IEnumerable<KeyResultArea> GetKeyResultAreasForAppraiser(int appraiserId, int employeeId);
    }
}
