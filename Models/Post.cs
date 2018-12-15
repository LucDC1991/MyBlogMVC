using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlogMVC.Models
{
    public class Post
    {
        public int postId { get; set; }
        public string title { get; set; }
        public string summary { get; set; }
        public string content { get; set; }
        public string postedDate { get; set; }
        public User user { get; set; }
    }
}