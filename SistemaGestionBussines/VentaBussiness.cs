using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaGestionData;
using SistemaGestionEntities;

namespace SistemaGestionBussines
{
    public class VentaBussiness
    {
        public static Venta getVentaPorId(int id)
        {
            return VentaData.ObtenerVenta(id);
        }

        public static List<Venta> getVentas() {
            return VentaData.ListarVenta();
        }

        public static bool addVenta(Venta venta)
        {
            return VentaData.AgregarVenta(venta);
        }

        public static bool deleteVenta(int id)
        {
            return VentaData.EliminiarVenta(id);
        }

        public static bool modifyVenta(int id, Venta venta)
        {
            return VentaData.ModificarVenta(id, venta);
        }

        public static bool FinalizarVenta(int idUsuario, List<Producto> productos)
        {
            Venta venta = new Venta();
            List<string> nombresDeProductos = productos.Select(p => p.Descripcion).ToList();
            string comentarios ="";
            venta.Comentarios = comentarios;
            venta.IdUsuario = idUsuario;

            VentaBussiness.addVenta(venta);
            CaragarProductosRecibidos(productos, venta.Id);
            DescontarStock(productos);
             
            



            return true;

        }
        public  static void CaragarProductosRecibidos(List<Producto> producto, int idVenta)
        {
            producto.ForEach(p =>
            {
                ProductoVendido pvendido = new ProductoVendido();
                pvendido.Stock = p.Stock;
                pvendido.IdProducto = p.Id;
                pvendido.IdVenta = idVenta;

                ProductoVendidoBussiness.addProductoVendido(pvendido);

            });
        }

        public static void DescontarStock(List<Producto> producto) {

            producto.ForEach(p => {
                Producto productoactual = ProductoBussiness.getProductoPorId(p.Id);
                productoactual.Stock -= p.Stock;
                ProductoBussiness.modifyProducto(p.Id,productoactual);
            });
        }
    }

    
}
