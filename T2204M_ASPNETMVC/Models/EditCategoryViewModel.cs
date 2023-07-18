using System;
using System.ComponentModel.DataAnnotations;

namespace T2204M_ASPNETMVC.Models
{
	public class EditCategoryViewModel
	{
		[Required]


		public int Id { get; set; }


		[Required]
		[Display(Name ="Teen danh muc")]
		public string Name { get; set; }

		
	}
}

