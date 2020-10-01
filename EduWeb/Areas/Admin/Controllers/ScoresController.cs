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
    public class ScoresController : Controller
    {
        //private EdumarkDBContext db = new EdumarkDBContext();

        Repository<Score> _score;
        Repository<Exam> _exam;
        Repository<Class> _class;
        Repository<Student> _student;

        public ScoresController()
        {
            _score = new Repository<Score>();
            _exam = new Repository<Exam>();
            _class = new Repository<Class>();
            _student = new Repository<Student>();
        }
        // GET: Admin/Scores
        public ActionResult Index()
        {
            var scores = _score.GetAll().AsQueryable().Include(s => s.Exam).Include(s => s.Student);
            //var scores = db.Scores.Include(s => s.Exam).Include(s => s.Student);
            return View(scores.ToList());
        }

        // GET: Admin/Scores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Score score = _score.Get(id);
            //Score score = db.Scores.Find(id);
            if (score == null)
            {
                return HttpNotFound();
            }
            return View(score);
        }

        // GET: Admin/Scores/Create
        public ActionResult Create()
        {
            ViewBag.ExamId = new SelectList(_class.GetAll(), "ClassId", "ClassName");
            ViewBag.StudentId = new SelectList(_student.GetAll(), "AccountId", "AccountId");
            //ViewBag.ExamId = new SelectList(db.Classes, "ClassId", "ClassName");
            //ViewBag.StudentId = new SelectList(db.Students, "AccountId", "AccountId");
            return View();
        }

        // POST: Admin/Scores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExamId,StudentId,Value")] Score score)
        {
            if (ModelState.IsValid)
            {
                _score.Add(score);
                //db.Scores.Add(score);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ExamId = new SelectList(_class.GetAll(), "ClassId", "ClassName", score.ExamId);
            ViewBag.StudentId = new SelectList(_student.GetAll(), "AccountId", "AccountId", score.StudentId);
            return View(score);
        }

        // GET: Admin/Scores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Score score = _score.Get(id);
            //Score score = db.Scores.Find(id);
            if (score == null)
            {
                return HttpNotFound();
            }
            ViewBag.ExamId = new SelectList(_class.GetAll(), "ClassId", "ClassName", score.ExamId);
            ViewBag.StudentId = new SelectList(_student.GetAll(), "AccountId", "AccountId", score.StudentId);
            //ViewBag.ExamId = new SelectList(db.Classes, "ClassId", "ClassName", score.ExamId);
            //ViewBag.StudentId = new SelectList(db.Students, "AccountId", "AccountId", score.StudentId);
            return View(score);
        }

        // POST: Admin/Scores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExamId,StudentId,Value")] Score score)
        {
            if (ModelState.IsValid)
            {
                _score.Edit(score);
                //db.Entry(score).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ExamId = new SelectList(_class.GetAll(), "ClassId", "ClassName", score.ExamId);
            ViewBag.StudentId = new SelectList(_student.GetAll(), "AccountId", "AccountId", score.StudentId);
            return View(score);
        }

        // GET: Admin/Scores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Score score = _score.Get(id);
            //Score score = db.Scores.Find(id);
            if (score == null)
            {
                return HttpNotFound();
            }
            return View(score);
        }

        // POST: Admin/Scores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Score score = _score.Get(id);
            _score.Remove(score);
            //Score score = db.Scores.Find(id);
            //db.Scores.Remove(score);
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
