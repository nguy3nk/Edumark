using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EduService.Models
{
    [Table("Comment")]
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommentId { get; set; }
        public int? AccountId { get; set; }
        public string CommentContent { get; set; }
        public int? PostId { get; set; }
        public int? ReplyToCommentId { get; set; }

        [ForeignKey("PostId")]
        public BlogPost BlogPost { get; set; }

        [ForeignKey("AccountId")]
        public Account Account { get; set; }
    }
}