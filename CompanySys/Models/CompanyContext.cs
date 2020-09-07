using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CompanySys.Models
{
	public class CompanyContext: DbContext
	{
		public CompanyContext(): base("name=CompanyDBContext") { }

		public DbSet<Department> Departments { get; set; }
		public DbSet<Position> Positions { get; set; }
		public DbSet<Employee> Employees { get; set; }
	}

}

