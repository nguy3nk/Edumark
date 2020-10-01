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
    public class BlogPostsController : Controller
    {
        //private EdumarkDBContext db = new EdumarkDBContext();

        Repository<Blog> _blogRepository;
        Repository<BlogPost> _postRepository;

        public BlogPostsController()
        {
            _blogRepository = new Repository<Blog>();
            _postRepository = new Repository<BlogPost>();
        }
        // GET: Admin/BlogPosts
        public ActionResult Index()
        {
            var blogPosts = _postRepository.GetAll().AsQueryable().Include(b => b.Blog);
            //var blogPosts = db.BlogPosts.Include(b => b.Blog);
            return View(blogPosts.ToList());
        }

        // GET: Admin/BlogPosts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogPost blogPost = _postRepository.Get(id);
            //BlogPost blogPost = db.BlogPosts.Find(id);
            if (blogPost == null)
            {
                return HttpNotFound();
            }
            ViewBag.BlogId = new SelectList(_blogRepository.GetAll(), "BlogId", "BlogName", blogPost.BlogId);
            return View(blogPost);
        }

        // GET: Admin/BlogPosts/Create
        public ActionResult Create()
        {
            ViewBag.BlogId = new SelectList(_blogRepository.GetAll(), "BlogId", "BlogName");
            //ViewBag.BlogId = new SelectList(db.Blogs, "BlogId", "BlogName");
            return View();
        }

        // POST: Admin/BlogPosts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PostId,BlogId,PostTitle,PostImage,Resource,UploadDate,Author,BlogContent")] BlogPost blogPost)
        {
            if (ModelState.IsValid)
            {
                _postRepository.Add(blogPost);
                //db.BlogPosts.Add(blogPost);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BlogId = new SelectList(_blogRepository.GetAll(), "BlogId", "BlogName", blogPost.BlogId);
            //ViewBag.BlogId = new SelectList(db.Blogs, "BlogId", "BlogName", blogPost.BlogId);
            return View(blogPost);
        }

        // GET: Admin/BlogPosts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogPost blogPost = _postRepository.Get(id);
            //BlogPost blogPost = db.BlogPosts.Find(id);
            if (blogPost == null)
            {
                return HttpNotFound();
            }
            ViewBag.BlogId = new SelectList(_blogRepository.GetAll(), "BlogId", "BlogName", blogPost.BlogId);
            //ViewBag.BlogId = new SelectList(db.Blogs, "BlogId", "BlogName", blogPost.BlogId);
            return View(blogPost);
        }

        // POST: Admin/BlogPosts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PostId,BlogId,PostTitle,PostImage,Resource,UploadDate,Author,BlogContent")] BlogPost blogPost)
        {
            if (ModelState.IsValid)
            {
                _postRepository.Edit(blogPost);
                //db.Entry(blogPost).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BlogId = new SelectList(_blogRepository.GetAll(), "BlogId", "BlogName", blogPost.BlogId);
            //ViewBag.BlogId = new SelectList(db.Blogs, "BlogId", "BlogName", blogPost.BlogId);
            return View(blogPost);
        }

        // GET: Admin/BlogPosts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogPost blogPost = _postRepository.Get(id);
            //BlogPost blogPost = db.BlogPosts.Find(id);
            if (blogPost == null)
            {
                return HttpNotFound();
            }
            return View(blogPost);
        }

        // POST: Admin/BlogPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BlogPost blogPost = _postRepository.Get(id);
            _postRepository.Remove(blogPost);
            //BlogPost blogPost = db.BlogPosts.Find(id);
            //db.BlogPosts.Remove(blogPost);
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
