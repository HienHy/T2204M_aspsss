using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EXAM_API.Models
{
	public class ProjectEmployee
	{
		public ProjectEmployee()
		{
		}

		[Key]
        public int Id { get; set; }
        [Required]
        public int EmployeeId { get; set; }
		[Required]
        public int ProjectId { get; set; }
        [Required]

        public string Tasks { get; set; }

        public virtual Employee Employees { get; set; }
        public virtual Project Projects { get; set; }


    }
}

