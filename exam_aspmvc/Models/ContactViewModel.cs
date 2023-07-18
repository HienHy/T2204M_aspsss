using System;
using System.ComponentModel.DataAnnotations;
namespace T2204M_ASPNETMVC.Models
{
	public class CategoryViewModel
	{


		[Required]
		[MinLength(6)]
		[MaxLength(255)]
		[Display(Name="Teen danh mucj")]
		public string Name { get; set; }
	}
}

