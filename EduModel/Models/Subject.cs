using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EduModel.Models
{
    [Table("Subject")]
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; }
        public int Session { get; set; }
        public string Name { get; set; }
        public ICollection<Program> Programs { get; set; }
    }
}