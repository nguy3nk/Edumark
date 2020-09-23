using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EduModel.Models
{
    [Table("Class")]
    public class Class
    {
        [Key]
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int? CourseId { get; set; }
        public int? LecturerId { get; set; }

        [ForeignKey("CourseId")]
        public Course Course { get; set; }

        [ForeignKey("LecturerId")]
        public Lecturer Lecturer { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<Exam> Exams { get; set; }
    }
}