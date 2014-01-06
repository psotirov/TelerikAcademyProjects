using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        [Required]
        [Column(TypeName = "ntext")]
        public string CommentText { get; set; }

        [Required]
        public DateTime PostDate { get; set; }

        [Required]
        public virtual User User { get; set; }

        public virtual Post Post { get; set; }
    }
}
