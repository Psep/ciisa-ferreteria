namespace Ferreteria.Models
{
    public class Venta
    {
        public int idPedido { set; get; }
        public Producto producto { set; get; }
        public int vendedor { set; get; }
        public Cliente comprador { set; get; }

        public Venta()
        {

        }

        public Venta(int idPedido, Producto producto, int vendedor, Cliente comprador)
        {
            this.idPedido = idPedido;
            this.producto = producto;
            this.vendedor = vendedor;
            this.comprador = comprador;
        }
    }
}