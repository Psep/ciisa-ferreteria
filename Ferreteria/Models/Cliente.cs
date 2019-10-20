using System.Collections.Generic;

namespace Ferreteria.Models
{
    public class Cliente
    {
        public int idCliente { set; get; }
        public string nombres { set; get; }
        public string apellidos { set; get; }
        public string razonSocial { set; get; }
        public string direccion { set; get; }
        public string email { set; get; }
        public int numeroCelular { set; get; }
        public int numeroFijo { set; get; }
        public List<Descuento> descuentos { set; get; }

        public Cliente()
        {

        }

        public Cliente(int idCliente, string nombres, string apellidos, string razonSocial, string direccion, string email, int numeroCelular, int numeroFijo, List<Descuento> descuentos)
        {
            this.idCliente = idCliente;
            this.nombres = nombres;
            this.apellidos = apellidos;
            this.razonSocial = razonSocial;
            this.direccion = direccion;
            this.email = email;
            this.numeroCelular = numeroCelular;
            this.numeroFijo = numeroFijo;
            this.descuentos = descuentos;
        }
    }
}