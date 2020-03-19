using Microsoft.AspNetCore.Mvc;
using Resourceedge.Common.Util;
using Resourceedge.Employee.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resourceedge.Employee.API.Helpers
{
    public class ResourceUriGenerator
    {
        public static string CreateAuthorResourceUri(EmployeeResourceParameter authorResourceParameters, ResourceUriType type, IUrlHelper Url)
        {
            switch (type)
            {
                case ResourceUriType.PreviousPage:
                    return Url.Link("GetAuthors", new
                    {
                        fields = authorResourceParameters.Fields,
                        orderBy = authorResourceParameters.OrderBy,
                        PageNumber = authorResourceParameters.PageNumber - 1,
                        pageSize = authorResourceParameters.PageSize,
                        searchQuery = authorResourceParameters.SearchQuery
                    });
                case ResourceUriType.NextPage:
                    return Url.Link("GetAuthors", new
                    {
                        fields = authorResourceParameters.Fields,
                        orderBy = authorResourceParameters.OrderBy,
                        PageNumber = authorResourceParameters.PageNumber + 1,
                        pageSize = authorResourceParameters.PageSize,
                        searchQuery = authorResourceParameters.SearchQuery
                    });
                case ResourceUriType.Current:
                default:
                    return Url.Link("GetAuthors", new
                    {
                        fields = authorResourceParameters.Fields,
                        orderBy = authorResourceParameters.OrderBy,
                        PageNumber = authorResourceParameters.PageNumber,
                        pageSize = authorResourceParameters.PageSize,
                        searchQuery = authorResourceParameters.SearchQuery
                    });
            }
        }
    }
}
