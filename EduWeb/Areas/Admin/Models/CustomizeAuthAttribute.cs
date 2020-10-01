using EduService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EduWeb.Areas.Admin.Models
{
    public class CustomizeAuthAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            // Kiểm tra đăng nhập hay chưa
            if (HttpContext.Current.Session["Account"] == null)
            {
                return false;
            }

            //
            if (HttpContext.Current.Session["roleId"].ToString() != "1")
            {
                return false;
            }

            // ép kiểu sang kiểu user
            var _account = (Account)HttpContext.Current.Session["Account"];
            // kiểm tra nó có quyền hay k -> action hiện tại nó có yêu cầu quyền hay k
            // lấy các quyền mà action yêu cầu
            var requiredRoles = this.Roles.Split(',').Where(x => !string.IsNullOrEmpty(x)).ToList();

            // lấy tên controller hiện tại 
            var role = httpContext.Request.RequestContext.RouteData;
            string _controllerName = role.GetRequiredString("controller");
            if (requiredRoles.Count() > 0) //Có yêu cầu quyền
            {
                // Lấy các quyền của User hiện tại
                var _roles = HttpContext.Current.Session["roles"] as IEnumerable<string>;
                // kiểm tra xem có tồn tại các quyền yêu cầu trong số các quyền đã gán hay k
                var check = false;
                foreach (var item in requiredRoles)
                {
                    var _r = _controllerName + "_" + item;
                    if (_roles.Any(x => x == _r))
                    {
                        check = true;
                        break;
                    }
                }
                //nếu check truy ->  có quyền truy cập
                if (check)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectResult("~/Error/Error403");
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (this.AuthorizeCore(filterContext.HttpContext))
            {
                base.OnAuthorization(filterContext);
            }
            else
            {
                this.HandleUnauthorizedRequest(filterContext);
            }
        }
    }
}