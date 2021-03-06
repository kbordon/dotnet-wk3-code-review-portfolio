﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Models
{
    [Table("posts")]
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public virtual BlogUser User { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

        public Post()
        {
            Date = DateTime.Now;
        }
    }
}
