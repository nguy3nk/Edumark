using EduService;
using EduService.Models;
using EduService.Repository;
using EduWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EduWeb.Controllers
{
    public class CartController : Controller
    {
        
        Repository<Course> _course;
        Repository<Register> _register;
        private const string CartSesion = "CartSesion";
        public CartController()
        {
            _course = new Repository<Course>();
            _register = new Repository<Register>();

        }
        // GET: Cart
        public ActionResult Payment(int id)
        {
            Course course = _course.Get(id);
           
            Register register = new Register();
            register.Course = course;
            Cart cart = new Cart();
            cart.Course = course;
            cart.Register = register;
            Session["Cart"] = cart;

            return View(register);
        }
        public ActionResult Index2()
        {
            Course Cart = Session["Cart"] as Course;


            return RedirectToAction("Index", new { id = 1 });
        }
        public JsonResult DeleteAll()
        {
            Session["Cart"] = null;
            return Json(new
            {
                status = true
            });
        }
        [HttpPost]
        public ActionResult Payment([Bind(Include = "AccountId, CourseId, Course, IsExtraLab, Price, FullName, Email, Address, Phone")] Register register)
        {
            //register.AccountID = 1;
            //_register.Add(register);
            //ghi log

            //return RedirectToAction("Index", "Home" );
            return View(register);
        }
    }
}