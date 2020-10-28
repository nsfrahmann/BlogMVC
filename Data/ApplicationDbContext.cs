using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BlogMVC.Models;
using Microsoft.AspNetCore.Identity;

namespace BlogMVC.Data
{
    public class ApplicationDbContext : IdentityDbContext<BlogUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<BlogMVC.Models.Blog> Blog { get; set; }
        public DbSet<BlogMVC.Models.Post> Post { get; set; }
        public DbSet<BlogMVC.Models.Tag> Tag { get; set; }
        public DbSet<BlogMVC.Models.Comment> Comment { get; set; }
    }
}
