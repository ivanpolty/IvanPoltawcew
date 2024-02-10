using SistemaGestionEntities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionData
{
    public static class ProductoData
    {



        public static Producto ObtenerProducto(int idProducto)
        {
            try
            {
                string conexionstring = @"Data Source= IVAN\SQLEXPRESS;Database = SistemaGestion;Trusted_Connection=True";
                var query = "SELECT * FROM Producto Where id = @idProducto;";
                using (SqlConnection conexion = new SqlConnection(conexionstring))
                {

                    SqlCommand command = new SqlCommand(query, conexion);
                    command.Parameters.AddWithValue("idProducto", idProducto);
                    conexion.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int idObetned = Convert.ToInt32(reader["id"]);
                            string descripcion = reader.GetString(1);
                            double costo = (double)reader.GetDecimal(2);
                            double precioventa = (double)reader.GetDecimal(3);
                            int stock = reader.GetInt32(4);
                            int idusuario = reader.GetInt32(5);
                            Producto producto = new Producto(idProducto, descripcion, costo, precioventa, stock, idusuario);

                            return producto;
                        }

                        throw new Exception("No existe ID");
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception("Error en BD");
            }
        }










        public static List<Producto> ListarProducto()
        {
            try
            {
                List<Producto> lista = new List<Producto>();
                string conexionstring = @"Data Source= IVAN\SQLEXPRESS;Database = SistemaGestion;Trusted_Connection=True";
                var query = "SELECT * FROM Producto;";
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
                                string descripcion = reader.GetString(1);
                                double costo = (double)reader.GetDecimal(2);
                                double precioventa = (double)reader.GetDecimal(3);
                                int stock = reader.GetInt32(4);
                                int idusuario = reader.GetInt32(5);
                                Producto producto = new Producto(id, descripcion, costo, precioventa, stock, idusuario);


                                lista.Add(producto);

                            }
                            return lista;
                        }
                        throw new Exception("Id no econtrado");

                    }

                }
            }
            catch (Exception)
            {

                throw new Exception("Error en BD");
            }


        }

        public static bool AgregarProducto(Producto producto)
        {
            try
            {
                string conexionstring = @"Data Source= IVAN\SQLEXPRESS;Database = SistemaGestion;Trusted_Connection=True";
                var query = "INSERT INTO Producto (Descripciones,Costo,PrecioVenta,Stock,IdUsuario) VALUES (@descripcion,@costo,@precioventa,@stock,@idusuario) select @@IDENTITY as ID;";
                using (SqlConnection conexion = new SqlConnection(conexionstring))
                {

                    SqlCommand command = new SqlCommand(query, conexion);

                    command.Parameters.AddWithValue("descripcion", producto.Descripcion);
                    command.Parameters.AddWithValue("costo", producto.Costo);
                    command.Parameters.AddWithValue("precioventa", producto.PrecioVenta);
                    command.Parameters.AddWithValue("stock", producto.Stock);
                    command.Parameters.AddWithValue("idusuario", producto.IdUsuario);

                    conexion.Open();

                    return command.ExecuteNonQuery() > 0;

                }
            }
            catch (Exception)
            {

                throw new Exception("Error en BD");
            }






        }
        public static bool EliminiarProducto(int idABorrar)
        {
            try
            {
                string conexionstring = @"Data Source= IVAN\SQLEXPRESS;Database = SistemaGestion;Trusted_Connection=True";
                var query = "DELETE FROM Producto WHERE id = @idABorrar";
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


        public static bool ModificarProducto(int id, Producto producto)
        {
            try
            {
                string conexionstring = @"Data Source= IVAN\SQLEXPRESS;Database = SistemaGestion;Trusted_Connection=True";
                var query = "UPDATE Producto SET Descripciones = @descripcion,Costo = @costo,PrecioVenta = @precioventa,Stock= @stock,IdUsuario=@idusuario WHERE id = @id ";
                using (SqlConnection conexion = new SqlConnection(conexionstring))
                {
                    SqlCommand command = new SqlCommand(query, conexion);
                    command.Parameters.AddWithValue("id", id);
                    command.Parameters.AddWithValue("descripcion", producto.Descripcion);
                    command.Parameters.AddWithValue("costo", producto.Costo);
                    command.Parameters.AddWithValue("precioventa", producto.PrecioVenta);
                    command.Parameters.AddWithValue("stock", producto.Stock);
                    command.Parameters.AddWithValue("idusuario", producto.IdUsuario);
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
