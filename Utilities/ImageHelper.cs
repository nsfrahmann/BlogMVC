using BlogMVC.Models;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogMVC.Utilities
{
    public class PostImageHelper
    {
        public static string GetImage(Post post)
        {
            var binary = Convert.ToBase64String(post.Image);
            var ext = Path.GetExtension(post.FileName);
            string imageDataURL = $"data:image/{ext};base64,{binary}";
            return imageDataURL;
        }
    }

    public class BlogImageHelper
    {
        public static string GetImage(Blog blog)
        {
            var binary = Convert.ToBase64String(blog.Image);
            var ext = Path.GetExtension(blog.FileName);
            string imageDataURL = $"data:image/{ext};base64,{binary}";
            return imageDataURL;
        }
    }
}
