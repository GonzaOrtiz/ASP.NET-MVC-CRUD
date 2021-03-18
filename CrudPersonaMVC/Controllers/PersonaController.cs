using CrudPersonaMVC.Models;
using CrudPersonaMVC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudPersonaMVC.Controllers
{
    public class PersonaController : Controller
    {
        // GET: Persona
        public ActionResult Index()
        {

            //creamos una lista de nuestra clase ListarPersona
            List<ListarPersonas> list;
            using (PersonaEntities bd = new PersonaEntities())
            {
                //hacemos un select a nuestra tabla con los campos que queremos mostrar
                list = (from b in bd.Persona
                        select new ListarPersonas
                        {
                            Id = b.ID,
                            Nombre = b.NOMBRE,
                            Apellido = b.APELLIDO,
                            Direccion = b.DIRECCION,
                            Email = b.EMAIL

                        }).ToList();
            }
            return View(list);
        }

        public ActionResult Nuevo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Nuevo(PersonaViewModel persona)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (PersonaEntities db = new PersonaEntities())
                    {
                        var opersona = new Persona();
                        opersona.NOMBRE = persona.Nombre;
                        opersona.APELLIDO = persona.Apellido;
                        opersona.DIRECCION = persona.Direccion;
                        opersona.EMAIL = persona.Email;

                        db.Persona.Add(opersona);
                        db.SaveChanges();
                    }
                    return View(persona);
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            return View();
        }
        [HttpGet]
        public ActionResult Editar(int id)
        {
            PersonaViewModel modelo = new PersonaViewModel();
            using (PersonaEntities db = new PersonaEntities())
            {
                var persona = db.Persona.Find(id);
                modelo.Id = persona.ID;
                modelo.Nombre = persona.NOMBRE;
                modelo.Apellido = persona.APELLIDO;
                modelo.Direccion = persona.DIRECCION;
                modelo.Email = persona.EMAIL;
            }
            return    View(modelo);
        }

        [HttpPost]
        public ActionResult Editar(PersonaViewModel persona)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (PersonaEntities db = new PersonaEntities())
                    {
                        var opersona = db.Persona.Find(persona.Id);
                        opersona.NOMBRE = persona.Nombre;
                        opersona.APELLIDO = persona.Apellido;
                        opersona.DIRECCION = persona.Direccion;
                        opersona.EMAIL = persona.Email;
                        db.Entry(opersona).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                }
                return View(persona);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPost]
        public ActionResult Eliminar(int id)
        {
            PersonaViewModel model = new PersonaViewModel();
            using (PersonaEntities db = new PersonaEntities())
            {
                var opersona = db.Persona.Find(id);
                db.Persona.Remove(opersona);
                db.SaveChanges();
            }
           return Content("ok");
        }
    }
}