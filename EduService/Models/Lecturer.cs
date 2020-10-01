using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EduService.Models
{
    [Table("Lecturer")]
    public class Lecturer
    {
        [Key]
        public int AccountId { get; set; }
        public int LecturerId { get; set; }
        public string Faculty { get; set; }

        [ForeignKey("AccountId")]
        public Account Account { get; set; }
        public ICollection<Class> Classes { get; set; }
    }
}