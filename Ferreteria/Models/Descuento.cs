namespace Ferreteria.Models
{
    public class Descuento
    {
        public long idDescuento { set; get; }
        public int porcentaje { set; get; }
        public Producto producto { set; get; }
        public TipoDescuento tipoDescuento { set; get; }
    }
}