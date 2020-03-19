using System;
using System.Collections.Generic;
using System.Text;

namespace Resourceedge.Common.Util
{
    public class PaginationResourceParameter
    {
        const int maxPageSize = 20;
        public string SearchQuery { get; set; }
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 20;
        public int PageSize
        {
            get => _pageSize;

            set => _pageSize = (value > maxPageSize) ? maxPageSize : value;
        }

        public string OrderBy { get; set; }
        public string Fields { get; set; }
    }
}
