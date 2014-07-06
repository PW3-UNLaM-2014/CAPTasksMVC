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
        CAPTasksEntities entities = new CAPTasksEntities();

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
                string password = model.Contrasenia;
                string mail = model.Email;

               /* PasswordManagement criptografia = new PasswordManagement();

                password = criptografia.Decrypt(password);
                */
                bool userValid = entities.Usuarios.Any(user => user.Email == mail && user.Contrasenia == password);

                if (userValid)
                {
                    FormsAuthentication.SetAuthCookie(mail, false);
                    Usuarios miUsuario = traerDatosUsuario(mail);
                    Session["IdUsuario"] = miUsuario.IdUsuario; // CREO SESSION
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
            return View(model);
        }

        //TRAIGO DATOS DEL USUARIO LOGUEADO PARA CREAR LA SESSION:
        public Usuarios traerDatosUsuario(string mail)
        {
            Usuarios user = new Usuarios();
            user = (from usuarios in entities.Usuarios where usuarios.Email == mail select usuarios).FirstOrDefault();
            return user;
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            Session.Clear();
            return RedirectToAction("Login");
        }

        public ActionResult Users()
        {
            List<Usuarios> user = new List<Usuarios>();
            user = (from usuarios in entities.Usuarios select usuarios).ToList();

            return View(user);
        }


        public ActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registro(Usuarios model)
        {
            // Creo que el encriptado no funciona porque el campo en la bdd es demasiado chico. 
            if (ModelState.IsValid)
            {

                //PasswordManagement manejoDeContrasenia = new PasswordManagement();
                //model.Contrasenia = manejoDeContrasenia.Encrypt(model.Contrasenia);
                model.FechaActivacion = DateTime.Now;
                model.FechaCreacion = DateTime.Now;
                Int16 IsActive = 1;
                model.Estado = IsActive;
                model.CodigoActivacion = model.Email;

                entities.Usuarios.AddObject(model);
                entities.SaveChanges();

                return RedirectToAction("Home","Home");
            }
            else {
                return RedirectToAction("Index");
            }

            
        }

        //ACTIVACION DE REGISTRACION:
        public bool ActivarUsuario(string codAct)
        {

            try
            {
                // Encontrar al propietario del codigo de activacion
                var user = (from usuarios in entities.Usuarios
                            where usuarios.CodigoActivacion == codAct
                            select usuarios).First();

                // Solo se activa el usuario si la activacion se realiza dentro de los 15 min.
                if ((DateTime.Today - user.FechaCreacion).Minutes < 15)
                {
                    user.Estado = 1;
                    user.FechaActivacion = DateTime.Today;
                    entities.SaveChanges();
                }
                return true;
            }
            catch
            {
                //Vencio el plazo de validez del enlace
                return false;
            }

        }

        //VERIFICAR SI YA EXISTE UN USUARIO REGISTRADO ACTIVO CON ESE MAIL EN LA LISTA DE USUARIOS:
        public Usuarios VerificarEmail(string email)
        {

            var user = (from usuarios in entities.Usuarios
                        where usuarios.Email == email
                        && usuarios.Estado != 0
                        select usuarios
                             ).First();

            return user;

        }
    }
}
