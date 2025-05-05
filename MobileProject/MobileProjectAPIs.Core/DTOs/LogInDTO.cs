using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileProjectAPIs.Core.DTOs
{
    public class LogInDTO
    {
        [Required]
        public string email {  get; set; }
        [Required]
        public string password { get; set; }
    }
}
