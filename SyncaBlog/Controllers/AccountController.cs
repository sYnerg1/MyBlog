using SyncaBlog.Core.Interfaces;
using SyncaBlog.Core.Models;
using SyncaBlog.Models.AccountViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SyncaBlog.Controllers
{
    public class AccountController : Controller
    {
        private IUnitOfWork unit;
        public AccountController(IUnitOfWork unit)
        {
            this.unit = unit;
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                User user = unit.Users.Find(u => u.Email == model.Name);              
                if (user == null)
                {
                    try
                    {
                        Blog blog = new Blog { Name = "Мой блог", Description = "Описание моего блога" };
                        unit.Blogs.Create(blog);
                        unit.Users.Create(new User { Email = model.Name, Password = model.Password, RoleId = 3, MyBlog = blog });
                        unit.Save();
                        user = unit.Users.Find(u => u.Email == model.Name && u.Password == model.Password);
                        if (user != null)
                        {
                            FormsAuthentication.SetAuthCookie(model.Name, true);
                            return RedirectToAction("Index", "Home", new { page = 1 });
                        }
                    }
                    catch (Exception ex)
                    {
                         ModelState.AddModelError("",ex.Message);
                    }
                }
                else
                    ModelState.AddModelError("", "Пользователь с таким логином уже существует");
            }
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model,string returnUrl)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    User user = unit.Users.Find(u => u.Email == model.Name && u.Password == model.Password);

                    if (user != null)
                    {
                        FormsAuthentication.SetAuthCookie(model.Name, true);
                        if (user.RoleId == 1)
                        {
                            return RedirectToAction("ListUsers", "Admin", new { page = 1 });
                        }
                        else if (!string.IsNullOrEmpty(returnUrl))
                            return Redirect(returnUrl);
                        else                        
                        return RedirectToAction("Index", "Home", new { page = 1 });
                    }
                    else
                    {

                        ModelState.AddModelError("", "Пользователя с таким логином и паролем нет");
                    }
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View(model);
        }
        public ActionResult Login()
        {
            return View();
        }

        public RedirectToRouteResult LogOff()
        {
            
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home",new { page=1});
        }
    }
}