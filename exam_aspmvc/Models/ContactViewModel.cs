using System;
using System.ComponentModel.DataAnnotations;
namespace exam_aspmvc.Models
{
    public class ContactViewModel
    {


        [Required]
        [MinLength(6)]
        [MaxLength(255)]
        [Display(Name = "Ten")]
        public string Name { get; set; }





        [Required]
        [MinLength(6)]
        [MaxLength(255)]
        public string Number { get; set; }


        [Required]
        [MinLength(6)]
        [MaxLength(255)]
        public string GroupName { get; set; }

        [Required]
        public DateOnly HireDate { get; set; }



        [Required]
       
        public DateOnly Birthday
        {
            get; set;

      }
    }
}

