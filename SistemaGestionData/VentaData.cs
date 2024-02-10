using SistemaGestionEntities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionData
{
    public static class VentaData
    {

        public static Venta ObtenerVenta(int idVenta)
        {
            try
            {
                string conexionstring = @"Data Source= IVAN\SQLEXPRESS;Database = SistemaGestion;Trusted_Connection=True";
                var query = "SELECT * FROM Venta Where id = @idVenta;";
                using (SqlConnection conexion = new SqlConnection(conexionstring))
                {

                    SqlCommand command = new SqlCommand(query, conexion);
                    command.Parameters.AddWithValue("idVenta", idVenta);
                    conexion.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int idObetned = Convert.ToInt32(reader["id"]);
                            string comentarios = reader.GetString(1);
                            int idusuario = reader.GetInt32(2);

                            Venta venta = new Venta(idVenta, comentarios, idusuario);
                            return venta;
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



        public static List<Venta> ListarVenta()
        {
            try
            {
                List<Venta> lista = new List<Venta>();
                string conexionstring = @"Data Source= IVAN\SQLEXPRESS;Database = SistemaGestion;Trusted_Connection=True";
                var query = "SELECT * FROM Venta;";
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
                                string comentarios = reader.GetString(1);
                                int idusuario = reader.GetInt32(2);

                                Venta venta = new Venta(id, comentarios, idusuario);
                                lista.Add(venta);

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

        public static bool AgregarVenta(Venta venta)
        {
            try
            {
                string conexionstring = @"Data Source= IVAN\SQLEXPRESS;Database = SistemaGestion;Trusted_Connection=True";
                var query = "INSERT INTO Venta (Comentarios,IdUsuario) VALUES (@comentarios,@idusuario) select @@IDENTITY as ID;";
                using (SqlConnection conexion = new SqlConnection(conexionstring))
                {

                    SqlCommand command = new SqlCommand(query, conexion);

                    command.Parameters.AddWithValue("comentarios", venta.Comentarios);
                    command.Parameters.AddWithValue("idusuario", venta.IdUsuario);

                    conexion.Open();

                    return command.ExecuteNonQuery() > 0;

                }
            }
            catch (Exception)
            {

                throw new Exception("Error en la BD");
            }




        }
        public static bool EliminiarVenta(int idABorrar)
        {
            try
            {
                string conexionstring = @"Data Source= IVAN\SQLEXPRESS;Database = SistemaGestion;Trusted_Connection=True";
                var query = "DELETE FROM Venta WHERE id = @idABorrar";
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
        public static bool ModificarVenta(int id, Venta venta)
        {
            try
            {
                string conexionstring = @"Data Source= IVAN\SQLEXPRESS;Database = SistemaGestion;Trusted_Connection=True";
                var query = "UPDATE Venta SET Comentarios = @comentario,IdUsuario = @idusuario WHERE Id = @id ";
                using (SqlConnection conexion = new SqlConnection(conexionstring))
                {
                    SqlCommand command = new SqlCommand(query, conexion);
                    command.Parameters.AddWithValue("id", id);
                    command.Parameters.AddWithValue("comentario", venta.Comentarios);
                    command.Parameters.AddWithValue("idusuario", venta.IdUsuario);

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
