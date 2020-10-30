using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace BlogMVC.Models
{
    public class Post
    {
        #region Keys
        public int Id { get; set; }
        public int BlogId { get; set; }
        #endregion

        #region Post Properties

        public string Title { get; set; }
        public string Abstract { get; set; }
        public string Content { get; set; }
        [Display(Name="FileName")]
        public string FileName { get; set; }
        public byte[] Image { get; set; }
        public string Slug { get; set; }

        public DateTime Created { get; set; }

        public DateTime? Updated { get; set; }

        public bool IsPublished { get; set; }




        public Blog Blog { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<SubComment> SubComments { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        #endregion

        public Post()
        {
            Comments = new HashSet<Comment>();
            SubComments = new HashSet<SubComment>();
            Tags = new HashSet<Tag>();
        }
        #region Navigation
        #endregion
    }
}
