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
    public class FeedbacksController : Controller
    {
        //private EdumarkDBContext db = new EdumarkDBContext();

        Repository<Feedback> _feedback;
        Repository<Account> _account;
        Repository<Course> _course;

        public FeedbacksController()
        {
            _feedback = new Repository<Feedback>();
            _account = new Repository<Account>();
            _course = new Repository<Course>();
        }
        // GET: Admin/Feedbacks
        public ActionResult Index()
        {
            var feedbacks = _feedback.GetAll().AsQueryable().Include(f => f.Account).Include(f => f.Course);
            //var feedbacks = db.Feedbacks.Include(f => f.Account).Include(f => f.Course);
            return View(feedbacks.ToList());
        }

        // GET: Admin/Feedbacks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feedback feedback = _feedback.GetAll().AsQueryable().Include(f => f.Account).Include(f => f.Course).FirstOrDefault(x => x.FeedbackId == id);
            //Feedback feedback = db.Feedbacks.Find(id);
            if (feedback == null)
            {
                return HttpNotFound();
            }
            return View(feedback);
        }

        // GET: Admin/Feedbacks/Create
        public ActionResult Create()
        {
            ViewBag.AccountId = new SelectList(_account.GetAll(), "AccountId", "Username");
            ViewBag.CourseId = new SelectList(_course.GetAll(), "CourseId", "CourseName");
            //ViewBag.AccountId = new SelectList(db.Accounts, "AccountId", "Username");
            //ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName");
            return View();
        }

        // POST: Admin/Feedbacks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FeedbackId,CourseId,AccountId,ReplyToCommentId,evaluate,CommentContent")] Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                _feedback.Add(feedback);
                //db.Feedbacks.Add(feedback);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccountId = new SelectList(_account.GetAll(), "AccountId", "Username", feedback.AccountId);
            ViewBag.CourseId = new SelectList(_course.GetAll(), "CourseId", "CourseName", feedback.CourseId);
            //ViewBag.AccountId = new SelectList(db.Accounts, "AccountId", "Username", feedback.AccountId);
            //ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName", feedback.CourseId);
            return View(feedback);
        }

        // GET: Admin/Feedbacks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feedback feedback = _feedback.Get(id);
            //Feedback feedback = db.Feedbacks.Find(id);
            if (feedback == null)
            {
                return HttpNotFound();
            }

            ViewBag.AccountId = new SelectList(_account.GetAll(), "AccountId", "Username", feedback.AccountId);
            ViewBag.CourseId = new SelectList(_course.GetAll(), "CourseId", "CourseName", feedback.CourseId);
            //ViewBag.AccountId = new SelectList(db.Accounts, "AccountId", "Username", feedback.AccountId);
            //ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName", feedback.CourseId);
            return View(feedback);
        }

        // POST: Admin/Feedbacks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FeedbackId,CourseId,AccountId,ReplyToCommentId,evaluate,CommentContent")] Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                _feedback.Edit(feedback);
                //db.Entry(feedback).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccountId = new SelectList(_account.GetAll(), "AccountId", "Username", feedback.AccountId);
            ViewBag.CourseId = new SelectList(_course.GetAll(), "CourseId", "CourseName", feedback.CourseId);
            //ViewBag.AccountId = new SelectList(db.Accounts, "AccountId", "Username", feedback.AccountId);
            //ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName", feedback.CourseId);
            return View(feedback);
        }

        // GET: Admin/Feedbacks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feedback feedback = _feedback.Get(id);
            //Feedback feedback = db.Feedbacks.Find(id);
            if (feedback == null)
            {
                return HttpNotFound();
            }
            return View(feedback);
        }

        // POST: Admin/Feedbacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Feedback feedback = _feedback.Get(id);
            _feedback.Remove(feedback);
            //Feedback feedback = db.Feedbacks.Find(id);
            //db.Feedbacks.Remove(feedback);
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
