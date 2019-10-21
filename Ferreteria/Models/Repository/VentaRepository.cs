using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Ferreteria.Models.Repository
{
    public class VentaRepository : BaseRepository
    {
        public List<Venta> FindAll()
        {
            SqlConnection conn = this.GetConnection();
            SqlCommand cmd = new SqlCommand("listarVentas", connection: conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Venta> ventas = new List<Venta>();

            while (reader.Read())
            {
                Venta venta = new Venta();
                venta.idPedido = reader.GetInt32(0);

                Producto producto = new Producto();
                producto.idProducto = reader.GetInt32(1);
                producto.nombreProducto = reader.GetString(2);
                venta.producto = producto;

                venta.vendedor = reader.GetString(3);

                Cliente cliente = new Cliente();
                cliente.idCliente = reader.GetInt32(4);
                cliente.nombreCompleto = reader.GetString(5);
                venta.comprador = cliente;

                ventas.Add(venta);
            }

            this.CloseAll(conn, reader);

            return ventas;
        }

        public void Save(Venta venta)
        {
            SqlConnection conn = this.GetConnection();
            SqlCommand cmd = new SqlCommand("insertarVenta", connection: conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdProducto", SqlDbType.Int).Value = venta.producto.idProducto;
            cmd.Parameters.Add("@Vendedor", SqlDbType.VarChar).Value = venta.vendedor;
            cmd.Parameters.Add("@IdCliente", SqlDbType.Int).Value = venta.comprador.idCliente;

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void Update(Venta venta)
        {
            SqlConnection conn = this.GetConnection();
            SqlCommand cmd = new SqlCommand("modificarVenta", connection: conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdPedido", SqlDbType.Int).Value = venta.idPedido;
            cmd.Parameters.Add("@IdProducto", SqlDbType.Int).Value = venta.producto.idProducto;
            cmd.Parameters.Add("@Vendedor", SqlDbType.VarChar).Value = venta.vendedor;
            cmd.Parameters.Add("@IdCliente", SqlDbType.Int).Value = venta.comprador.idCliente;

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void Delete(int id)
        {
            SqlConnection conn = this.GetConnection();
            SqlCommand cmd = new SqlCommand("eliminarVenta", connection: conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdPedido", SqlDbType.Int).Value = id;

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}