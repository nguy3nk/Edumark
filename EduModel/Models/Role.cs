using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EduModel.Models
{
    [Table("Role")]
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public ICollection<PersonalRole> PersonalRoles { get; set; }
        public ICollection<GroupRole> GroupRoles { get; set; }
    }
}