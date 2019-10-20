namespace Ferreteria.Models
{
    public class Producto
    {
        public Producto()
        {

        }

        public Producto(int idProducto, string nombreProducto, int nitProveedor, int stockInventario)
        {
            this.idProducto = idProducto;
            this.nombreProducto = nombreProducto;
            this.nitProveedor = nitProveedor;
            this.stockInventario = stockInventario;
        }

        public int idProducto { set; get; }
        public string nombreProducto { set; get; }
        public int nitProveedor { set; get; }
        public int stockInventario { set; get; }
    }
}