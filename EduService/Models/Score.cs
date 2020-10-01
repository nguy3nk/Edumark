using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EduService.Models
{
    [Table("Score")]
    public class Score
    {
        [Key, Column(Order = 0)]
        public int ExamId { get; set; }

        [Key, Column(Order = 1)]
        public int StudentId { get; set; }
        public float Value { get; set; }

        [ForeignKey("StudentId")]
        public Student Student { get; set; }

        [ForeignKey("ExamId")]
        public Class Exam { get; set; }
    }
}