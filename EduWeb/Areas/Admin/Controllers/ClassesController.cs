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
    public class ClassesController : Controller
    {
        //private EdumarkDBContext db = new EdumarkDBContext();

        Repository<Class> _classRepository;
        Repository<Course> _courseRepository;
        Repository<Lecturer> _lecRepository;

        public ClassesController()
        {
            _classRepository = new Repository<Class>();
            _courseRepository = new Repository<Course>();
            _lecRepository = new Repository<Lecturer>();
        }
        // GET: Admin/Classes
        public ActionResult Index()
        {
            var classes = _classRepository.GetAll().AsQueryable().Include(c => c.Course).Include(c => c.Lecturer);
            //var classes = db.Classes.Include(c => c.Course).Include(c => c.Lecturer);
            return View(classes.ToList());
        }

        // GET: Admin/Classes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Class @class = _classRepository.GetAll().AsQueryable().Include(c => c.Course).Include(c => c.Lecturer).FirstOrDefault(x => x.ClassId == id);
            //Class @class = db.Classes.Find(id);
            if (@class == null)
            {
                return HttpNotFound();
            }
            return View(@class);
        }

        // GET: Admin/Classes/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(_courseRepository.GetAll(), "CourseId", "CourseName");
            ViewBag.LecturerId = new SelectList(_lecRepository.GetAll(), "AccountId", "Faculty");
            //ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName");
            //ViewBag.LecturerId = new SelectList(db.Lecturers, "AccountId", "Faculty");
            return View();
        }

        // POST: Admin/Classes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClassId,ClassName,StartTime,EndTime,CourseId,LecturerId")] Class @class)
        {
            if (ModelState.IsValid)
            {
                _classRepository.Add(@class);
                //db.Classes.Add(@class);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(_courseRepository.GetAll(), "CourseId", "CourseName", @class.CourseId);
            ViewBag.LecturerId = new SelectList(_lecRepository.GetAll(), "AccountId", "Faculty", @class.LecturerId);

            //ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName", @class.CourseId);
            //ViewBag.LecturerId = new SelectList(db.Lecturers, "AccountId", "Faculty", @class.LecturerId);
            return View(@class);
        }

        // GET: Admin/Classes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Class @class = _classRepository.Get(id);
            //Class @class = db.Classes.Find(id);
            if (@class == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(_courseRepository.GetAll(), "CourseId", "CourseName", @class.CourseId);
            ViewBag.LecturerId = new SelectList(_lecRepository.GetAll(), "AccountId", "Faculty", @class.LecturerId);
            //ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName", @class.CourseId);
            //ViewBag.LecturerId = new SelectList(db.Lecturers, "AccountId", "Faculty", @class.LecturerId);
            return View(@class);
        }

        // POST: Admin/Classes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClassId,ClassName,StartTime,EndTime,CourseId,LecturerId")] Class @class)
        {
            if (ModelState.IsValid)
            {
                _classRepository.Edit(@class);
                //db.Entry(@class).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(_courseRepository.GetAll(), "CourseId", "CourseName", @class.CourseId);
            ViewBag.LecturerId = new SelectList(_lecRepository.GetAll(), "AccountId", "Faculty", @class.LecturerId);
            //ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName", @class.CourseId);
            //ViewBag.LecturerId = new SelectList(db.Lecturers, "AccountId", "Faculty", @class.LecturerId);
            return View(@class);
        }

        // GET: Admin/Classes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Class @class = _classRepository.Get(id);
            //Class @class = db.Classes.Find(id);
            if (@class == null)
            {
                return HttpNotFound();
            }
            return View(@class);
        }

        // POST: Admin/Classes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Class @class = _classRepository.Get(id);
            _classRepository.Remove(@class);
            //Class @class = db.Classes.Find(id);
            //db.Classes.Remove(@class);
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
