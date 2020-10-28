using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BlogMVC.Models
{
    public class Blog
    {
        #region Keys
        public int Id { get; set; }
        #endregion

        #region Blog Properties
        public string Name { get; set; }
        public string Summary { get; set; }

        [Display(Name = "FileName")]
        public string FileName { get; set; }
        public byte[] Image { get; set; }
        public string URL { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        #endregion

        #region Navigation
        public virtual ICollection<Post> Posts { get; set; }
        #endregion

        public Blog()
        {
            Posts = new HashSet<Post>();
        }

    }
}
