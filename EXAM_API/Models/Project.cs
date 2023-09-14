using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EXAM_API.Models
{
    [Table("Projects")]

    public class Project
	{
		public Project()
		{
		}
        [Key]	
		public int ProjectId { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 2, ErrorMessage = "Length must be 2 to 150")]
        public string ProjectName { get; set; }
        public DateTime ProjectStartDate { get; set; }
        public DateTime? ProjectEndDate { get; set; }
	 public virtual ICollection<ProjectEmployee> ProjectEmployees { get; set; }


    }
}

