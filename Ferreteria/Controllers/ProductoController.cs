﻿using Ferreteria.Models;
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
        private ProveedorRepository proveedorRepository;
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
            this.loadProveedores();

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

        private void loadProveedores()
        {
            this.proveedorRepository = new ProveedorRepository();
            List<Proveedor> proveedores = this.proveedorRepository.FindAll();
            ViewBag.ListaProveedores = proveedores;
        }

        private Producto CastProducto(FormCollection collection)
        {
            Producto producto = new Producto();
            producto.idProducto = Convert.ToInt32(collection["idProducto"]);
            producto.nombreProducto = collection["nombreProducto"];

            Proveedor proveedor = new Proveedor();
            proveedor.idProveedor = Convert.ToInt32(collection["proveedores"]);

            producto.proveedor = proveedor;
            producto.stockInventario = Convert.ToInt32(collection["stockInventario"]);

            return producto;
        }

        private ViewResult FindProductoById(int id)
        {
            this.productos = Session["productos"] as List<Producto>;
            List<Producto> busqueda = this.productos.FindAll(x => x.idProducto == id);

            if (busqueda != null && busqueda.Count > 0)
            {
                ViewBag.IdProducto = id;
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
            this.loadProveedores();
            return this.FindProductoById(id);
        }

        // POST: Producto/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                Producto producto = this.CastProducto(collection);
                producto.idProducto = id;

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
                this.repository = new ProductoRepository();
                this.repository.Delete(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
