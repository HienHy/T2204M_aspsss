using System;
using System.ComponentModel.DataAnnotations;

namespace T2204M_API.ViewModels
{
	public class UserLogin
	{

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

