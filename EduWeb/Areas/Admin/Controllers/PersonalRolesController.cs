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
    public class PersonalRolesController : Controller
    {
        //private EdumarkDBContext db = new EdumarkDBContext();

        Repository<PersonalRole> _person;
        Repository<Account> _account;
        Repository<Business> _business;
        Repository<Role> _role;

        public PersonalRolesController()
        {
            _person = new Repository<PersonalRole>();
            _account = new Repository<Account>();
            _business = new Repository<Business>();
            _role = new Repository<Role>();
        }
        // GET: Admin/PersonalRoles
        public ActionResult Index()
        {
            var personalRoles = _person.GetAll().AsQueryable().Include(p => p.Account).Include(p => p.Business).Include(p => p.Role);
            //var personalRoles = db.PersonalRoles.Include(p => p.Account).Include(p => p.Business).Include(p => p.Role);
            return View(personalRoles.ToList());
        }

        // GET: Admin/PersonalRoles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalRole personalRole = _person.Get(id);
            //PersonalRole personalRole = db.PersonalRoles.Find(id);
            if (personalRole == null)
            {
                return HttpNotFound();
            }
            return View(personalRole);
        }

        // GET: Admin/PersonalRoles/Create
        public ActionResult Create()
        {
            ViewBag.AccountId = new SelectList(_account.GetAll(), "AccountId", "Username");
            ViewBag.BusinessId = new SelectList(_business.GetAll(), "BusniessId", "BusniessName");
            ViewBag.RoleId = new SelectList(_role.GetAll(), "RoleId", "RoleName");
            //ViewBag.AccountId = new SelectList(db.Accounts, "AccountId", "Username");
            //ViewBag.BusinessId = new SelectList(db.Businesses, "BusniessId", "BusniessName");
            //ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "RoleName");
            return View();
        }

        // POST: Admin/PersonalRoles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AccountId,BusinessId,RoleId")] PersonalRole personalRole)
        {
            if (ModelState.IsValid)
            {
                _person.Add(personalRole);
                //db.PersonalRoles.Add(personalRole);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccountId = new SelectList(_account.GetAll(), "AccountId", "Username", personalRole.AccountId);
            ViewBag.BusinessId = new SelectList(_business.GetAll(), "BusniessId", "BusniessName", personalRole.BusinessId);
            ViewBag.RoleId = new SelectList(_role.GetAll(), "RoleId", "RoleName", personalRole.RoleId);

            //ViewBag.AccountId = new SelectList(db.Accounts, "AccountId", "Username", personalRole.AccountId);
            //ViewBag.BusinessId = new SelectList(db.Businesses, "BusniessId", "BusniessName", personalRole.BusinessId);
            //ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "RoleName", personalRole.RoleId);
            return View(personalRole);
        }

        // GET: Admin/PersonalRoles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalRole personalRole = _person.Get(id);
            //PersonalRole personalRole = db.PersonalRoles.Find(id);
            if (personalRole == null)
            {
                return HttpNotFound();
            }

            ViewBag.AccountId = new SelectList(_account.GetAll(), "AccountId", "Username", personalRole.AccountId);
            ViewBag.BusinessId = new SelectList(_business.GetAll(), "BusniessId", "BusniessName", personalRole.BusinessId);
            ViewBag.RoleId = new SelectList(_role.GetAll(), "RoleId", "RoleName", personalRole.RoleId);

            //ViewBag.AccountId = new SelectList(db.Accounts, "AccountId", "Username", personalRole.AccountId);
            //ViewBag.BusinessId = new SelectList(db.Businesses, "BusniessId", "BusniessName", personalRole.BusinessId);
            //ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "RoleName", personalRole.RoleId);
            return View(personalRole);
        }

        // POST: Admin/PersonalRoles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AccountId,BusinessId,RoleId")] PersonalRole personalRole)
        {
            if (ModelState.IsValid)
            {
                _person.Edit(personalRole);
                //db.Entry(personalRole).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccountId = new SelectList(_account.GetAll(), "AccountId", "Username", personalRole.AccountId);
            ViewBag.BusinessId = new SelectList(_business.GetAll(), "BusniessId", "BusniessName", personalRole.BusinessId);
            ViewBag.RoleId = new SelectList(_role.GetAll(), "RoleId", "RoleName", personalRole.RoleId);

            //ViewBag.AccountId = new SelectList(db.Accounts, "AccountId", "Username", personalRole.AccountId);
            //ViewBag.BusinessId = new SelectList(db.Businesses, "BusniessId", "BusniessName", personalRole.BusinessId);
            //ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "RoleName", personalRole.RoleId);
            return View(personalRole);
        }

        // GET: Admin/PersonalRoles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalRole personalRole = _person.Get(id);
            //PersonalRole personalRole = db.PersonalRoles.Find(id);
            if (personalRole == null)
            {
                return HttpNotFound();
            }
            return View(personalRole);
        }

        // POST: Admin/PersonalRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PersonalRole personalRole = _person.Get(id);
            _person.Remove(personalRole);
            //PersonalRole personalRole = db.PersonalRoles.Find(id);
            //db.PersonalRoles.Remove(personalRole);
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
