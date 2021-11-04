using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankGateWay.Models
{
    public class EmployeeContext:DbContext
    {
        public EmployeeContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<EmployeeLogin> BankEmployee { get; set; }

       
    }
}
