namespace Ferreteria.Models
{
    public class Producto
    {
        public Producto()
        {

        }

        public int idProducto { set; get; }
        public string nombreProducto { set; get; }
        public Proveedor proveedor { set; get; }
        public int stockInventario { set; get; }
    }
}