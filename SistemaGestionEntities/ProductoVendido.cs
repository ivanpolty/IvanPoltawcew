using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionEntities
{
    public class ProductoVendido
    {
        private int id { get; set; }
        private int idProducto { get; set; }
        private int stock { get; set; }
        private int idVenta { get; set; }

        public ProductoVendido(int idproducto, int stock, int idventa)
        {

            this.idProducto = idproducto;
            this.stock = stock;
            this.idVenta = idventa;

        }
        public ProductoVendido(int id, int idproducto, int stock, int idventa) : this(idproducto, stock, idventa)
        {
            this.id = id;
        }

        public int Id { get => id; set => id = value; }
        public int IdProducto { get => idProducto; set => idProducto = value; }
        public int Stock { get => stock; set => stock = value; }
        public int IdVenta { get => idVenta; set => idVenta = value; }

        public override string ToString()
        {
            return $"id: {this.id}, id producto: {this.idProducto},stock {this.stock},id venta: {this.idVenta}, ";
        }

    }
}
