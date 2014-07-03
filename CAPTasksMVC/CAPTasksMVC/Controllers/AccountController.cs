using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;
using CAPTasksMVC.Models;

namespace CAPTasksMVC.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            Usuarios user = new Usuarios();
            return View(user);
        }

        [HttpPost]
        public ActionResult Login(Usuarios model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                using (CAPTasksEntities entities = new CAPTasksEntities())
                {
                    string username = model.Nombre;
                    string password = model.Contrasenia;

                    PasswordManagement criptografia = new PasswordManagement();

                    password = criptografia.Encrypt(password);

                    bool userValid = entities.Usuarios.Any(user => user.Nombre == username && user.Contrasenia == password);

                    if (userValid)
                    {
                        FormsAuthentication.SetAuthCookie(username, false);

                        if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                            && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                        {
                            return Redirect(returnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Home", "Home");
                        }


                    }
                    else
                    {
                        ModelState.AddModelError("", "El nombre de usuario o la contrase&ntilde;a no son correctos.");

                    }
                }
            }
            return View(model);
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }


    }
}
