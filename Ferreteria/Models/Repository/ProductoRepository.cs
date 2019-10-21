using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace Ferreteria.Models.Repository
{
    public class ProductoRepository : BaseRepository
    {
        public List<Producto> FindAll()
        {
            SqlConnection conn = this.GetConnection();
            SqlCommand cmd = new SqlCommand("listarProductos", connection: conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Producto> productos = new List<Producto>();

            while (reader.Read())
            {
                Producto producto = new Producto();
                producto.idProducto = reader.GetInt32(0);
                producto.nombreProducto = reader.GetString(1);

                Proveedor proveedor = new Proveedor();
                proveedor.idProveedor = reader.GetInt32(2);
                proveedor.nombreCompleto = reader.GetString(3);
                producto.proveedor = proveedor;

                producto.stockInventario = reader.GetInt32(4);

                productos.Add(producto);
            }

            this.CloseAll(conn, reader);

            return productos;
        }

        public void Save(Producto producto)
        {
            SqlConnection conn = this.GetConnection();
            SqlCommand cmd = new SqlCommand("insertarProducto", connection: conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@NombreProducto", SqlDbType.VarChar).Value = producto.nombreProducto;
            cmd.Parameters.Add("@IdProveedor", SqlDbType.Int).Value = producto.proveedor.idProveedor;
            cmd.Parameters.Add("@StockInventario", SqlDbType.Int).Value = producto.stockInventario;

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void Update(Producto producto)
        {
            SqlConnection conn = this.GetConnection();
            SqlCommand cmd = new SqlCommand("modificarProducto", connection: conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdProducto", SqlDbType.Int).Value = producto.idProducto;
            cmd.Parameters.Add("@NombreProducto", SqlDbType.VarChar).Value = producto.nombreProducto;
            cmd.Parameters.Add("@IdProveedor", SqlDbType.Int).Value = producto.proveedor.idProveedor;
            cmd.Parameters.Add("@StockInventario", SqlDbType.Int).Value = producto.stockInventario;

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void Delete(int id)
        {
            SqlConnection conn = this.GetConnection();
            SqlCommand cmd = new SqlCommand("eliminarProducto", connection: conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdProducto", SqlDbType.Int).Value = id;

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}