using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Ferreteria.Models.Repository
{
    public class ProveedorRepository : BaseRepository
    {
        public List<Proveedor> FindAll()
        {
            SqlConnection conn = this.GetConnection();
            SqlCommand cmd = new SqlCommand("listarProveedores", connection: conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Proveedor> proveedores = new List<Proveedor>();

            while (reader.Read())
            {
                Proveedor proveedor = new Proveedor();
                proveedor.idProveedor = reader.GetInt32(0);
                proveedor.nombreCompleto = reader.GetString(1);
                proveedores.Add(proveedor);
            }

            this.CloseAll(conn, reader);

            return proveedores;
        }
    }
}