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

        public ExamsController()
        {
            _exam = new Repository<Exam>();
            _class = new Repository<Class>();
            _program = new Repository<Program>();
        }
        // GET: Admin/Exams
        public ActionResult Index()
        {
            var exams = _exam.GetAll().AsQueryable().Include(e => e.Class).Include(e => e.Program);
            //var exams = db.Exams.Include(e => e.Class).Include(e => e.Program);
            return View(exams.ToList());
        }

        // GET: Admin/Exams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = _exam.GetAll().AsQueryable().Include(c => c.Class).Include(e => e.Program).FirstOrDefault(x => x.ExamId == id);
            //Exam exam = db.Exams.Find(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            return View(exam);
        }

        // GET: Admin/Exams/Create
        public ActionResult Create()
        {
            ViewBag.ClassId = new SelectList(_class.GetAll(), "ClassId", "ClassName");
            ViewBag.ProgramId = new SelectList(_program.GetAll(), "ProgramId", "ProgramId");
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
