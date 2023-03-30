using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CareManagement.Models;
using CareManagement.Models.OM;

namespace CareManagement.Data
{
    public class CareManagementContext : DbContext
    {
        public CareManagementContext(DbContextOptions<CareManagementContext> options)
            : base(options)
        {
        }
        public DbSet<CareManagement.Models.OM.EmployeeHistory>? EmployeeHistory { get; set; }
        public DbSet<CareManagement.Models.OM.Vacation>? Vacation { get; set; }
    }
}