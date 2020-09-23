using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduModel.Models
{
    [Table("Banner")]
    public class Banner
    {
        [Key]
        public int BannerId { get; set; }
        public string BannerName { get; set; }
        public string Image { get; set; }
        public bool Status { get; set; }
    }
}