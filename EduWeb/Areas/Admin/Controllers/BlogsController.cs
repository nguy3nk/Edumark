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
using EduWeb.Models;

namespace EduWeb.Areas.Admin.Controllers
{
    public class BlogsController : Controller
    {
        //private EdumarkDBContext db = new EdumarkDBContext();

        Repository<Blog> _blogRepository;
        Repository<BlogPost> _blogPost;

        public BlogsController()
        {
            _blogRepository = new Repository<Blog>();
            _blogPost = new Repository<BlogPost>();
        }
        // GET: Admin/Blogs
        public ActionResult Index()
        {
            return View(_blogRepository.GetAll().ToList());
            //return View(db.Blogs.ToList());
        }

        // GET: Admin/Blogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = _blogRepository.Get(id);
            //Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // GET: Admin/Blogs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Blogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BlogId,BlogName")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                _blogRepository.Add(blog);
                //db.Blogs.Add(blog);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(blog);
        }

        // GET: Admin/Blogs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = _blogRepository.Get(id);
            //Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Admin/Blogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BlogId,BlogName")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                _blogRepository.Edit(blog);
                //db.Entry(blog).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blog);
        }

        // GET: Admin/Blogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = _blogRepository.Get(id);
            //Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Admin/Blogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Xóa thuộc các post thuộc Blog
            _blogPost.RemoveRange(_blogPost.GetBy(x => x.BlogId == id));
            _blogRepository.Remove(id);

            TempData["msg"] = new ResponseMessage()
            {
                Type = "callout-success",
                Message = "DeleteSuccess"
            };
            return RedirectToAction("Index");
            //Blog blog = db.Blogs.Find(id);
            //db.Blogs.Remove(blog);
            //db.SaveChanges();
            //return RedirectToAction("Index");

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
