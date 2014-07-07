using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CAPTasksMVC.Models;



namespace CAPTasksMVC.Repositorios
{
    public class UsuariosRepositorio
    {

        CAPTasksEntities entities = new CAPTasksEntities();

        /**
         * TODO: Fijarse porque no devuelve ningun usuario.
         * */
        internal Usuarios TraerPorMail(string mail)
        {
            var user = (from usuarios in entities.Usuarios where usuarios.Email == mail select usuarios).First();
            return user;
        }

        internal bool IsActive(Usuarios model)
        {
            bool userActive = entities.Usuarios.Any(user => user.Email == model.Email && user.Estado == 1);
            return userActive;
        }

        internal bool Exists(Usuarios model)
        {
            bool userExists = entities.Usuarios.Any(user => user.Email == model.Email && user.Contrasenia == model.Contrasenia);
            return userExists;
        }

        internal Usuarios TraerPorCodigoDeActivacion(string codAct)
        {
            var user = (from usuarios in entities.Usuarios
                        where usuarios.CodigoActivacion == codAct
                        select usuarios).First();
            return user;
        }

        internal void Crear(Usuarios user)
        {
            entities.Usuarios.AddObject(user);
            Guardar();
        }

        internal Usuarios EmailExisteActivado(string email)
        {
            var user = (from usuarios in entities.Usuarios
                        where usuarios.Email == email
                        && usuarios.Estado != 0
                        select usuarios
                                 ).First();
            return user;
        }

        internal Usuarios EmailExisteInactivo(string email)
        {

            var user = (from usuarios in entities.Usuarios
                        where usuarios.Email == email
                        && usuarios.Estado == 0
                        select usuarios
                             ).First();
            return user;
        }

        internal void Modificar(Usuarios user)
        {
            Usuarios usuario = entities.Usuarios.Where(e => e.IdUsuario == user.IdUsuario).FirstOrDefault();
            usuario.Nombre = user.Nombre;
            usuario.Apellido = user.Apellido;
            usuario.Contrasenia = user.Contrasenia;
            usuario.Estado = user.Estado;

            Guardar();
        }

        internal void Guardar()
        {
            entities.SaveChanges();
        }
    }
}