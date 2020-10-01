using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EduService.Models
{
    [Table("Student")]
    public class Student
    {
        [Key]
        public int AccountId { get; set; }
        public int StudentId { get; set; }
        public int? ClassId { get; set; }

        [ForeignKey("AccountId")]
        public Account Account { get; set; }

        [ForeignKey("ClassId")]
        public Class Class { get; set; }
        public ICollection<Score> Scores { get; set; }
        public ICollection<Register> Registers { get; set; }
    }
}