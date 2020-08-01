﻿namespace WiredBrainCoffee.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Contact
    {
        [Required]
        public string Name { get; set; }

        [Phone]
        [Required]
        public string Phone { get; set; }

        [Required]
        public string Email { get; set; }

        [MinLength(10)]
        [Required]
        public string Message { get; set; }
    }
}
