using Ferreteria.Models;
using Ferreteria.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ferreteria.Controllers
{
    public class ProductoController : Controller
    {
        private ProductoRepository repository;
        private List<Producto> productos;

        // GET: Producto
        public ActionResult Index()
        {
            this.repository = new ProductoRepository();
            this.productos = this.repository.FindAll();
            Session["productos"] = this.productos;
            return View(model: productos);
        }

        // GET: Producto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Producto/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private ViewResult FindProductoById(int id)
        {
            this.productos = Session["productos"] as List<Producto>;
            List<Producto> busqueda = this.productos.FindAll(x => x.idProducto == id);

            if (busqueda != null && busqueda.Count > 0)
            {
                return View(model: busqueda.ElementAt(0));
            }
            else
            {
                return View();
            }
        }

        // GET: Producto/Edit/5
        public ActionResult Edit(int id)
        {
            return this.FindProductoById(id);
        }

        // POST: Producto/Edit/5
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

        // GET: Producto/Delete/5
        public ActionResult Delete(int id)
        {
            return this.FindProductoById(id);
        }

        // POST: Producto/Delete/5
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
    }
}
