using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileProjectAPIs.Core.DTOs
{
    public class SignUpDTO
    {
        [Required]
        public string name { get; set; }
        public string? gender { get; set; }
        [Required]
        public string email { get; set; }
        public int? level { get; set; }
        [Required]
        [PasswordPropertyText]
        public string password { get; set; }
        [Required]
        [PasswordPropertyText]
        [Compare("password", ErrorMessage = "Confirm Password not Same As Password")]
        public string confirm_password { get; set; }
    }
}
