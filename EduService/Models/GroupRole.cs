using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EduService.Models
{
    [Table("GroupRole")]
    public class GroupRole
    {
        [Key, Column(Order = 0)]
        public int GroupId { get; set; } 
        [Key, Column(Order = 1)]
        public int BusinessId { get; set; }  
        [Key, Column(Order = 2)]
        public int RoleId { get; set; } 

        [ForeignKey("GroupId")]
        public Group Group { get; set; }
        [ForeignKey("BusinessId")]
        public Business Business { get; set; }
        [ForeignKey("RoleId")]
        public Role Role { get; set; }
    }
}