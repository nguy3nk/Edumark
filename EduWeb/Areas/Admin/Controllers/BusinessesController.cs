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
    public class BusinessesController : Controller
    {
        //private EdumarkDBContext db = new EdumarkDBContext();

        Repository<Business> _busiRepository;

        public BusinessesController()
        {
            _busiRepository = new Repository<Business>();
        }
        // GET: Admin/Businesses
        public ActionResult Index()
        {
            return View(_busiRepository.GetAll().ToList());
            //return View(db.Businesses.ToList());
        }

        // GET: Admin/Businesses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Business business = _busiRepository.Get(id);
            //Business business = db.Businesses.Find(id);
            if (business == null)
            {
                return HttpNotFound();
            }
            return View(business);
        }

        // GET: Admin/Businesses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Businesses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BusniessId,Status,BusniessName")] Business business)
        {
            if (ModelState.IsValid)
            {
                _busiRepository.Add(business);
                //db.Businesses.Add(business);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(business);
        }

        // GET: Admin/Businesses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Business business = _busiRepository.Get(id);
            //Business business = db.Businesses.Find(id);
            if (business == null)
            {
                return HttpNotFound();
            }
            return View(business);
        }

        // POST: Admin/Businesses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BusniessId,Status,BusniessName")] Business business)
        {
            if (ModelState.IsValid)
            {
                _busiRepository.Edit(business);
                //db.Entry(business).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(business);
        }

        // GET: Admin/Businesses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Business business = _busiRepository.Get(id);
            //Business business = db.Businesses.Find(id);
            if (business == null)
            {
                return HttpNotFound();
            }
            return View(business);
        }

        // POST: Admin/Businesses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Business business = _busiRepository.Get(id);
            _busiRepository.Remove(business);
            //Business business = db.Businesses.Find(id);
            //db.Businesses.Remove(business);
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
