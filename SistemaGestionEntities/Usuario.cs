using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionEntities
{
    public class Usuario
    {
        private int id { get; set; }
        private string nombre { get; set; }
        private string apellido { get; set; }
        private string nombreUsuario { get; set; }
        private string contraseña { get; set; }
        private string mail { get; set; }


        public Usuario(string nombre, string apellido, string nombreUsuario, string password, string email)
        {

            this.nombre = nombre;
            this.apellido = apellido;
            this.nombreUsuario = nombreUsuario;
            this.contraseña = password;
            this.mail = email;
        }
        public Usuario(int id, string nombre, string apellido, string nombreUsuario, string password, string email) : this(nombre, apellido, nombreUsuario, password, email)
        {
            this.id = id;
        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string NombreUsuario { get => nombreUsuario; set => nombreUsuario = value; }
        public string Contraseña { get => contraseña; set => contraseña = value; }
        public string Mail { get => mail; set => mail = value; }


        public override string ToString()
        {
            return $"id: {this.id}, nombre: {this.nombre}, apellido: {this.apellido}";
        }

    }
}
