using Ferreteria.Models;
using Ferreteria.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ferreteria.Controllers
{
    public class HomeController : Controller
    {
        private VentaRepository repository;
        private ProductoRepository productoRepository;
        private List<Venta> ventas;

        private void loadProductos()
        {
            this.productoRepository = new ProductoRepository();
            List<Producto> productos = this.productoRepository.FindAll();
            ViewBag.ListaProductos = productos;
        }

        // GET: Venta
        public ActionResult Index()
        {
            this.repository = new VentaRepository();
            this.ventas = this.repository.FindAll();
            Session["ventas"] = this.ventas;
            return View(model: ventas);
        }

        // GET: Venta/Create
        public ActionResult Create()
        {
            this.loadProductos();
            return View();
        }

        // POST: Venta/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Venta/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Venta/Edit/5
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

        // GET: Venta/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Venta/Delete/5
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