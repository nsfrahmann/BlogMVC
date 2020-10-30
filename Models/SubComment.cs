using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogMVC.Models
{
    public class SubComment
    {
        #region Keys
        public int Id { get; set; }
        public int CommentId { get; set; }
        public int PostId { get; set; }
        public string AuthorId { get; set; }
        #endregion

        #region Comment Properties
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        #endregion


        #region Navigation
        public virtual BlogUser Author { get; set; }
        public virtual Comment Comment { get; set; }
        #endregion
    }
}
