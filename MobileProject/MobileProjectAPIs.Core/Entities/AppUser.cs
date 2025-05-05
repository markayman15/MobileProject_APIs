using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileProjectAPIs.Core.Entities
{
    public class AppUser: IdentityUser
    {
        public string Name { get; set; }
        public string? Gender { get; set; }
        public int? Level { get; set; }

    }
}
