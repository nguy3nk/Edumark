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
using EduService.Repository;

namespace EduWeb.Areas.Admin.Controllers
{
    public class RegistersController : Controller
    {
        Repository<Register> _repoRegister;
        Repository<Account> _repoAccount;
        Repository<Student> _studentRepository;
        Repository<Class> _repoClass;
        Repository<Course> _repoCourse;
        Repository<Lecturer> _repoLecturer;
        public RegistersController()
        {
            _repoRegister = new Repository<Register>();
            _repoAccount = new Repository<Account>();
            _studentRepository = new Repository<Student>();
            _repoClass = new Repository<Class>();
            _repoCourse = new Repository<Course>();
            _repoLecturer = new Repository<Lecturer>();
        }

        //private EdumarkDBContext db = new EdumarkDBContext();

        // GET: Admin/Registers
        public ActionResult Index()
        {
            var data = _repoRegister.GetAll().AsQueryable().Include(r => r.Course).Include(r => r.Student).ToList();
            return View(data);
            //var registers = db.Registers.Include(r => r.Course).Include(r => r.Student);
            //return View(registers.ToList());
        }

        // GET: Admin/Registers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Register register = _repoRegister.GetAll().AsQueryable().Include(r => r.Course).Include(r => r.Student).FirstOrDefault(l => l.RegisterId == id);
            //Register register = db.Registers.Find(id);
            if (register == null)
            {
                return HttpNotFound();
            }
            return View(register);
        }

        // GET: Admin/Registers/Create
        public ActionResult Create()
        {
            var lecturer = _repoLecturer.GetAll().Select(s => s.AccountId);
            var notLecturer = _repoAccount.GetAll().AsQueryable().Where(x => !lecturer.Contains(x.AccountId)).ToList();
            ViewBag.CourseId = new SelectList(_repoCourse.GetAll(), "CourseId", "CourseName");
            ViewBag.AccountID = new SelectList(notLecturer, "AccountId", "FullName");
            return View();
        }

        // POST: Admin/Registers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AccountID,CourseId,IsExtraLab,PaidTime,Debt,Price,Status")] Register register)
        {
            if (ModelState.IsValid)
            {
                _repoRegister.Add(register);
                //db.Registers.Add(register);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            var lecturer = _repoLecturer.GetAll().Select(s => s.AccountId);
            var notLecturer = _repoAccount.GetAll().AsQueryable().Where(x => !lecturer.Contains(x.AccountId)).ToList();
            ViewBag.CourseId = new SelectList(_repoCourse.GetAll(), "CourseId", "CourseName");
            ViewBag.AccountID = new SelectList(notLecturer, "AccountId", "FullName");
            return View(register);
        }

        // GET: Admin/Registers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Register register = _repoRegister.Get(id);
            //Register register = db.Registers.Find(id);
            if (register == null)
            {
                return HttpNotFound();
            }
            var lecturer = _repoLecturer.GetAll().Select(s => s.AccountId);
            var notLecturer = _repoAccount.GetAll().AsQueryable().Where(x => !lecturer.Contains(x.AccountId)).ToList();
            ViewBag.CourseId = new SelectList(_repoCourse.GetAll(), "CourseId", "CourseName");
            ViewBag.AccountID = new SelectList(notLecturer, "AccountId", "FullName");
            //ViewBag.AccountID = new SelectList(_repoAccount.GetAll(), "AccountId", "FullName", register.AccountID);
            return View(register);
        }

        // POST: Admin/Registers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AccountID,CourseId,IsExtraLab,PaidTime,Debt,Price,Status")] Register register)
        {
            if (ModelState.IsValid)
            {
                _repoRegister.Edit(register);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            var lecturer = _repoLecturer.GetAll().Select(s => s.AccountId);
            var notLecturer = _repoAccount.GetAll().AsQueryable().Where(x => !lecturer.Contains(x.AccountId)).ToList();
            ViewBag.CourseId = new SelectList(_repoCourse.GetAll(), "CourseId", "CourseName");
            ViewBag.AccountID = new SelectList(notLecturer, "AccountId", "FullName");
            //ViewBag.AccountID = new SelectList(_repoAccount.GetAll(), "AccountId", "FullName", register.AccountID);
            return View(register);
        }

        // GET: Admin/Registers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Register register = _repoRegister.Get(id);
            if (register == null)
            {
                return HttpNotFound();
            }
            return View(register);
        }

        // POST: Admin/Registers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Register register = _repoRegister.Get(id);
            _repoRegister.Remove(register);
            //Register register = db.Registers.Find(id);
            //db.Registers.Remove(register);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Classification([Bind(Include = "AccountID,CourseId,IsExtraLab,PaidTime,Debt,Price,Status")] Register register)
        {
            if (ModelState.IsValid)
            {
                _repoRegister.Edit(register);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            var lecturer = _repoLecturer.GetAll().Select(s => s.AccountId);
            var notLecturer = _repoAccount.GetAll().AsQueryable().Where(x => !lecturer.Contains(x.AccountId)).ToList();
            ViewBag.CourseId = new SelectList(_repoCourse.GetAll(), "CourseId", "CourseName");
            ViewBag.AccountID = new SelectList(notLecturer, "AccountId", "FullName");
            //ViewBag.AccountID = new SelectList(_repoAccount.GetAll(), "AccountId", "FullName", register.AccountID);
            return View(register);
        }

        public ActionResult LoadClassification()
        {
            int id = 1;
            Student student = _studentRepository.Get(id);
            return PartialView("~/Views/Shared/_Classification.cshtml", student);
        }
        /*protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }*/
    }
}
