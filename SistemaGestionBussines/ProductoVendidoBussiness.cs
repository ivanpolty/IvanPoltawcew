using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaGestionData;
using SistemaGestionEntities;

namespace SistemaGestionBussines
{
    public class ProductoVendidoBussiness
    {
        public static ProductoVendido getProductoVendidoPorId(int id)
        {
            return ProductoVendidoData.ObtenerProductoVendido(id);
        }
        public static List<ProductoVendido> getProductoVendidoPorIdusuario(int idusu) {
            List<Producto> productos = ProductoData.ListarProducto();
            List<Producto> productoFiltrado = productos.Where(p=> p.IdUsuario == idusu).ToList();

            List <ProductoVendido> resultado = new List<ProductoVendido>();
            List<ProductoVendido> productosVendidos = ProductoVendidoData.ListarProductoVendido();

            foreach(Producto p in productoFiltrado)
            {
                int id = p.Id;
                ProductoVendido? pvendido = productosVendidos.Find(pv => pv.IdProducto == id);
                if(pvendido is not null)
                {
                    resultado.Add(pvendido);
                }
            }
            return resultado;
        }

        public static List<ProductoVendido> getProductosVendidos()
        {
            return ProductoVendidoData.ListarProductoVendido();
        }

        public static bool addProductoVendido(ProductoVendido productovendido)
        {
            return ProductoVendidoData.AgregarProductoVendido(productovendido);
        }

        public static bool deleteProductoVendido(int id)
        {
            return ProductoVendidoData.EliminiarProductoVendido(id);
        }

        public static bool modifyProductoVendido(int id, ProductoVendido productoVendido)
        {
            return ProductoVendidoData.ModificarProductoVendido(id, productoVendido);
        }

       
    }
}
