using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EduService.ViewModels.UserViewModel
{
    public class UserModel
    {
        public int AccountId { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Image { get; set; }
        public int GroupId { get; set; }
        public DateTime Birthday { get; set; }
        public bool Gender { get; set; }
        public bool Status { get; set; }
    }
}