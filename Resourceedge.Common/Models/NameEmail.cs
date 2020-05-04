using System;
using System.Collections.Generic;
using System.Text;

namespace Resourceedge.Common.Models
{
    public class NameEmail
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        //public string Type { get; set; }
    }

    public class NameEmailWithFullName
    {
        public int EmployeeId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}
