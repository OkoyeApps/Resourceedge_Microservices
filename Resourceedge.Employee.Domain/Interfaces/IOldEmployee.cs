using MongoDB.Bson;
using Resourceedge.Common.Util;
using Resourceedge.Employee.Domain.ArchiveEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Resourceedge.Employee.Domain.Interfaces
{
    public interface IOldEmployee
    {
        PagedList<OldEmployee> GetEmployees(PaginationResourceParameter param);
        OldEmployee GetEmployeeByUserId(string userId);
        OldEmployee GetEmployeeByEmployeeId(int employeeId);
        OldEmployee GetEmployeeByObjectId(ObjectId Id);
        OldEmployee GetEmployeeByEmail(string email);
    }
}
