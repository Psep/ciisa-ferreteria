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
        private ClienteRepository clienteRepository;
        private List<Venta> ventas;

        private void loadClientes()
        {
            this.clienteRepository = new ClienteRepository();
            List<Cliente> clientes = this.clienteRepository.FindAll();
            ViewBag.ListaClientes = clientes;
        }

        private void loadProductos()
        {
            this.productoRepository = new ProductoRepository();
            List<Producto> productos = this.productoRepository.FindAll();
            ViewBag.ListaProductos = productos;
        }

        private Venta CastVenta(FormCollection collection)
        {
            Venta venta = new Venta();
            venta.idPedido = Convert.ToInt32(collection["idPedido"]);
            venta.vendedor = collection["vendedor"];

            Producto producto = new Producto();
            producto.idProducto = Convert.ToInt32(collection["productos"]);
            venta.producto = producto;

            Cliente cliente = new Cliente();
            cliente.idCliente = Convert.ToInt32(collection["clientes"]);
            venta.comprador = cliente;

            return venta;
        }

        private ViewResult FindVentaById(int id)
        {
            this.ventas = Session["ventas"] as List<Venta>;
            List<Venta> busqueda = this.ventas.FindAll(x => x.idPedido == id);

            if (busqueda != null && busqueda.Count > 0)
            {
                ViewBag.IdPedido = id;
                return View(model: busqueda.ElementAt(0));
            }
            else
            {
                return View();
            }
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
            this.loadClientes();
            this.loadProductos();
            return View();
        }

        // POST: Venta/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                this.repository = new VentaRepository();
                this.repository.Save(this.CastVenta(collection));

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
            this.loadClientes();
            this.loadProductos();
            return this.FindVentaById(id);
        }

        // POST: Venta/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                Venta venta = this.CastVenta(collection);
                venta.idPedido = id;

                this.repository = new VentaRepository();
                this.repository.Update(venta);

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