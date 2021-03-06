﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CAPTasksMVC.Models;
using CAPTasksMVC.Servicios;
using BotDetect.Web.UI.Mvc;
using System.Web.Security;


namespace CAPTasksMVC.Controllers
{

    public class AccountController : Controller
    {
        UsuariosServicios us = new UsuariosServicios();

        public ActionResult Index()
        {
            return View("Login");
        }

        public ActionResult Login()
        {
            ViewBag.RegistracionExitosa = TempData["Exito"];
            return View();
        }


        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Login(Usuarios model, string returnUrl)
        {
            int cantidadDeErrores = 0;

            if (model.Email.Length > 20)
            {
                ModelState.AddModelError("", "Email demasiado largo.");
                cantidadDeErrores++;
            }

            if (model.Contrasenia.Length > 20)
            {
                ModelState.AddModelError("", "Contraseña demasiado larga.");
                cantidadDeErrores++;
            }

            if (cantidadDeErrores == 0)
            {
                model.Contrasenia = Encryptor.MD5Hash(model.Contrasenia);


                if (us.Exists(model))
                {

                    if (us.IsActive(model))
                    {

                        us.CrearCookie(model);
                        Session["IdUsuario"] = us.traerIdUsuario(model); 

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
                        ModelState.AddModelError("", "Usuario inactivo.");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Verifique usuario y/o contraseña.");

                }
            }
            return View(model);
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            Session.Clear();
            return RedirectToAction("Login");
        }

        public ActionResult Registro()
        {
            Usuarios user = new Usuarios();
            return View(user);
        }

        [HttpPost]
        [CaptchaValidation("CaptchaCode", "SampleCaptcha", "Codigo Incorrecto!")]
        public ActionResult Registro(Usuarios model)
        {

            if (ModelState.IsValid)
            {

                if (us.EmailExisteActivado(model.Email))
                {
                    ModelState.AddModelError("", "El mail ingresado ya posee una cuenta asociada.");

                    return View(model);
                }
                else
                {
                    /**
                     * En caso de que ya exista un usuario registrado inactivo con el mismo email, 
                     * se deberá permitir la registración del usuario. 
                     * Activando la registración ya existente 
                     * y no duplicando la registración del mismo. 
                     * Se deberá actualizar los datos Nombre, Apellido y Contraseña.
                     */

                    if (us.EmailExisteInactivo(model.Email))
                    {
                        
                        try
                        {
                            us.ActivarInactivo(model);
                        }
                        catch (System.Net.Mail.SmtpException ex)
                        {
                            return RedirectToAction("Error", "Shared");
                        }
                        
                    }
                    else
                    {
                  
                        try
                        {
                            us.Agregar(model);
                        }
                        catch (System.Net.Mail.SmtpException ex)
                        {
                            return RedirectToAction("Error", "Shared");
                        }
                    }

                    TempData["Exito"] = "La registración tuvo exito! Revise su casilla de mail para activar su cuenta.";
                    return RedirectToAction("Login");

                }
            }
            else
            {
                ModelState.AddModelError("", "Verifique los errores en los campos.");

                return View(model);
            }

        }

        public ActionResult Activar(string codAct)
        {

            string msj;
            if (us.ActivarUsuario(codAct))
            {
                msj = "Gracias por activar su cuenta.";
            }
            else
            {
                msj = "Su tiempo para la activacion ha expirado.";
            }

            ViewBag.msj = msj;
            return View();
        }

    }
}
