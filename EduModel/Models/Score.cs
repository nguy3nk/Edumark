using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EduModel.Models
{
    [Table("Score")]
    public class Score
    {
        public int ExamId { get; set; }
        public int StudentId { get; set; }
        public float Value { get; set; }

        [ForeignKey("StudentId")]
        public Student Student { get; set; }

        [ForeignKey("ClassId")]
        public Class Class { get; set; }
    }
}