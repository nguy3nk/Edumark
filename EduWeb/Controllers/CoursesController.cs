using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EduWeb.Controllers
{
    public class CoursesController : Controller
    {
        // GET: Courses
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Wordpress_courses()
        {
            return View();
        }
        public ActionResult Uxiu_courses()
        {
            return View();
        }
        
        public ActionResult Python_courses()
        {
            return View();
        }
        public ActionResult Photoshop_courses()
        {
            return View();
        }
        public ActionResult Java_courses()
        {
            return View();
        }
        public ActionResult Html_courses()
        {
            return View();
        }
    }
}