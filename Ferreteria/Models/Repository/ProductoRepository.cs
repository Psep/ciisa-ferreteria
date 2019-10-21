using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ferreteria.Models.Repository
{
    public class ProductoRepository
    {
        public List<Producto> FindAll()
        {
            List<Producto> productos = new List<Producto>();
            Producto producto = new Producto(1, "Clavos", 1, 10);
            Producto producto1 = new Producto(2, "Tornillos", 1, 5);
            productos.Add(producto);
            productos.Add(producto1);

            return productos;
        }

        public Boolean Save(Producto producto)
        {
            //TODO implementar
            return true;
        }

        public Boolean Update(Producto producto)
        {
            //TODO implementar
            return true;
        }
    }
}