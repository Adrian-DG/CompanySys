using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CompanySys.Models
{
	public class Employee
	{
		[Key]
		[DisplayName("Emp. ID")]
		public int ID { get; set; }
		[Required(ErrorMessage ="Upload a profile image")]
		[DataType(DataType.Upload)]
		[DisplayName("Profile")]
		public string Image { get; set; }
		[NotMapped]
		public HttpPostedFileBase Upload { get; set; }
		[Required]
		[MinLength(3)]
		[MaxLength(20)]
		public string Name { get; set; }
		[Required]
		[MinLength(3)]
		[MaxLength(20)]
		[DisplayName("Lastname")]
		public string LastName { get; set; }
		[Required]
		[DataType(DataType.Date)]
		public DateTime Birthday { get; set; }
		[Required]
		[DisplayName("Genre")]
		public EmployeeGenre Genre { get; set; }
		/* contact section */
		[Required]
		[DataType(DataType.PhoneNumber)]
		public string Phone { get; set; }
		[Required]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		// Foreign Keys
		[DisplayName("Pos. ID")]
		public int PositionID { get; set; }
		[DisplayName("Pos. Name")]
		public Position GetPosition { get; set; }
		[DisplayName("Dept. ID")]
		public int DepartmentID { get; set; }
		[DisplayName("Dept. Name")]
		public Department GetDepartment { get; set; }

	}

	public enum EmployeeGenre { male, female }

}