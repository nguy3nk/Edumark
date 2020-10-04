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
    public class CoursesController : Controller
    {
        //private EdumarkDBContext db = new EdumarkDBContext();

        Repository<Course> _course;
        Repository<Program> _program;
        Repository<Subject> _subject;

        public CoursesController()
        {
            _course = new Repository<Course>();
            _program = new Repository<Program>();
            _subject = new Repository<Subject>();
        }
        // GET: Admin/Courses
        public ActionResult Index()
        {
            return View(_course.GetAll().ToList());
            //return View(db.Courses.ToList());
        }

        // GET: Admin/Courses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = _course.Get(id);
            ICollection<Program> programs = _program.GetAll().AsQueryable().Include(p => p.Course).Include(p => p.Subject).Where(x => x.CourseId == course.CourseId).ToList();
            //ICollection<Program> programs = _program.GetAll().AsQueryable().Where(x => x.CourseId == course.CourseId).Include(p => p.Subject).ToList();
            course.Programs = programs;
            //Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // GET: Admin/Courses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseId,CourseName,Description,Image,Price,SalePrice")] Course course)
        {
            if (ModelState.IsValid)
            {
                _course.Add(course);
                //db.Courses.Add(course);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(course);
        }

        // GET: Admin/Courses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = _course.Get(id);
            ICollection<Program> programs = _program.GetAll().AsQueryable().Include(p => p.Course).Include(p => p.Subject).Where(x => x.CourseId == course.CourseId).ToList();
            //ICollection<Program> programs = _program.GetAll().AsQueryable().Where(x => x.CourseId == course.CourseId).Include(p => p.Subject).ToList();
            course.Programs = programs;
            //Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Admin/Courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseId,CourseName,Description,Image,Price,SalePrice")] Course course)
        {
            if (ModelState.IsValid)
            {
                _course.Edit(course);
                //db.Entry(course).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(course);
        }

        // GET: Admin/Courses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = _course.Get(id);
            //Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Admin/Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = _course.Get(id);
            _course.Remove(course);
            //Course course = db.Courses.Find(id);
            //db.Courses.Remove(course);
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
