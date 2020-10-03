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
    public class AccountsController : Controller
    {
        //private EdumarkDBContext db = new EdumarkDBContext();
        Repository<Account> _accountRepository;
        Repository<Group> _groupRepository;
        Repository<PersonalRole> _personRepository;
        // GET: Admin/Accounts
        public AccountsController()
        {
            _accountRepository = new Repository<Account>();
            _personRepository = new Repository<PersonalRole>();
            _groupRepository = new Repository<Group>();
        }
        public ActionResult Index()
        {
            var accounts = _accountRepository.GetAll().AsQueryable().Include(x => x.Group);
            //var accounts = db.Accounts.Include(a => a.Group);
            return View(accounts.ToList());
        }

        // GET: Admin/Accounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = _accountRepository.GetAll().AsQueryable().Include(x => x.Group).FirstOrDefault(x => x.AccountId == id);

            //Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // GET: Admin/Accounts/Create
        public ActionResult Create()
        {
            ViewBag.GroupId = new SelectList(_groupRepository.GetAll(), "GroupId", "GroupName");
            //ViewBag.GroupId = new SelectList(db.Groups, "GroupId", "GroupName");
            return View();
        }

        // POST: Admin/Accounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AccountId,Username,Password,FullName,Email,Address,Phone,Image,GroupId,PersonalId,Birthday,Gender,Status")] Account account)
        {
            if (ModelState.IsValid)
            {
                _accountRepository.Add(account);
                //db.SaveChanges();
                //db.Accounts.Add(account);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GroupId = new SelectList(_groupRepository.GetAll(), "GroupId", "GroupName", account.GroupId);
            //ViewBag.GroupId = new SelectList(db.Groups, "GroupId", "GroupName", account.GroupId);
            return View(account);
        }

        // GET: Admin/Accounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = _accountRepository.Get(id);
            //Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            ViewBag.GroupId = new SelectList(_groupRepository.GetAll(), "GroupId", "GroupName", account.GroupId);
            //ViewBag.GroupId = new SelectList(db.Groups, "GroupId", "GroupName", account.GroupId);
            return View(account);
        }

        // POST: Admin/Accounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AccountId,Username,Password,FullName,Email,Address,Phone,Image,GroupId,PersonalId,Birthday,Gender,Status")] Account account)
        {
            if (ModelState.IsValid)
            {
                _accountRepository.Edit(account);
                //db.Entry(account).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GroupId = new SelectList(_groupRepository.GetAll(), "GroupId", "GroupName", account.GroupId);
            //ViewBag.GroupId = new SelectList(db.Groups, "GroupId", "GroupName", account.GroupId);
            return View(account);
        }

        // GET: Admin/Accounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = _accountRepository.Get(id);
            //Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // POST: Admin/Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Account account = _accountRepository.Get(id);
            _accountRepository.Remove(account);
            //Account account = db.Accounts.Find(id);
            //db.Accounts.Remove(account);
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
