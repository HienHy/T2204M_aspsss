using System;
using EXAM_API.Models;

namespace EXAM_API.DTOs
{
	public class ProjectEmployeeDTO
	{
		public ProjectEmployeeDTO()
		{
		}


        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }
        public string Tasks { get; set; }
        public virtual Employee Employees { get; set; }
        public virtual Project Projects { get; set; }


    }
}

