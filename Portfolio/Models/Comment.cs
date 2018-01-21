using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Portfolio.Models
{
    [Table("comments")]
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public int PostId { get; set; }
        public virtual Post Post { get; set; }

        public Comment()
        {
            Date = DateTime.Now;
        }
    }
}
