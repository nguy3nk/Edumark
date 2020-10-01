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
    public class SubjectsController : Controller
    {
        //private EdumarkDBContext db = new EdumarkDBContext();

        Repository<Subject> _subject;

        public SubjectsController()
        {
            _subject = new Repository<Subject>();
        }
        // GET: Admin/Subjects
        public ActionResult Index()
        {
            return View(_subject.GetAll().ToList());
            //return View(db.Subjects.ToList());
        }

        // GET: Admin/Subjects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = _subject.Get(id);
            //Subject subject = db.Subjects.Find(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            return View(subject);
        }

        // GET: Admin/Subjects/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Subjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SubjectId,Session,Name")] Subject subject)
        {
            if (ModelState.IsValid)
            {
                _subject.Add(subject);
                //db.Subjects.Add(subject);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(subject);
        }

        // GET: Admin/Subjects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = _subject.Get(id);
            //Subject subject = db.Subjects.Find(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            return View(subject);
        }

        // POST: Admin/Subjects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SubjectId,Session,Name")] Subject subject)
        {
            if (ModelState.IsValid)
            {
                _subject.Edit(subject);
                //db.Entry(subject).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(subject);
        }

        // GET: Admin/Subjects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = _subject.Get(id);
            //Subject subject = db.Subjects.Find(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            return View(subject);
        }

        // POST: Admin/Subjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Subject subject = _subject.Get(id);
            _subject.Remove(subject);
            //Subject subject = db.Subjects.Find(id);
            //db.Subjects.Remove(subject);
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
