using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EduModel.Models
{
    [Table("Course")]
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public float SalePrice { get; set; }
        public int? PostId { get; set; }
        public int? ReplyToCommentId { get; set; }
        public ICollection<Feedback> Feedbacks { get; set; }
        public ICollection<Class> Classes { get; set; }
        public ICollection<Register> Registers { get; set; }
        public ICollection<Program> Programs { get; set; }
    }
}