using EduService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EduWeb.Models
{
    public class Cart
    {
        public Cart() {; }
        public Course Course { get; set; }
        public Register Register { get; set; }
        
    }
}