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
    public class StudentsController : Controller
    {
        //private EdumarkDBContext db = new EdumarkDBContext();

        Repository<Student> _student;
        Repository<Lecturer> _lecturer;
        Repository<Class> _class;
        Repository<Account> _account;
        Repository<Register> _register;

        public StudentsController()
        {
            _student = new Repository<Student>();
            _class = new Repository<Class>();
            _account = new Repository<Account>();
            _lecturer = new Repository<Lecturer>();
            _register = new Repository<Register>();
        }
        // GET: Admin/Students
        public ActionResult Index()
        {
            var students = _student.GetAll().AsQueryable().Include(s => s.Account).Include(s => s.Class);
            //var students = db.Students.Include(s => s.Account).Include(s => s.Class);
            return View(students.ToList());
        }

        // GET: Admin/Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = _student.GetAll().AsQueryable().Include(s => s.Account).Include(s => s.Class).FirstOrDefault(s => s.AccountId == id);
            //Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Admin/Students/Create
        public ActionResult Create(int registerId)
        {
            //var lecturer = _lecturer.GetAll().Select(l => l.AccountId);
            //var student = _student.GetAll().Select(s => s.AccountId);
            //var dataSelect = _accountRepository.GetAll().AsQueryable().Where(x => (!_lecRepository.GetAll().AsQueryable().Where(l => l.AccountId == x.AccountId).Any()) && (!_lecRepository.GetAll().AsQueryable().Where(l => l.AccountId == x.AccountId).Any()));
            //var dataSelect = _accountRepository.GetAll();
            Register register = _register.Get(registerId);
            var listAccounts = _account.GetAll().AsQueryable().Where(x => x.AccountId == register.AccountId).ToList();
            var listClasses = _class.GetAll().AsQueryable().Where(x => x.CourseId == register.CourseId).ToList();
            ViewBag.AccountId = new SelectList(listAccounts, "AccountId", "FullName");
            ViewBag.ClassId = new SelectList(listClasses, "ClassId", "ClassName");
            ViewBag.RegisterId = registerId;
            //ViewBag.AccountId = new SelectList(db.Accounts, "AccountId", "Username");
            //ViewBag.ClassId = new SelectList(db.Classes, "ClassId", "ClassName");
            return View();
        }

        // POST: Admin/Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AccountId,StudentId,ClassId")] Student student, int registerId)
        {
            ViewBag.RegisterId = registerId;
            if (ModelState.IsValid)
            {
                if (_student.Add(student))
                    return RedirectToAction("Details", "Registers", new { id = registerId });

                //db.Students.Add(student);
                //db.SaveChanges();
                //return RedirectToAction("Index");
            }
            Register register = _register.Get(registerId);
            var listAccounts = _account.GetAll().AsQueryable().Where(x => x.AccountId == register.AccountId);
            var listClasses = _class.GetAll().AsQueryable().Where(x => x.CourseId == register.CourseId);
            ViewBag.AccountId = new SelectList(listAccounts, "AccountId", "FullName", student.AccountId);
            ViewBag.ClassId = new SelectList(listClasses, "ClassId", "ClassName", student.ClassId);
            //ViewBag.AccountId = new SelectList(db.Accounts, "AccountId", "Username", student.AccountId);
            //ViewBag.ClassId = new SelectList(db.Classes, "ClassId", "ClassName", student.ClassId);
            return View(student);
        }

        // GET: Admin/Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = _student.Get(id);
            //Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountId = new SelectList(_account.GetAll(), "AccountId", "Username", student.AccountId);
            ViewBag.ClassId = new SelectList(_class.GetAll(), "ClassId", "ClassName", student.ClassId);
            //ViewBag.AccountId = new SelectList(db.Accounts, "AccountId", "Username", student.AccountId);
            //ViewBag.ClassId = new SelectList(db.Classes, "ClassId", "ClassName", student.ClassId);
            return View(student);
        }

        // POST: Admin/Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AccountId,StudentId,ClassId")] Student student)
        {
            if (ModelState.IsValid)
            {
                _student.Edit(student);
                //db.Entry(student).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccountId = new SelectList(_account.GetAll(), "AccountId", "Username", student.AccountId);
            ViewBag.ClassId = new SelectList(_class.GetAll(), "ClassId", "ClassName", student.ClassId);
            //ViewBag.AccountId = new SelectList(db.Accounts, "AccountId", "Username", student.AccountId);
            //ViewBag.ClassId = new SelectList(db.Classes, "ClassId", "ClassName", student.ClassId);
            return View(student);
        }

        // GET: Admin/Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = _student.Get(id);
            //Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Admin/Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = _student.Get(id);
            _student.Remove(student);
            //Student student = db.Students.Find(id);
            //db.Students.Remove(student);
            //db.SaveChanges();
            return RedirectToAction("Index");
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
