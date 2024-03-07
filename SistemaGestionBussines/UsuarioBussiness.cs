using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaGestionData;
using SistemaGestionEntities;

namespace SistemaGestionBussines
{
    public static class UsuarioBussiness
    {
        public static Usuario getUsuarioPorId(int id)
        {
            
            return UsuarioData.ObtenerUsuario(id);
        }
         
      //  public static Usuario 
        public static List<Usuario> getUsuarios() {
            return UsuarioData.ListarUsuario();        
        }

        public static bool addUsuario(Usuario usuario)
        {
           return UsuarioData.AgregarUsuario(usuario);
        }

        public static bool deleteUsuario(int id)
        {
            return UsuarioData.EliminiarUsuario(id);
        }

        public static bool modifyUsuario(int id, Usuario usuario)
        {
            return UsuarioData.ModificarUsuario(id, usuario);
        }

        public static Usuario? obtenerUsuarioYpassword(string nombre, string pass)
        {
            List<Usuario> usuarios = getUsuarios();

            Usuario? usuarioBuscado = usuarios.Find(u => u.NombreUsuario == nombre && u.Contraseña == pass);
            if (usuarioBuscado == null ) {
                throw new Exception("Usuario no Encontrado");
            }
            return usuarioBuscado;
        }

        public static Usuario?  ObtenerUsuarioPorNombre(string nombre) {
            List<Usuario> usuarios = getUsuarios();

            Usuario? usuarioBuscado = usuarios.Find(u => u.NombreUsuario == nombre);
            if (usuarioBuscado == null)
            {
                throw new Exception("Usuario no Encontrado");
            }
            return usuarioBuscado;
        }
    }
}
