using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EduService.Models
{
    [Table("Program")]
    public class Program
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProgramId { get; set; }
        public int CourseId { get; set; }
        public int SubjectId { get; set; }

        [ForeignKey("CourseId")]
        public Course Course { get; set; }

        [ForeignKey("SubjectId")]
        public Subject Subject { get; set; }
        public ICollection<Exam> Exams { get; set; }
    }
}