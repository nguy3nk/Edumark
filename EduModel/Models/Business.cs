using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EduModel.Models
{
    [Table("Business")]
    public class Business
    {
        [Key]
        public int BusniessId { get; set; }
        public bool Status { get; set; }
        public string BusniessName { get; set; }
        public ICollection<PersonalRole> PersonalRoles { get; set; }
        public ICollection<GroupRole> GroupRoles { get; set; }
    }
}