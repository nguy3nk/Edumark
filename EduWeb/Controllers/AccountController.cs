using EduModel.Models;
using EduModel.Repository;
using EduModel.ViewModels.AccountViewModel;
using EduWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EduWeb.Controllers
{
    public class AccountController : Controller
    {
        Repository<Account> _repoAccount;
        Repository<GroupRole> _repoGroupRole;
        Repository<PersonalRole> _repoPersonalRoles;

        public AccountController()
        {
            _repoAccount = new Repository<Account>();
            _repoGroupRole = new Repository<GroupRole>();
            _repoPersonalRoles = new Repository<PersonalRole>();
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
                // Tìm customer theo email và pass đăng nhập
                var data_account = _repoAccount.SingleBy(x => x.Username.Equals(loginViewModel.Username) && x.Password.Equals(loginViewModel.Password));

                if (data_account != null)
                {


                    if (data_account.Status == false)
                    {
                        ViewBag.err1 = "Your account has been locked";
                        return View();
                    }
                    else
                    {
                        Session["User"] = data_account;
                        // Lấy danh sách các quyền 
                        var permissions = _repoGroupRole.GetBy(x => x.GroupId == data_account.GroupId).Select(x => x.BusinessId + "_" + x.RoleId);
                        // Business_Add
                        Session["roles"] = permissions;
                        Session["roleId"] = data_account.GroupId;

                        return RedirectToAction("Index", "Home");
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
                Account a = new Account();
                a.FullName = registerViewModel.FullName;
                a.Email = registerViewModel.Email;
                a.Password = registerViewModel.Password.ToMD5();
                a.GroupId = 2;
                a.Status = true;

                if (_repoAccount.GetAll().FirstOrDefault(x => x.Email == a.Email) != null)
                {
                    ModelState.AddModelError("Email", "Email already exists");
                    return View(registerViewModel);
                }

                if (_repoAccount.Add(a))
                {
                    Helper.SendMail(registerViewModel.Email, "user@gmail.com", "password", "Đăng ký tài khoản", string.Format(@"
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

            return View(registerViewModel);
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
