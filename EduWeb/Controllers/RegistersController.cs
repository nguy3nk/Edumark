using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EduService;
using EduService.Models;

namespace EduWeb.Controllers
{
    public class RegistersController : Controller
    {
        private EdumarkDBContext db = new EdumarkDBContext();

        // GET: Registers
        public ActionResult Index()
        {
            var registers = db.Registers.Include(r => r.Course).Include(r => r.Student);
            return View(registers.ToList());
        }

        // GET: Registers/Details/5
        public ActionResult Details(Register register)
        {
            return View(register);
        }

        // GET: Registers/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName");
            ViewBag.AccountId = new SelectList(db.Students, "AccountId", "AccountId");
            return View();
        }

        // POST: Registers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RegisterId,AccountID,CourseId,IsExtraLab,PaidTime,Price,SalePrice,FullName,Email,Address,Phone,Status")] Register register)
        {
            if (ModelState.IsValid)
            {
                db.Registers.Add(register);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName", register.CourseId);
            ViewBag.AccountId = new SelectList(db.Students, "AccountId", "AccountId", register.AccountId);
            return View(register);
        }

        // GET: Registers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Register register = db.Registers.Find(id);
            if (register == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName", register.CourseId);
            ViewBag.AccountId = new SelectList(db.Students, "AccountId", "AccountId", register.AccountId);
            return View(register);
        }

        // POST: Registers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RegisterId,AccountID,CourseId,IsExtraLab,PaidTime,Price,SalePrice,FullName,Email,Address,Phone,Status")] Register register)
        {
            if (ModelState.IsValid)
            {
                db.Entry(register).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName", register.CourseId);
            ViewBag.AccountId = new SelectList(db.Students, "AccountId", "AccountId", register.AccountId);
            return View(register);
        }

        // GET: Registers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Register register = db.Registers.Find(id);
            if (register == null)
            {
                return HttpNotFound();
            }
            return View(register);
        }

        // POST: Registers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Register register = db.Registers.Find(id);
            db.Registers.Remove(register);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
