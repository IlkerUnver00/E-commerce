using Eticaret.Domain.Constants;
using Eticaret.Domain.POCO;
using Eticaret.MVC.Admin.UI.Manage.Sessions;
using Eticaret.MVC.Admin.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eticaret.MVC.Admin.UI.Controllers
{
    public class AuthController : BaseController
    {


        // GET: Auth
        public ActionResult Index()
        {
            var roles = db.Roles.Where(x => !x.IsDeleted).ToList();
            return View(roles);
        }

        [HttpPost]
        public ActionResult AddRole(string rolename, string roledesc)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            try
            {
                if (!string.IsNullOrWhiteSpace(rolename) || !string.IsNullOrWhiteSpace(roledesc))
                {
                    var role = db.Roles.Add(new Role
                    {
                        Name = rolename,
                        Description = roledesc
                    });
                    if (db.SaveChanges() > 0)
                    {
                        result.Add("status", true);
                        result.Add("data", role);
                        result.Add("message", "");
                    }
                    else
                    {
                        result.Add("status", false);
                        result.Add("data", null);
                        result.Add("message", "Unknow error");
                    }
                }
                else
                {
                    result.Add("status", false);
                    result.Add("data", null);
                    result.Add("message", "All fields are required");
                }
            }
            catch (Exception ex)
            {
                result.Add("status", false);
                result.Add("data", null);
                result.Add("message", ex.Message);
            }
            return Json(result);
        }


        public PartialViewResult RenderUserList()
        {
            List<SelectModel<ApplicationUser>> result = new List<SelectModel<ApplicationUser>>();

            var role = db.Roles.SingleOrDefault(x => x.Id == AuthSessions.SelectedRoleId);
            List<ApplicationUser> roleUsers = db.Database.SqlQuery<ApplicationUser>($"Select * from {DbCons.Users.NameWithSch} where Id in(Select UserId from {DbCons.UserRoles.NameWithSch} where RoleId={role.Id})").ToList();


            var allusers = db.Users.Where(x => !x.IsDeleted).ToList();
            foreach (var user in allusers)
            {
                result.Add(new SelectModel<ApplicationUser>
                {
                    Selected = roleUsers.Where(x=>x.Id==user.Id).Any(),
                    Model = user
                });
            }

            return PartialView("~/Views/Auth/Partials/UserList.cshtml", result);
        }

        public PartialViewResult RenderModuleList()
        {
            List<SelectModel<Module>> result = new List<SelectModel<Module>>();

            var role = db.Roles.SingleOrDefault(x => x.Id == AuthSessions.SelectedRoleId);
            List<Module> roleModules = db.Database.SqlQuery<Module>($"Select * from {DbCons.Modules.NameWithSch} where Id in(Select ModuleId from {DbCons.RoleModules.NameWithSch} where RoleId={role.Id})").ToList();


            var allmodules = db.Modules.Where(x => !x.IsDeleted).ToList();
            foreach (var module in allmodules)
            {
                result.Add(new SelectModel<Module>
                {
                    Selected = roleModules.Where(x => x.Id == module.Id).Any(),
                    Model = module
                });
            }
            return PartialView("~/Views/Auth/Partials/ModuleList.cshtml", result);
        }


        [HttpPost]
        public JsonResult OnRoleChange(int roleid = -1)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            if (roleid != -1)
            {
                AuthSessions.SelectedRoleId = roleid;
                result.Add("status", true);
                result.Add("message", null);
            }
            else
            {
                result.Add("status", false);
                result.Add("message", "Role Id can not be value -1");
            }
            return Json(result);
        }
    }
}