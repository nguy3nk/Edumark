using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EduModel.Models
{
    [Table("BlogPost")]
    public class BlogPost
    {
        [Key]
        public int PostId { get; set; }
        public int? BlogId { get; set; }
        public string BlogContent { get; set; }

        [ForeignKey("BlogId")]
        public Blog Blog { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}