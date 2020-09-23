using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EduModel.Models
{
    [Table("Register")]
    public class Register
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public bool IsExtraLab { get; set; }
        public DateTime PaidTime { get; set; }
        public float Debt { get; set; }
        public float Price { get; set; }
        public bool Status { get; set; }

        [ForeignKey("CourseId")]
        public Course Course { get; set; }

        [ForeignKey("StudentId")]
        public Student Student { get; set; }
    }
}