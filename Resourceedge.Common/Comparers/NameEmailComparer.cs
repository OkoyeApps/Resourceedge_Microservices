using Resourceedge.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Resourceedge.Common.Comparers
{
  public  class NameEmailComparer : IEqualityComparer<NameEmailWithType>
    {
        public bool Equals(NameEmailWithType x, NameEmailWithType y)
        {
            if (x.EmployeeId == y.EmployeeId
                    && x.Email.ToLower() == y.Email.ToLower())
                return true;

            return false;
        }

        public int GetHashCode(NameEmailWithType obj)
        {
            return obj.EmployeeId.GetHashCode();
        }
    }
}
