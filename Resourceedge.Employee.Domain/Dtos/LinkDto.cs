using System;
using System.Collections.Generic;
using System.Text;

namespace Resourceedge.Employee.Domain.Dtos
{
    public class LinkDto
    {
        public string Href { get; set; }
        public string Rel { get; set; }
        public string Method { get; set; }
        public LinkDto(string href, string rel, string method)
        {
            this.Href = href;
            this.Rel = rel;
            this.Method = method;
        }
    }
}
