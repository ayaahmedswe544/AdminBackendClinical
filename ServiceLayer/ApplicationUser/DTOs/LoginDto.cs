using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ServiceLayer.ApplicationUser.DTOs
{
    public class LoginDto
    {
        [Required(ErrorMessage ="username can't be empty")]
        public string UserName { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Password,ErrorMessage = "password can't be empty")]
        public string Password { get; set; } = string.Empty;
    }
}
