using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EduModel.Models
{
    [Table("Book")]
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        public string BookName { get; set; }
    }
}