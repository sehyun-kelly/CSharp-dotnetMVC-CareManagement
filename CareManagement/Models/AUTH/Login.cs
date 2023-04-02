using System;
using System.ComponentModel.DataAnnotations;

namespace CareManagement.Models.AUTH
{
	public class Login
	{
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string? ReturnUrl { get; set; }
    }
}

