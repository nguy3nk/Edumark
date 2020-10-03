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
    public class CommentsController : Controller
    {
        //private EdumarkDBContext db = new EdumarkDBContext();

        Repository<Comment> _comment;
        Repository<BlogPost> _post;
        Repository<Account> _account;

        public CommentsController()
        {
            _comment = new Repository<Comment>();
            _post = new Repository<BlogPost>();
            _account = new Repository<Account>();
        }
        // GET: Admin/Comments
        public ActionResult Index()
        {
            var comments = _comment.GetAll().AsQueryable().Include(c => c.Account).Include(c => c.BlogPost);
            //var comments = db.Comments.Include(c => c.Account).Include(c => c.BlogPost);
            return View(comments.ToList());
        }

        // GET: Admin/Comments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = _comment.GetAll().AsQueryable().Include(c => c.Account).Include(c => c.BlogPost).FirstOrDefault(x => x.CommentId == id);
            //Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // GET: Admin/Comments/Create
        public ActionResult Create()
        {
            ViewBag.AccountId = new SelectList(_account.GetAll(), "AccountId", "Username");
            ViewBag.PostId = new SelectList(_post.GetAll(), "PostId", "PostTitle");
            //ViewBag.AccountId = new SelectList(db.Accounts, "AccountId", "Username");
            //ViewBag.PostId = new SelectList(db.BlogPosts, "PostId", "PostTitle");
            return View();
        }

        // POST: Admin/Comments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CommentId,AccountId,CommentContent,PostId,ReplyToCommentId")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                _comment.Add(comment);
                //db.Comments.Add(comment);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccountId = new SelectList(_account.GetAll(), "AccountId", "Username", comment.AccountId);
            ViewBag.PostId = new SelectList(_post.GetAll(), "PostId", "PostTitle", comment.PostId);

            //ViewBag.AccountId = new SelectList(db.Accounts, "AccountId", "Username", comment.AccountId);
            //ViewBag.PostId = new SelectList(db.BlogPosts, "PostId", "PostTitle", comment.PostId);
            return View(comment);
        }

        // GET: Admin/Comments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = _comment.Get(id);
            //Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountId = new SelectList(_account.GetAll(), "AccountId", "Username", comment.AccountId);
            ViewBag.PostId = new SelectList(_post.GetAll(), "PostId", "PostTitle", comment.PostId);
            //ViewBag.AccountId = new SelectList(db.Accounts, "AccountId", "Username", comment.AccountId);
            //ViewBag.PostId = new SelectList(db.BlogPosts, "PostId", "PostTitle", comment.PostId);
            return View(comment);
        }

        // POST: Admin/Comments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CommentId,AccountId,CommentContent,PostId,ReplyToCommentId")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                _comment.Edit(comment);
                //db.Entry(comment).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccountId = new SelectList(_account.GetAll(), "AccountId", "Username", comment.AccountId);
            ViewBag.PostId = new SelectList(_post.GetAll(), "PostId", "PostTitle", comment.PostId);
            //ViewBag.AccountId = new SelectList(db.Accounts, "AccountId", "Username", comment.AccountId);
            //ViewBag.PostId = new SelectList(db.BlogPosts, "PostId", "PostTitle", comment.PostId);
            return View(comment);
        }

        // GET: Admin/Comments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = _comment.Get(id);
            //Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: Admin/Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comment comment = _comment.Get(id);
            _comment.Remove(comment);
            //Comment comment = db.Comments.Find(id);
            //db.Comments.Remove(comment);
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
