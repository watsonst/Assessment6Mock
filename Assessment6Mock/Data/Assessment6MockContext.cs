using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Assessment6Mock.Models;

namespace Assessment6Mock.Data
{
    public class Assessment6MockContext : DbContext
    {
        public Assessment6MockContext (DbContextOptions<Assessment6MockContext> options)
            : base(options)
        {
        }

        public DbSet<Assessment6Mock.Models.Employee> Employee { get; set; }
    }
}
