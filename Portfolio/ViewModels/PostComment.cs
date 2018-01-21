using System;
using Portfolio.Models;

namespace Portfolio.ViewModels
{
    public class PostComment
    {
        public Post Post { get; set; }
        public Comment Comment { get; set; }

        public PostComment()
        {
        }
    }
}
