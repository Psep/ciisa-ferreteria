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

        public Cliente()
        {

        }
    }
}