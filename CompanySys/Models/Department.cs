using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CompanySys.Models
{
	public class Department
	{
		[Key]
		public int ID { get; set; }
		[Required]
		[DisplayName("Dept. name")]
		public string Name { get; set; }
		public virtual ICollection<Position> Positions { get; set; }
		public virtual ICollection<Employee> Employees { get; set; }
	}
}