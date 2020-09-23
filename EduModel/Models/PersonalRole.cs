using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EduModel.Models
{
    [Table("PersonalRole")]
    public class PersonalRole
    {
        [Key, Column(Order = 0)]
        public int AccountId { get; set; }
        [Key, Column(Order = 1)]
        public string BusinessId { get; set; }
        [Key, Column(Order = 2)]
        public string RoleId { get; set; }

        [ForeignKey("BusinessId")]
        public Business Business { get; set; }

        [ForeignKey("RoleId")]
        public Role Role { get; set; }

        [ForeignKey("AccountId")]
        public Account Account { get; set; }
    }
}