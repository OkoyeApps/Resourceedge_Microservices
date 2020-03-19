
using MongoDB.Bson;
using Resourceedge.Common.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Resourceedge.Common.Archive;

namespace Resourceedge.Employee.Domain.Interfaces
{
    public interface IEmployee
    {
        PagedList<OldEmployee> GetEmployees(PaginationResourceParameter param);
        OldEmployee GetEmployeeByUserId(string userId);
        OldEmployee GetEmployeeByEmployeeId(int employeeId);
        OldEmployee GetEmployeeByObjectId(ObjectId Id);
        OldEmployee GetEmployeeByEmail(string email);

        Task<IEnumerable<OldEmployee>> GetMultipleEmployeesById(IEnumerable<int> Ids);
    }
}