using System;
using System.Collections.Generic;
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
    }
}
