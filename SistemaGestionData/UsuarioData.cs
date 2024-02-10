using SistemaGestionEntities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionData
{
    public static class UsuarioData
    {

        public static Usuario ObtenerUsuario(int idUsuario)
        {
            try
            {
                string conexionstring = @"Data Source= IVAN\SQLEXPRESS;Database = SistemaGestion;Trusted_Connection=True";
                var query = "SELECT * FROM Usuario Where id = @idUsuario;";
                using (SqlConnection conexion = new SqlConnection(conexionstring))
                {

                    SqlCommand command = new SqlCommand(query, conexion);
                    command.Parameters.AddWithValue("idUsuario", idUsuario);
                    conexion.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int idObetned = Convert.ToInt32(reader["id"]);
                            string nombre = reader.GetString(1);
                            string apellido = reader.GetString(2);
                            string nombreUsuario = reader.GetString(3);
                            string contraseña = reader.GetString(4);
                            string mail = reader.GetString(5);

                            Usuario usuario = new Usuario(idUsuario, nombre, apellido, nombreUsuario, contraseña, mail);
                            return usuario;
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


        public static List<Usuario> ListarUsuario()
        {
            try
            {
                List<Usuario> lista = new List<Usuario>();
                string conexionstring = @"Data Source= IVAN\SQLEXPRESS;Database = SistemaGestion;Trusted_Connection=True";
                var query = "SELECT * FROM Usuario;";
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
                                string nombre = reader.GetString(1);
                                string apellido = reader.GetString(2);
                                string nombreUsuario = reader.GetString(3);
                                string contraseña = reader.GetString(4);
                                string mail = reader.GetString(5);

                                Usuario usuario = new Usuario(id, nombre, apellido, nombreUsuario, contraseña, mail);
                                lista.Add(usuario);

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

        public static bool AgregarUsuario(Usuario usuario)
        {
            try
            {
                string conexionstring = @"Data Source= IVAN\SQLEXPRESS;Database = SistemaGestion;Trusted_Connection=True";
                var query = "INSERT INTO Usuario (Nombre,Apellido,NombreUsuario,Contraseña,Mail) VALUES (@nombre,@apellido,@nombreUsuario,@contraseña,@mail) select @@IDENTITY as ID;";
                using (SqlConnection conexion = new SqlConnection(conexionstring))
                {

                    SqlCommand command = new SqlCommand(query, conexion);

                    command.Parameters.AddWithValue("nombre", usuario.Nombre);
                    command.Parameters.AddWithValue("apellido", usuario.Apellido);
                    command.Parameters.AddWithValue("nombreUsuario", usuario.NombreUsuario);
                    command.Parameters.AddWithValue("contraseña", usuario.Contraseña);
                    command.Parameters.AddWithValue("mail", usuario.Mail);

                    conexion.Open();

                    return command.ExecuteNonQuery() > 0;

                }
            }
            catch (Exception)
            {

                throw new Exception("Error en la BD");
            }




        }
        public static bool EliminiarUsuario(int idABorrar)
        {
            try
            {
                string conexionstring = @"Data Source= IVAN\SQLEXPRESS;Database = SistemaGestion;Trusted_Connection=True";
                var query = "DELETE FROM Usuario WHERE id = @idABorrar";
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

        public static bool ModificarUsuario(int id, Usuario usuario)
        {
            try
            {
                string conexionstring = @"Data Source= IVAN\SQLEXPRESS;Database = SistemaGestion;Trusted_Connection=True";
                var query = "UPDATE Usuario SET Nombre = @nombre,Apellido = @apellido,NombreUsuario = @nombreUsuario,Contraseña= @contraseña,Mail=@mail WHERE Id = @id ";
                using (SqlConnection conexion = new SqlConnection(conexionstring))
                {
                    SqlCommand command = new SqlCommand(query, conexion);
                    command.Parameters.AddWithValue("id", id);
                    command.Parameters.AddWithValue("nombre", usuario.Nombre);
                    command.Parameters.AddWithValue("apellido", usuario.Apellido);
                    command.Parameters.AddWithValue("nombreUsuario", usuario.NombreUsuario);
                    command.Parameters.AddWithValue("contraseña", usuario.Contraseña);
                    command.Parameters.AddWithValue("mail", usuario.Mail);
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
