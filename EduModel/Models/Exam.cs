using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EduModel.Models
{
    [Table("Exam")]
    public class Exam
    {
        [Key]
        public int ExamId { get; set; }
        public DateTime ExamTime { get; set; }
        public int? ProgramId { get; set; }
        public int? ClassId { get; set; }

        [ForeignKey("ProgramId")]
        public Program Program { get; set; }

        [ForeignKey("ClassId")]
        public Class Class { get; set; }
        public ICollection<Score> Scores { get; set; }
    }
}