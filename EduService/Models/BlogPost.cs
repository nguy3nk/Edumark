using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EduService.Models
{
    [Table("BlogPost")]
    public class BlogPost
    {
        [Key]
        public int PostId { get; set; }
        public int? BlogId { get; set; }
        public string PostTitle { get; set; }
        public string PostImage { get; set; }
        public string Resource { get; set; }
        public DateTime UploadDate { get; set; }
        public string Author { get; set; }
        public string BlogContent { get; set; }

        [ForeignKey("BlogId")]
        public Blog Blog { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}