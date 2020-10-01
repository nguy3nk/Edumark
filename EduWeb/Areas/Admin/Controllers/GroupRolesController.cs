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
    public class GroupRolesController : Controller
    {
        //private EdumarkDBContext db = new EdumarkDBContext();

        Repository<Group> _group;
        Repository<GroupRole> _groupRole;
        Repository<Business> _business;
        Repository<Role> _role;

        public GroupRolesController()
        {
            _group = new Repository<Group>();
            _groupRole = new Repository<GroupRole>();
            _business = new Repository<Business>();
            _role = new Repository<Role>();
        }
        // GET: Admin/GroupRoles
        public ActionResult Index()
        {
            var groupRoles = _groupRole.GetAll().AsQueryable().Include(g => g.Business).Include(g => g.Group).Include(g => g.Role);
            //var groupRoles = db.GroupRoles.Include(g => g.Business).Include(g => g.Group).Include(g => g.Role);
            return View(groupRoles.ToList());
        }

        // GET: Admin/GroupRoles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupRole groupRole = _groupRole.Get(id);
            //GroupRole groupRole = db.GroupRoles.Find(id);
            if (groupRole == null)
            {
                return HttpNotFound();
            }
            return View(groupRole);
        }

        // GET: Admin/GroupRoles/Create
        public ActionResult Create()
        {
            ViewBag.BusinessId = new SelectList(_business.GetAll(), "BusniessId", "BusniessName");
            ViewBag.GroupId = new SelectList(_group.GetAll(), "GroupId", "GroupName");
            ViewBag.RoleId = new SelectList(_role.GetAll(), "RoleId", "RoleName");
            //ViewBag.BusinessId = new SelectList(db.Businesses, "BusniessId", "BusniessName");
            //ViewBag.GroupId = new SelectList(db.Groups, "GroupId", "GroupName");
            //ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "RoleName");
            return View();
        }

        // POST: Admin/GroupRoles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GroupId,BusinessId,RoleId")] GroupRole groupRole)
        {
            if (ModelState.IsValid)
            {
                _groupRole.Add(groupRole);
                //db.GroupRoles.Add(groupRole);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BusinessId = new SelectList(_business.GetAll(), "BusniessId", "BusniessName", groupRole.BusinessId);
            ViewBag.GroupId = new SelectList(_group.GetAll(), "GroupId", "GroupName", groupRole.GroupId);
            ViewBag.RoleId = new SelectList(_role.GetAll(), "RoleId", "RoleName", groupRole.RoleId);
            //ViewBag.BusinessId = new SelectList(db.Businesses, "BusniessId", "BusniessName", groupRole.BusinessId);
            //ViewBag.GroupId = new SelectList(db.Groups, "GroupId", "GroupName", groupRole.GroupId);
            //ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "RoleName", groupRole.RoleId);
            return View(groupRole);
        }

        // GET: Admin/GroupRoles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupRole groupRole = _groupRole.Get(id);
            //GroupRole groupRole = db.GroupRoles.Find(id);
            if (groupRole == null)
            {
                return HttpNotFound();
            }

            ViewBag.BusinessId = new SelectList(_business.GetAll(), "BusniessId", "BusniessName", groupRole.BusinessId);
            ViewBag.GroupId = new SelectList(_group.GetAll(), "GroupId", "GroupName", groupRole.GroupId);
            ViewBag.RoleId = new SelectList(_role.GetAll(), "RoleId", "RoleName", groupRole.RoleId);
            //ViewBag.BusinessId = new SelectList(db.Businesses, "BusniessId", "BusniessName", groupRole.BusinessId);
            //ViewBag.GroupId = new SelectList(db.Groups, "GroupId", "GroupName", groupRole.GroupId);
            //ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "RoleName", groupRole.RoleId);
            return View(groupRole);
        }

        // POST: Admin/GroupRoles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GroupId,BusinessId,RoleId")] GroupRole groupRole)
        {
            if (ModelState.IsValid)
            {
                _groupRole.Edit(groupRole);
                //db.Entry(groupRole).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BusinessId = new SelectList(_business.GetAll(), "BusniessId", "BusniessName", groupRole.BusinessId);
            ViewBag.GroupId = new SelectList(_group.GetAll(), "GroupId", "GroupName", groupRole.GroupId);
            ViewBag.RoleId = new SelectList(_role.GetAll(), "RoleId", "RoleName", groupRole.RoleId);
            //ViewBag.BusinessId = new SelectList(db.Businesses, "BusniessId", "BusniessName", groupRole.BusinessId);
            //ViewBag.GroupId = new SelectList(db.Groups, "GroupId", "GroupName", groupRole.GroupId);
            //ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "RoleName", groupRole.RoleId);
            return View(groupRole);
        }

        // GET: Admin/GroupRoles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupRole groupRole = _groupRole.Get(id);
            //GroupRole groupRole = db.GroupRoles.Find(id);
            if (groupRole == null)
            {
                return HttpNotFound();
            }
            return View(groupRole);
        }

        // POST: Admin/GroupRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GroupRole groupRole = _groupRole.Get(id);
            _groupRole.Remove(groupRole);
            //GroupRole groupRole = db.GroupRoles.Find(id);
            //db.GroupRoles.Remove(groupRole);
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
