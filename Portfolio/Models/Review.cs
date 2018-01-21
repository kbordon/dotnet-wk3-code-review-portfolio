using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Portfolio.Models
{
    [Table("reviews")]
    public class Review
    {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public int PostId { get; set; }
        public virtual Post Post { get; set; }

        public Review()
        {
            Date = DateTime.Now;
        }
    }
}
