using Microsoft.AspNetCore.Identity;
using System;

namespace FA.JustBlog.Models.Security
{
    public class User : IdentityUser<Guid>
    {
        public int Age { get; set; }

        public string AboutMe { get; set; }
    }
}