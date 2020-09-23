using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EduModel.Models
{
    [Table("Blog")]
    public class Blog
    {
        [Key]
        public int BlogId { get; set; }
        public string BlogName { get; set; }

        public ICollection<BlogPost> BlogPosts { get; set; }
    }
}