using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace BlogMVC.Models
{
    public class BlogUser : IdentityUser
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        public string DisplayName { get; set; }

        public ICollection<Comment> Comments { get; set; } /*= new List<Comment>();*/  /*<--This is the other way to build a constructor*/

        public BlogUser()
        {
            Comments = new HashSet<Comment>();
            DisplayName = "New User";
        }
    }
}
