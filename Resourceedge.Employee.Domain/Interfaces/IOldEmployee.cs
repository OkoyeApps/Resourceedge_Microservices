
using MongoDB.Bson;
using Resourceedge.Common.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Resourceedge.Common.Archive;
using Resourceedge.Common.Models;

namespace Resourceedge.Employee.Domain.Interfaces
{
    public interface IEmployee
    {
        PagedList<OldEmployee> GetEmployees(PaginationResourceParameter param);
        OldEmployee GetEmployeeByUserId(string userId);
        OldEmployee GetEmployeeByEmployeeId(int employeeId);
        OldEmployee GetEmployeeByObjectId(ObjectId Id);
        OldEmployee GetEmployeeByEmail(string email);
        PagedList<NameEmailWithFullName> GetEmployeesWithSeachQuery(int empId, PaginationResourceParameter resourceParam);
        Task<IEnumerable<OldEmployee>> GetMultipleEmployeesById(IEnumerable<int> Ids);
        Task<bool> AddNewEmployeeByEmail(string email);
        Task<bool> AddMultipleEmployeeByEmail(IList<string> emails);
        Task Insert(OldEmployee employee);
    }
}