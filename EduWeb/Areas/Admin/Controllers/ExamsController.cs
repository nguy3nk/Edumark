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
    public class ExamsController : Controller
    {
        //private EdumarkDBContext db = new EdumarkDBContext();

        Repository<Exam> _exam;
        Repository<Class> _class;
        Repository<Program> _program;
        Repository<Subject> _subject;
        Repository<Course> _course;

        public ExamsController()
        {
            _exam = new Repository<Exam>();
            _class = new Repository<Class>();
            _program = new Repository<Program>();
            _subject = new Repository<Subject>();
            _course = new Repository<Course>();
        }
        // GET: Admin/Exams
        public ActionResult Index()
        {
            var classes = _class.GetAll().AsQueryable().Include(e => e.Lecturer).Include(e => e.Lecturer.Account);
            //var exams = _exam.GetAll().AsQueryable().Include(e => e.Class).Include(e => e.Program);
            //var exams = db.Exams.Include(e => e.Class).Include(e => e.Program);
            return View(classes.ToList());
            //return View(exams.ToList());
        }

        // GET: Admin/Exams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Class @class = _class.GetAll().AsQueryable().Include(e => e.Exams).Include(e => e.Lecturer.Account).Include(e => e.Course.Programs.Select(x=> x.Subject)).FirstOrDefault();
            //Exam exam = _exam.GetAll().AsQueryable().Include(c => c.Class).Include(e => e.Program).FirstOrDefault(x => x.ExamId == id);
            //Exam exam = db.Exams.Find(id);
            if (@class == null)
            {
                return HttpNotFound();
            }
            return View(@class);
        }

        // GET: Admin/Exams/Create
        public ActionResult Create(int id)
        {

            var program = _exam.GetAll().Where(p => p.ClassId == id).Select(l => l.ProgramId);
            var dataSelect = _program.GetAll().AsQueryable().Include(x => x.Subject).Where(x => !program.Contains(x.ProgramId));
            ViewBag.ClassId = new SelectList(_class.GetAll().Where(x => x.ClassId == id), "ClassId", "ClassName");
            ViewBag.ProgramId = new SelectList(dataSelect, "ProgramId", "Subject.Name");
            //ViewBag.ClassId = new SelectList(db.Classes, "ClassId", "ClassName");
            //ViewBag.ProgramId = new SelectList(db.Programs, "ProgramId", "ProgramId");
            return View();
        }

        // POST: Admin/Exams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExamId,ExamTime,ProgramId,ClassId")] Exam exam)
        {
            if (ModelState.IsValid)
            {
                _exam.Add(exam);
                //db.Exams.Add(exam);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassId = new SelectList(_class.GetAll(), "ClassId", "ClassName", exam.ClassId);
            ViewBag.ProgramId = new SelectList(_program.GetAll(), "ProgramId", "ProgramId", exam.ProgramId);

            //ViewBag.ClassId = new SelectList(db.Classes, "ClassId", "ClassName", exam.ClassId);
            //ViewBag.ProgramId = new SelectList(db.Programs, "ProgramId", "ProgramId", exam.ProgramId);
            return View(exam);
        }

        // GET: Admin/Exams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = _exam.Get(id);
            //Exam exam = db.Exams.Find(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassId = new SelectList(_class.GetAll(), "ClassId", "ClassName", exam.ClassId);
            ViewBag.ProgramId = new SelectList(_program.GetAll(), "ProgramId", "ProgramId", exam.ProgramId);
            //ViewBag.ClassId = new SelectList(db.Classes, "ClassId", "ClassName", exam.ClassId);
            //ViewBag.ProgramId = new SelectList(db.Programs, "ProgramId", "ProgramId", exam.ProgramId);
            return View(exam);
        }

        // POST: Admin/Exams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExamId,ExamTime,ProgramId,ClassId")] Exam exam)
        {
            if (ModelState.IsValid)
            {
                _exam.Edit(exam);
                //db.Entry(exam).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassId = new SelectList(_class.GetAll(), "ClassId", "ClassName", exam.ClassId);
            ViewBag.ProgramId = new SelectList(_program.GetAll(), "ProgramId", "ProgramId", exam.ProgramId);
            //ViewBag.ClassId = new SelectList(db.Classes, "ClassId", "ClassName", exam.ClassId);
            //ViewBag.ProgramId = new SelectList(db.Programs, "ProgramId", "ProgramId", exam.ProgramId);
            return View(exam);
        }

        // GET: Admin/Exams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = _exam.Get(id);
            //Exam exam = db.Exams.Find(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            return View(exam);
        }

        // POST: Admin/Exams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Exam exam = _exam.Get(id);
            _exam.Remove(exam);
            //Exam exam = db.Exams.Find(id);
            //db.Exams.Remove(exam);
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
