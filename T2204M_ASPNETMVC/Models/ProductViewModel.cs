using System;

using System.ComponentModel.DataAnnotations;
using T2204M_ASPNETMVC.Entities;
namespace T2204M_ASPNETMVC.Models
{
	public class ProductViewModel
	{
		[Required]
		[MaxLength(255)]
		[MinLength(6)]
        [Display(Name = "Teen danh mucj")]

        public string Name { get; set; }


		[Required]
        [Display(Name = "Gias")]

        public double Price { get; set; }



		[Required]
        [Display(Name = "moo tar")]
        public string Description { get; set; }

        [Display(Name = "Thuongw hieeuj")]

        public Brand Brand{ get; set; }

        [Display(Name = "Danh mucj")]

        public Category Category { get; set; }
	}
}

