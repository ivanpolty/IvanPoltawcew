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
