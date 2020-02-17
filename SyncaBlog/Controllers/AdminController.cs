using SyncaBlog.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SyncaBlog.Core.Models;
using SyncaBlog.Infrastructure;

namespace SyncaBlog.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
       
        const string ALL_ROLES = "Все роли";
        private IUnitOfWork unit;
        public AdminController(IUnitOfWork unit)
        {
            this.unit = unit;
        }

        public PartialViewResult _SelectData(string userLogin, string selUserRole)
        {            
            var model = unit.Users.GetAllWithInclude();
            if (!string.IsNullOrWhiteSpace(userLogin))
                //model = model.Where(e => e.Email.ToLower().StartsWith(userLogin.ToLower()));
                model = model.Where(e => e.Email.ToLower().StartsWith(userLogin.ToLower()));
            if (selUserRole != null && selUserRole != ALL_ROLES)
                model = model.Where(e => e.Role.Id == int.Parse(selUserRole));
            return PartialView("_TableBody", model);
        }

        public ActionResult ListUsers()
        {
            ViewBag.SelUserRole = CreateRoleSelectList();
            return View(unit.Users.GetAllWithInclude());

        }

        public ActionResult EditRole(string name)
        {
            try
            {
                var user = unit.Users.Get(name);
                ViewBag.SelectRole = new SelectList(unit.Roles.GetAll(), "Id", "Name", user.RoleId);
                return View(user);
            }
            catch(Exception ex)
            {
                return View("~/Views/Shared/ErrorPage.cshtml");
            }
            
        }
        [HttpPost]
        public ActionResult EditRole(User user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    unit.Users.Update(user);
                    unit.Save();
                    return RedirectToAction("ListUsers", new { page = 1 });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("",ex.Message);
                }
            }
            return View(user);
        }

        List<SelectListItem> CreateRoleSelectList()
        {
            List<Role> values = new List<Role>();
            values.AddRange(unit.Roles.GetAll());
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem
            {
                Text=ALL_ROLES,
                Value=ALL_ROLES
            });
            foreach (var e in values)
            {
                list.Add(new SelectListItem
                {
                    Text = e.Name,
                    Value =e.Id.ToString()
                });
            }
            return list;
        }
    }
}