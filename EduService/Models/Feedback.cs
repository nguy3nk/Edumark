using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EduService.Models
{
    [Table("Feedback")]
    public class Feedback
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FeedbackId { get; set; }
        public int? CourseId { get; set; }
        public int? AccountId { get; set; }
        public int? ReplyToCommentId { get; set; }
        public int evaluate { get; set; }
        public string CommentContent { get; set; }

        [ForeignKey("CourseId")]
        public Course Course { get; set; }

        [ForeignKey("AccountId")]
        public Account Account { get; set; }
    }
}