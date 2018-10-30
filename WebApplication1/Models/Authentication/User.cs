using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WebApplication1.Models.Authentication
{
    public class User
    {
        [Key]
        [Required(ErrorMessage = "Email required")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Password required")]
        public string Password { get; set; }

        public string Role { get; set; }
    }
}
