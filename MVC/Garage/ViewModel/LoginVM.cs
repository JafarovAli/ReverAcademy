﻿using System.ComponentModel.DataAnnotations;

namespace Garage.ViewModel
{
    public class LoginVM
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
