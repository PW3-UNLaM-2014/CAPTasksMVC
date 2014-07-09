using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using CAPTasksMVC.Models;
using CAPTasksMVC.Repositorios;
using System.Web.Mvc;


namespace CAPTasksMVC.Servicios
{
    public class UsuariosServicios
    {

        UsuariosRepositorio ur = new UsuariosRepositorio();
        MailsServicios mailing = new MailsServicios();

        //TRAIGO DATOS DEL USUARIO LOGUEADO PARA CREAR LA SESSION:
        public Usuarios traerDatosPorMail(string mail)
        {
            return ur.TraerPorMail(mail);
        }

        public bool IsActive(Usuarios model)
        {
            //Verificar si esta activo
            return ur.IsActive(model);

        }
        public bool Exists(Usuarios model)
        {

            // Verificar si existe
            return ur.Exists(model);

        }
        //ACTIVACION DE REGISTRACION:
        public bool ActivarUsuario(string codAct)
        {

            // Encontrar al propietario del codigo de activacion
            Usuarios user = ur.TraerPorCodigoDeActivacion(codAct);
            
            Double TiempoPasadoDesdeLaRegistracion = (DateTime.Now - user.FechaCreacion).TotalMinutes;
            
            // Solo se activa el usuario si la activacion se realiza dentro de los 15 min.
            if (TiempoPasadoDesdeLaRegistracion < 15)
            {
                user.Estado = Convert.ToInt16(1);
                user.FechaActivacion = DateTime.Now;

                Carpetas carpeta = new Carpetas();
                carpeta.Nombre = "General";
                carpeta.IdUsuario = user.IdUsuario;
                carpeta.Descripcion = "Carpeta de uso general";
                user.Carpetas.Add(carpeta);

                ur.Guardar();

                return true;
            }
            else
            {
                //Vencio el plazo de validez del enlace
                return false;
            }

        }

        //VERIFICAR SI YA EXISTE UN USUARIO REGISTRADO ACTIVO CON ESE MAIL EN LA LISTA DE USUARIOS:
        public bool EmailExisteActivado(string email)
        {
            try
            {
                Usuarios user = ur.EmailExisteActivado(email);

            }
            catch
            {
                return false;
            }
            return true;


        }

        //VERIFICAR SI YA EXISTE UN USUARIO REGISTRADO INACTIVO CON ESE MAIL EN LA LISTA DE USUARIOS:
        public bool EmailExisteInactivo(string email)
        {
            try
            {
                Usuarios user = ur.EmailExisteInactivo(email);
            }
            catch
            {
                return false;
            }
            return true;


        }

        internal void Agregar(Usuarios model)
        {

            model.Contrasenia = Encryptor.MD5Hash(model.Contrasenia);
            model.FechaActivacion = DateTime.Now;
            model.FechaCreacion = DateTime.Now;
            model.Estado = Convert.ToInt16(0);
            model.CodigoActivacion = Encryptor.MD5Hash(model.Email);

            ur.Crear(model);

            mailing.EnviarMail(model);
        }


        internal void Modificar(Usuarios user)
        {
            ur.Modificar(user);
        }

        internal void ActivarInactivo(Usuarios model)
        {
            var user = traerDatosPorMail(model.Email);

            user.Nombre = model.Nombre;
            user.Apellido = model.Apellido;
            user.Contrasenia = Encryptor.MD5Hash(model.Contrasenia);

            mailing.EnviarMail(user);
            
            Modificar(user);

        }

        internal void CrearCookie(Usuarios model)
        {
            FormsAuthentication.SetAuthCookie(model.Email, false);
        }

        internal object traerIdUsuario(Usuarios model)
        {

            Usuarios miUsuario = traerDatosPorMail(model.Email);
            return miUsuario.IdUsuario; 
        }
    }
}