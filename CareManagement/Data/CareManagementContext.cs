using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CareManagement.Models;
using CareManagement.Models.SCHDL;


namespace CareManagement.Data
{
    public class CareManagementContext : DbContext
    {
        public CareManagementContext (DbContextOptions<CareManagementContext> options)
            : base(options)
        {
        }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}

		public DbSet<Service> Services { get; set; }
	}
}
