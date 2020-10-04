using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using EduService;
using EduService.Models;
using EduService.Repository;

namespace EduWeb.Areas.Admin.Controllers
{
    public class ProgramsController : Controller
    {
        //private EdumarkDBContext db = new EdumarkDBContext();

        Repository<Program> _program;
        Repository<Course> _course;
        Repository<Subject> _subject;

        public ProgramsController()
        {
            _program = new Repository<Program>();
            _course = new Repository<Course>();
            _subject = new Repository<Subject>();
        }
        // GET: Admin/Programs
        public ActionResult Index()
        {
            var programs = _program.GetAll().AsQueryable().Include(p => p.Course).Include(p => p.Subject);
            //var programs = db.Programs.Include(p => p.Course).Include(p => p.Subject);
            return View(programs.ToList());
        }

        // GET: Admin/Programs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Program program = _program.GetAll().AsQueryable().Include(p => p.Course).Include(p => p.Subject).FirstOrDefault(l => l.ProgramId == id);
            //Program program = db.Programs.Find(id);
            if (program == null)
            {
                return HttpNotFound();
            }
            return View(program);
        }

        // GET: Admin/Programs/Create
        public ActionResult Create(int id)
        {
            var program = _program.GetAll().Where(p => p.CourseId == id).Select(l => l.SubjectId);
            var dataSelect = _subject.GetAll().AsEnumerable().Where(x => !program.Contains(x.SubjectId));
            ViewBag.CourseId = new SelectList(_course.GetAll().Where(x => x.CourseId == id), "CourseId", "CourseName");
            ViewBag.SubjectId = new SelectList(dataSelect, "SubjectId", "Name");
            //ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName");
            //ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectId", "Name")
            return View();
        }

        // POST: Admin/Programs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProgramId,CourseId,SubjectId")] Program program)
        {
            if (ModelState.IsValid)
            {   
                _program.Add(program);
                //db.Programs.Add(program);
                //db.SaveChanges();
                return RedirectToAction("Details", "Courses", new{ id = program.CourseId});
            }

            //Course course = _course.Get(id);
            //ViewBag.CourseId = new ListItem(course.CourseName, course.CourseId.ToString());
            //ViewBag.CourseId = new SelectList(_course.GetAll(), "CourseId", "CourseName", program.CourseId);
            ViewBag.SubjectId = new SelectList(_subject.GetAll(), "SubjectId", "Name", program.SubjectId);
            //ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName", program.CourseId);
            //ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectId", "Name", program.SubjectId);
            return View(program);
        }

        // GET: Admin/Programs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Program program = _program.Get(id);
            //Program program = db.Programs.Find(id);
            if (program == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(_course.GetAll(), "CourseId", "CourseName", program.CourseId);
            ViewBag.SubjectId = new SelectList(_subject.GetAll(), "SubjectId", "Name", program.SubjectId);

            //ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName", program.CourseId);
            //ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectId", "Name", program.SubjectId);
            return View(program);
        }

        // POST: Admin/Programs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProgramId,CourseId,SubjectId")] Program program)
        {
            if (ModelState.IsValid)
            {
                _program.Edit(program);
                //db.Entry(program).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(_course.GetAll(), "CourseId", "CourseName", program.CourseId);
            ViewBag.SubjectId = new SelectList(_subject.GetAll(), "SubjectId", "Name", program.SubjectId);

            //ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName", program.CourseId);
            //ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectId", "Name", program.SubjectId);
            return View(program);
        }

        // GET: Admin/Programs/Delete/5
        public ActionResult Delete(int? id)
        {
            Program program = _program.Get(id);
            _program.Remove(program);
            return RedirectToAction("Details", "Courses", new { id = program.CourseId });
            /*if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Program program = _program.Get(id);
            //Program program = db.Programs.Find(id);
            if (program == null)
            {
                return HttpNotFound();
            }
            return View(program);*/
        }

        // POST: Admin/Programs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Program program = _program.Get(id);
            _program.Remove(program);
            //Program program = db.Programs.Find(id);
            //db.Programs.Remove(program);
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
