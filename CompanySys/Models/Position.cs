using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CompanySys.Models
{
	public class Position
	{
		[Key]
		[DisplayName("Pos. ID")]
		public int ID { get; set; }
		[Required]
		[DisplayName("Pos. name")]
		public string Name { get; set; }
		[Required]
		[DataType(DataType.Currency)]
		[DisplayName("Salary $RD")]
		public int Salary { get; set; }

		// one-to-many
		[DisplayName("Employees")]
		public virtual ICollection<Employee> Employees { get; set; }

		// Foreign Key
		[DisplayName("Dept. ID")]
		public int DepartmentID { get; set; }
		[DisplayName("Dept. name")]
		public Department GetDepartment { get; set; }

			

	}
}