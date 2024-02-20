using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionEntities
{
    public class Venta
    {
        private int id { get; set; }
        private string comentarios { get; set; }
        private int idUsuario { get; set; }

        public Venta()
        {

        }
        public Venta(string comentarios, int idusuario)
        {

            this.comentarios = comentarios;
            this.idUsuario = idusuario;


        }
        public Venta(int id, string comentarios, int idusuario) : this(comentarios, idusuario)
        {
            this.id = id;
        }

        public int Id { get => id; set => id = value; }
        public string Comentarios { get => comentarios; set => comentarios = value; }
        public int IdUsuario { get => idUsuario; set => idUsuario = value; }

        public override string ToString()
        {
            return $"id: {this.id}, Comentarios: {this.comentarios}, id usuario: {this.idUsuario}";
        }
    }
}
