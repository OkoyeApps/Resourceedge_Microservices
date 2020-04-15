using Resourceedge.Appraisal.Domain.Entities;
using Resourceedge.Appraisal.Domain.Models;
using Resourceedge.Common.Archive;
using Resourceedge.Common.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resourceedge.Appraisal.API.Interfaces
{
    public interface ITeamRepository
    {
        Task<IEnumerable<OldEmployeeDto>> GetEmployeesToAppraise(int employeeId);
        Task<IEnumerable<KeyResultAreaForViewDto>> GetTeamMemberKpi(int MyId, int TeammeberId);
        IEnumerable<KeyResultAreaForViewDto> UpdateWhoAmIForList(IEnumerable<KeyResultArea> resultArea, int employeeId);
        Task<IEnumerable<OldEmployeeForViewDto>> GetSupervisors(int empId, string searchPAram, string orderParam);
        Task<IEnumerable<OldEmployeeDto>> GetEmployeesToApproveEPA(int employeeId, string type);
        Task<IEnumerable<OldEmployeeDto>> FetchEmployeesDetailsFromEmployeeService(IEnumerable<string> Ids);

    }
}
