using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EduService.Models
{
    [Table("Extralab")]
    public class Extralab
    {
        [Key]
        public int CourseId { get; set; }
        public int Session { get; set; }
        public float Price { get; set; }
        public float ClassId { get; set; }

        [ForeignKey("CourseId")]
        public Course Course { get; set; }
    }
}