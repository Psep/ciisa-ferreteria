using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ferreteria.Models.Repository
{
    public class VentaRepository
    {
        public List<Venta> FindAll()
        {
            List<Venta> ventas = new List<Venta>();
            Venta venta = new Venta(1, new Producto(1, "Clavos", 1, 10), 1, new Cliente(1, "Pablo", "Sepulveda", null, "Por ahí 123", "a@a.cl", 123, 123123, new List<Descuento>()));

            return ventas;
        }
    }
}