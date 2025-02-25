﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KN_ProyectoClase.BasesDatos;
using KN_ProyectoClase.Models;

namespace KN_ProyectoClase.Controllers
{
    public class PrincipalController : Controller
    {
        #region RegistararCuenta

        [HttpGet]
        public ActionResult RegistrarCuenta()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegistrarCuenta(UsuarioModel model)
        {
            //EF utilizando LinQ
            using (var context = new KN_DBEntities()) 
            { 
            Usuario tabla = new Usuario();
                tabla.Identificacion = model.Identificacion;
                tabla.Contrasenna = model.Contrasenna;
                tabla.Nombre = model.Nombre;
                tabla.Correo = model.Correo;
                tabla.Estado = true;
                tabla.IdPerfil = 2;

                context.Usuario.Add(tabla);
                context.SaveChanges();
            

           //EF utilizando Procedimientos Almacenados
           //context.RegistrarCuenta(model.Identificacion, model.Contrasenna, model.Nombre, model.Correo);
            }

            return View();
        }
        #endregion



       

        [HttpGet]
        public ActionResult Inicio()
        {
            return View();
        }

         #region Inicio sesion

        [HttpGet]
        public ActionResult IniciarSesion()
        {
            return View();
        }

        [HttpPost]
        public ActionResult IniciarSesio(UsuarioModel model)
        {
            using (var context = new KN_DBEntities())
            {
                //EF utilizando LinQ
                //var info = context.Usuario.
                    //Where(x => x.Identificacion == model.Identificacion
                    //&& x.Contrasenna == model.Contrasenna
                    //&& x.Estado == true).FirstOrDefault();

                //EF utilizando Procedimientos Almacenados

                if (info != null)
                {
                    return RedirectToAction("Inicio", "Principal");
                }

                
                return View();
            }
        }

        #endregion

        [HttpGet]

        public ActionResult RecuperarContrasenna()
        {
            return View();
        }
    }
}