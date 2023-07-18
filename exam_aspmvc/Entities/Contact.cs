using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace exam_aspmvc.Entities
{
	[Table("Contacts")]
	public class Contact
	{

        [Key]
         public int Id { get; set; }

         [Required]
         [StringLength(50)]

        public string Number { get; set; }



       [Required]
       [StringLength(50)]

        public string Name { get; set; }


        [Required]
        [StringLength(50)]

        public string GroupName { get; set; }

        [Required]
        

        public DateTime HireDate { get; set; }

        [Required]

        public DateTime Birthday { get; set; }



    }
}

