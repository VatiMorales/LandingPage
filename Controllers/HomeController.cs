using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VeterinariaVanesaMorales.Models;

namespace VeterinariaVanesaMorales.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            MantenimientoContacto ma = new MantenimientoContacto();
            Contacto cont = new Contacto
            {

                Nombre = collection["nombre"],
                Direccion = collection["direccion"],
                Email = collection["email"],
                Telefono = int.Parse(collection["telefono"]),
                Ciudad = collection["ciudad"],
                Mensaje = collection["mensaje"]

            };
            ma.Alta(cont);
            return RedirectToAction("Confirmacion");
        }
        public ActionResult Confirmacion()
        {
            return View();
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
       

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult visualizar()
        {
            MantenimientoContacto ma = new MantenimientoContacto();
            return View(ma.RecuperarTodos());

        }
    }
}
