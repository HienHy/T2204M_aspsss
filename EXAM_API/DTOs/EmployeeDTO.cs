using System;
using EXAM_API.Models;

namespace EXAM_API.DTOs
{
	public class EmployeeDTO
	{



        public int EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public DateTime EmployeeDOB { get; set; }
        public string? EmployeeDepartment { get; set; }
        public ICollection<ProjectEmployee>? ProjectEmployees { get; set; }
    }
}

