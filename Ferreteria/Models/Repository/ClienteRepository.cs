using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Ferreteria.Models.Repository
{
    public class ClienteRepository : BaseRepository
    {
        public List<Cliente> FindAll()
        {
            SqlConnection conn = this.GetConnection();
            SqlCommand cmd = new SqlCommand("listarClientes", connection: conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Cliente> clientes = new List<Cliente>();

            while (reader.Read())
            {
                Cliente cliente = new Cliente();
                cliente.idCliente = reader.GetInt32(0);
                cliente.nombreCompleto = reader.GetString(1);
                cliente.razonSocial = reader.GetString(2);
                cliente.direccion = reader.GetString(3);
                cliente.email = reader.GetString(4);
                cliente.numeroCelular = reader.GetInt32(5);
                clientes.Add(cliente);
            }

            this.CloseAll(conn, reader);

            return clientes;
        }
    }
}