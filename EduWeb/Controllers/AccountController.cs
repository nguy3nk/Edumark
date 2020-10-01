
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EduService.Models;
using EduService.Repository;
using EduService.ViewModels.AccountViewModel;
using EduWeb.Models;

namespace EduWeb.Controllers
{
    public class AccountController : Controller
    {
        Repository<Account> _repoAccount;
        Repository<GroupRole> _repoGroupRole;

        public AccountController()
        {
            _repoAccount = new Repository<Account>();
            _repoGroupRole = new Repository<GroupRole>();
        }
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            //Session.Remove("User");
            //Session.Remove("roles");
            //Session.Remove("roleId");
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                loginViewModel.Password = loginViewModel.Password.ToMD5();
                var data_user = _repoAccount.SingleBy(x => x.Username.Equals(loginViewModel.Username) && x.Password.Equals(loginViewModel.Password));

                if (data_user != null)
                {


                    if (data_user.Status == false)
                    {
                        ViewBag.err1 = "Your account has been locked";
                        return View();
                    }
                    else
                    {
                        Session["User"] = data_user;
                        // Lấy danh sách các quyền 
                        var permissions = _repoGroupRole.GetBy(x => x.GroupId == data_user.GroupId).Select(x => x.BusinessId + "_" + x.RoleId);
                        // Business_Add
                        Session["roles"] = permissions;
                        Session["roleId"] = data_user.GroupId;

                        return RedirectToAction("Index", "Home", new { Area = "Admin" });
                    }

                }
                else
                {
                    ModelState.AddModelError("", "Sai tài khoản hoặc mật khẩu");
                    return View();
                }

            }

            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                Account account = new Account();
                account.FullName = registerViewModel.FullName;
                account.Email = registerViewModel.Email;
                // mã hóa mật khẩu
                account.Password = registerViewModel.Password.ToMD5();
                account.GroupId = 2;
                account.Status = true;

                if (_repoAccount.GetAll().FirstOrDefault(x => x.Email == account.Email) != null)
                {
                    ModelState.AddModelError("Email", "Email already exists");
                    return View(registerViewModel);
                }

                if (_repoAccount.Add(account))
                {
                    Helper.SendMail(registerViewModel.Email, "nguy4nk@gmail.com", "khanhdaica", "Đăng ký tài khoản", string.Format(@"
                    <h1> Đăng ký tài khoản thành công</h1>
                    <b>Email đăng ký :</b> {0}
                    <p>Visit: https://localhost:49178</p>
                    <p>Trân trọng </p>
                    ", registerViewModel.Email));
                    TempData["RigisterSucess"] = "Register successfully!";
                    return RedirectToAction("Login");
                }
                return View(registerViewModel);
            }

            return View();
        }

        public ActionResult SignOut()
        {
            Session.Remove("User");
            Session.Remove("roles");
            Session.Remove("roleId");
            //FormsAuthentication.SignOut();
            //Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}
