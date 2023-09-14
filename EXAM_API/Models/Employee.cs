using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EXAM_API.Models
{
    [Table("Employees")]

    public class Employee
	{
		public Employee()
		{
		}
		[Key]
		public int EmployeeId { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 2, ErrorMessage = "Length must be 2 to 150")]
        public string EmployeeName { get; set; }

        public DateTime EmployeeDOB { get; set; }
        public string EmployeeDepartment { get; set; }
        public ICollection<ProjectEmployee> ProjectEmployees { get; set; }


    }
}

