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
    public class ExtralabsController : Controller
    {
        //private EdumarkDBContext db = new EdumarkDBContext();

        Repository<Extralab> _extra;
        Repository<Course> _course;

        public ExtralabsController()
        {
            _extra = new Repository<Extralab>();
            _course = new Repository<Course>();
        }
        // GET: Admin/Extralabs
        public ActionResult Index()
        {
            var extralabs = _extra.GetAll().AsQueryable().Include(e => e.Course);
            //var extralabs = db.Extralabs.Include(e => e.Course);
            return View(extralabs.ToList());
        }

        // GET: Admin/Extralabs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Extralab extralab = _extra.Get(id);
            //Extralab extralab = db.Extralabs.Find(id);
            if (extralab == null)
            {
                return HttpNotFound();
            }
            return View(extralab);
        }

        // GET: Admin/Extralabs/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(_course.GetAll(), "CourseId", "CourseName");
            //ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName");
            return View();
        }

        // POST: Admin/Extralabs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseId,Session,Price,ClassId")] Extralab extralab)
        {
            if (ModelState.IsValid)
            {
                _extra.Add(extralab);
                //db.Extralabs.Add(extralab);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(_course.GetAll(), "CourseId", "CourseName", extralab.CourseId);
            //ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName", extralab.CourseId);
            return View(extralab);
        }

        // GET: Admin/Extralabs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Extralab extralab = _extra.Get(id);
            //Extralab extralab = db.Extralabs.Find(id);
            if (extralab == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(_course.GetAll(), "CourseId", "CourseName", extralab.CourseId);
            //ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName", extralab.CourseId);
            return View(extralab);
        }

        // POST: Admin/Extralabs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseId,Session,Price,ClassId")] Extralab extralab)
        {
            if (ModelState.IsValid)
            {
                _extra.Edit(extralab);
                //db.Entry(extralab).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(_course.GetAll(), "CourseId", "CourseName", extralab.CourseId);
            //ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName", extralab.CourseId);
            return View(extralab);
        }

        // GET: Admin/Extralabs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Extralab extralab = _extra.Get(id);
            //Extralab extralab = db.Extralabs.Find(id);
            if (extralab == null)
            {
                return HttpNotFound();
            }
            return View(extralab);
        }

        // POST: Admin/Extralabs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Extralab extralab = _extra.Get(id);
            _extra.Remove(extralab);
            //Extralab extralab = db.Extralabs.Find(id);
            //db.Extralabs.Remove(extralab);
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
