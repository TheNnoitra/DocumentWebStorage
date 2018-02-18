using DocumentWebDB.NH.Repository;
using DocumentWebDB.Repositories;
using DocumentWebStorage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DocumentWebStorage.Controllers
{
    public class LoginController : Controller
    {
        private IUserRepository Users { get; set; }

        public LoginController()
        {
            Users = new NHUserRepository();
        }

        // GET: Account
        //разрешить доступ всем
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginModel model)
        {
            if (!ModelState.IsValid)
                return View();

            if (Users.Check(model.Login, model.Password))
            {
                // поставить отметку о аутентификации
                FormsAuthentication.SetAuthCookie(model.Login, true);
                return RedirectToAction("About", "Home");
            }

            ModelState.AddModelError("", "Не удалось выполнить вход");

            return View();
        }


        public void Logout()
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }
    }
}