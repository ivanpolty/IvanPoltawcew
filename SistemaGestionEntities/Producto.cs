using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionEntities
{
    public class Producto
    {
        private int id { get; set; }
        private string descripcion { get; set; }
        private double costo { get; set; }
        private double precioVenta { get; set; }
        private int stock { get; set; }
        private int idUsuario { get; set; }
        public Producto(string descripcion, double costo, double precioVenta, int stock, int idUsuario)
        {

            this.descripcion = descripcion;
            this.costo = costo;
            this.precioVenta = precioVenta;
            this.stock = stock;
            this.idUsuario = idUsuario;
        }
        public Producto(int id, string descripcion, double costo, double precioVenta, int stock, int idUsuario) : this(descripcion, costo, precioVenta, stock, idUsuario)
        {
            this.id = id;
        }
        public Producto()
        {
          
        }

        public int Id { get => id; set => id = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public double Costo { get => costo; set => costo = value; }
        public double PrecioVenta { get => precioVenta; set => precioVenta = value; }
        public int Stock { get => stock; set => stock = value; }
        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public override string ToString()
        {
            return $"id: {this.id}, costo: {this.costo}, precio de venta: {this.precioVenta}";
        }

    }
}
