using SistemaGestionEntities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionData
{
    public static class ProductoVendidoData
    {
        public static ProductoVendido ObtenerProductoVendido(int idProductoVendido)
        {
            try
            {
                string conexionstring = @"Data Source= IVAN\SQLEXPRESS;Database = SistemaGestion;Trusted_Connection=True";
                var query = "SELECT * FROM ProductoVendido Where id = @idProductoVendido;";
                using (SqlConnection conexion = new SqlConnection(conexionstring))
                {

                    SqlCommand command = new SqlCommand(query, conexion);
                    command.Parameters.AddWithValue("idProductoVendido", idProductoVendido);
                    conexion.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int idObetned = Convert.ToInt32(reader["id"]);
                            int idProducto = reader.GetInt32(1);
                            int stock = reader.GetInt32(2);
                            int idVenta = reader.GetInt32(3);

                            ProductoVendido pv = new ProductoVendido(idProductoVendido, idProducto, stock, idVenta);
                            return pv;
                        }
                        throw new Exception("Id no econtrado");

                    }

                }
            }
            catch (Exception)
            {

                throw new Exception("Error en la BD");
            }




        }

        public static List<ProductoVendido> ListarProductoVendido()
        {
            try
            {
                List<ProductoVendido> lista = new List<ProductoVendido>();
                string conexionstring = @"Data Source= IVAN\SQLEXPRESS;Database = SistemaGestion;Trusted_Connection=True";
                var query = "SELECT * FROM ProductoVendido;";
                using (SqlConnection conexion = new SqlConnection(conexionstring))
                {
                    conexion.Open();
                    SqlCommand command = new SqlCommand(query, conexion);


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                int id = Convert.ToInt32(reader["id"]);
                                int idProducto = reader.GetInt32(1);
                                int stock = reader.GetInt32(2);
                                int idVenta = reader.GetInt32(3);
                                ProductoVendido pv = new ProductoVendido(id, idProducto, stock, idVenta);
                                lista.Add(pv);

                            }
                            return lista;
                        }
                        throw new Exception("Id no econtrado");

                    }

                }
            }
            catch (Exception)
            {

                throw new Exception("Error en la BD");
            }




        }
        public static bool AgregarProductoVendido(ProductoVendido productovendido)
        {
            try
            {
                string conexionstring = @"Data Source= IVAN\SQLEXPRESS;Database = SistemaGestion;Trusted_Connection=True";
                var query = "INSERT INTO ProductoVendido (Stock,IdProducto,IdVenta) VALUES (@stock,@idproducto,@idventa) select @@IDENTITY as ID;";
                using (SqlConnection conexion = new SqlConnection(conexionstring))
                {

                    SqlCommand command = new SqlCommand(query, conexion);

                    command.Parameters.AddWithValue("stock", productovendido.Stock);
                    command.Parameters.AddWithValue("idproducto", productovendido.IdProducto);
                    command.Parameters.AddWithValue("idventa", productovendido.IdVenta);

                    conexion.Open();

                    return command.ExecuteNonQuery() > 0;

                }
            }
            catch (Exception)
            {

                throw new Exception("Error en la BD");
            }




        }
        public static bool EliminiarProductoVendido(int idABorrar)
        {
            try
            {
                string conexionstring = @"Data Source= IVAN\SQLEXPRESS;Database = SistemaGestion;Trusted_Connection=True";
                var query = "DELETE FROM ProductoVendido WHERE id = @idABorrar";
                using (SqlConnection conexion = new SqlConnection(conexionstring))
                {
                    SqlCommand command = new SqlCommand(query, conexion);
                    command.Parameters.AddWithValue("idABorrar", idABorrar);
                    conexion.Open();

                    return command.ExecuteNonQuery() > 0;
                }

            }
            catch (Exception)
            {

                throw new Exception("Id no encontrado");
            }



        }

        public static bool ModificarProductoVendido(int id, ProductoVendido pv)
        {
            try
            {
                string conexionstring = @"Data Source= IVAN\SQLEXPRESS;Database = SistemaGestion;Trusted_Connection=True";
                var query = "UPDATE ProductoVendido SET Stock = @stock,IdProducto = @idproducto,IdVenta = @idventa WHERE Id = @id ";
                using (SqlConnection conexion = new SqlConnection(conexionstring))
                {
                    SqlCommand command = new SqlCommand(query, conexion);
                    command.Parameters.AddWithValue("id", id);
                    command.Parameters.AddWithValue("stock", pv.Stock);
                    command.Parameters.AddWithValue("idproducto", pv.IdProducto);
                    command.Parameters.AddWithValue("idventa", pv.IdVenta);

                    conexion.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception)
            {

                throw new Exception("Id no encontrado");
            }


        }


    }
}
