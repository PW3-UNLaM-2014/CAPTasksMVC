using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;
using CAPTasksMVC.Models;
using CAPTasksMVC.Servicios;
using BotDetect.Web.UI.Mvc;

namespace CAPTasksMVC.Controllers
{

    public class AccountController : Controller
    {
        CAPTasksEntities entities = new CAPTasksEntities();
        UsuariosServicios ts = new UsuariosServicios();

        public ActionResult Index()
        {
            return View("Login");
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

               
                password = Encryptor.MD5Hash(password);
                
                // Verificar si existe
                bool userExists = entities.Usuarios.Any(user => user.Email == mail && user.Contrasenia == password);                

                if (userExists)
                {
                    //Verificar si esta activo
                    bool userActive = entities.Usuarios.Any(user => user.Email == mail && user.Contrasenia == password && user.Estado == 1);

                    if (userActive)
                    {
                        FormsAuthentication.SetAuthCookie(mail, false);

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
                    else {

                        ModelState.AddModelError("", "Usuario inactivo.");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "El nombre de usuario o la contrase&ntilde;a no son correctos.");

                }
            }
            return View(model);
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        public ActionResult Registro()
        {
            Usuarios user = new Usuarios();
            return View(user);
        }

        [HttpPost]
        [CaptchaValidation("CaptchaCode", "SampleCaptcha", "Codigo de verificacion incorrecto!")]
        public ActionResult Registro(Usuarios model)
        {
    

            if (!String.IsNullOrEmpty(model.Email))
            {
                if (EmailEstaRepetido(model.Email))
                {
                    ModelState.AddModelError("", "El mail ingresado ya posee una cuenta asociada.");

                    return View(model);
                }
            
            }
                if(ModelState.IsValid)
                {

                    model.Contrasenia = Encryptor.MD5Hash(model.Contrasenia);
                    model.FechaActivacion = DateTime.Now;
                    model.FechaCreacion = DateTime.Now;
                    Int16 IsActive = 1;
                    model.Estado = IsActive;
                    model.CodigoActivacion = Encryptor.MD5Hash(model.Email);

                    entities.Usuarios.AddObject(model);
                    entities.SaveChanges();

                    return RedirectToAction("Home", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Verifique los errores en los campos.");

                    return View(model);
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

                    Carpetas carpeta = new Carpetas();
                    carpeta.Nombre = "General";
                    carpeta.IdUsuario = user.IdUsuario;
                    carpeta.Descripcion = "Carpeta de uso general";
                    user.Carpetas.Add(carpeta);

                    entities.Usuarios.AddObject(user);
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
        private bool EmailEstaRepetido(string email)
        {
            try
            {
                var user = (from usuarios in entities.Usuarios
                            where usuarios.Email == email
                            && usuarios.Estado != 0
                            select usuarios
                                 ).First();
            }
            catch
            {
                return false;
            }
            return true;          


        }
    }
}
