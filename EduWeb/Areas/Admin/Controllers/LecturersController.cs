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
    public class LecturersController : Controller
    {

        Repository<Lecturer> _lecRepository;
        Repository<Student> _studentRepository;
        Repository<Account> _accountRepository;
        Repository<Group> _groupRepository;
        Repository<PersonalRole> _personRepository;
        //private EdumarkDBContext db = new EdumarkDBContext();
        public LecturersController()
        {
            _lecRepository = new Repository<Lecturer>();
            _studentRepository = new Repository<Student>();
            _accountRepository = new Repository<Account>();
            _groupRepository = new Repository<Group>();
            _personRepository = new Repository<PersonalRole>();
        }
        // GET: Admin/Lecturers
        public ActionResult Index()
        {
            var lecturers = _lecRepository.GetAll().AsQueryable().Include(x => x.Account);
            return View(lecturers.ToList());
        }

        // GET: Admin/Lecturers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lecturer lecturer = _lecRepository.GetAll().AsQueryable().Include(x => x.Account).FirstOrDefault(l => l.AccountId == id);
            //Lecturer lecturer = _lecRepository.Get(id);
            if (lecturer == null)
            {
                return HttpNotFound();
            }
            return View(lecturer);
        }

        // GET: Admin/Lecturers/Create
        public ActionResult Create()
        {
            var lecturer = _lecRepository.GetAll().Select(l => l.AccountId);
            var student = _studentRepository.GetAll().Select(s => s.AccountId);
            var dataSelect = _accountRepository.GetAll().AsEnumerable().Where(x => !lecturer.Contains(x.AccountId)).Where(x => !student.Contains(x.AccountId));
            //var dataSelect = _accountRepository.GetAll().AsQueryable().Where(x => (!_lecRepository.GetAll().AsQueryable().Where(l => l.AccountId == x.AccountId).Any()) && (!_lecRepository.GetAll().AsQueryable().Where(l => l.AccountId == x.AccountId).Any()));
            //var dataSelect = _accountRepository.GetAll();
            ViewBag.AccountId = new SelectList(dataSelect, "AccountId", "Username") ;
            return View();
        }

        // POST: Admin/Lecturers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AccountId,LecturerId,Faculty")] Lecturer lecturer)
        {
            if (ModelState.IsValid)
            {
                _lecRepository.Add(lecturer);
                //db.Lecturers.Add(lecturer);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccountId = new SelectList(_accountRepository.GetAll(), "AccountId", "Username", lecturer.AccountId);
            return View(lecturer);
        }

        // GET: Admin/Lecturers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lecturer lecturer = _lecRepository.Get(id);
            if (lecturer == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountId = new SelectList(_accountRepository.GetAll(), "AccountId", "Username", lecturer.AccountId);
            return View(lecturer);
        }

        // POST: Admin/Lecturers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AccountId,LecturerId,Faculty")] Lecturer lecturer)
        {
            if (ModelState.IsValid)
            {
                _lecRepository.Edit(lecturer);
                //db.Entry(lecturer).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccountId = new SelectList(_accountRepository.GetAll(), "AccountId", "Username", lecturer.AccountId);
            return View(lecturer);
        }

        // GET: Admin/Lecturers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lecturer lecturer = _lecRepository.Get(id);
            if (lecturer == null)
            {
                return HttpNotFound();
            }
            return View(lecturer);
        }

        // POST: Admin/Lecturers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lecturer lecturer = _lecRepository.Get(id);
            _lecRepository.Remove(lecturer);
            //db.Lecturers.Remove(lecturer);
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
