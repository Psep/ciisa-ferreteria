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
                this.repository = new ProductoRepository();
                this.repository.Save(this.CastProducto(collection));

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private Producto CastProducto(FormCollection collection)
        {
            Producto producto = new Producto();
            producto.idProducto = Convert.ToInt32(collection["idProducto"]);
            producto.nombreProducto = collection["nombreProducto"];
            producto.nitProveedor = Convert.ToInt32(collection["nitProveedor"]);
            producto.stockInventario = Convert.ToInt32(collection["nitProveedor"]);

            return producto;
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
                Producto producto = this.CastProducto(collection);

                this.repository = new ProductoRepository();
                this.repository.Update(producto);

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
