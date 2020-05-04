using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBIntializers.Contexts
{
    public class NewEdgeDb : DbContext
    {
        public NewEdgeDb(DbContextOptions<NewEdgeDb> options) : base(options)
        {

        }
    }
}
