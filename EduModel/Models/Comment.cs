using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EduModel.Models
{
    [Table("Comment")]
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public string CommentContent { get; set; }
        public int? PostId { get; set; }
        public int? ReplyToCommentId { get; set; }

        [ForeignKey("PostId")]
        public BlogPost BlogPost { get; set; }
    }
}