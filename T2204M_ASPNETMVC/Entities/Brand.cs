using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace T2204M_ASPNETMVC.Entities
{

    [Table("Brand")]
	public class Brand
	{
        [Key]
        public int Id { get; set; }



        [Required]
        [StringLength(50)]
        
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }

    }
}

