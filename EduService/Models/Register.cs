using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EduService.Models
{
    [Table("Register")]
    public class Register
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RegisterId { get; set; }
        public int AccountID { get; set; }
        public int CourseId { get; set; }
        public bool IsExtraLab { get; set; }
        public DateTime PaidTime { get; set; }
        public float Price { get; set; }
        public float SalePrice { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public bool Status { get; set; }

        [ForeignKey("CourseId")]
        public Course Course { get; set; }

        [ForeignKey("AccountID")]
        public Student Student { get; set; }
    }
}