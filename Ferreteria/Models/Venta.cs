namespace Ferreteria.Models
{
    public class Venta
    {
        public int idPedido { set; get; }
        public Producto producto { set; get; }
        public string vendedor { set; get; }
        public Cliente comprador { set; get; }

        public Venta()
        {

        }
    }
}