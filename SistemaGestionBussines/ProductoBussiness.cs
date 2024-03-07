using SistemaGestionData;
using SistemaGestionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionBussines
{
    public class ProductoBussiness
    {
        public static Producto getProductoPorId(int id)
        {

            return ProductoData.ObtenerProducto(id);
        }

        public static List<Producto> getProducto()
        {
            return ProductoData.ListarProducto();
        }

        public static List<Producto> ObtenerProductoPorIdUsu(int id)
        {
            List<Producto> lista = ProductoData.ListarProducto();
            List<Producto> listaproductosbuscados = new List<Producto>();
            foreach (Producto producto in lista)
            {
                if (producto.IdUsuario == id)
                {
                    listaproductosbuscados.Add(producto);
                }
            }
            return listaproductosbuscados;
        }

        public static bool addProducto(Producto producto)
        {
            return ProductoData.AgregarProducto(producto);
        }

        public static bool deleteProducto(int id)
        {
            return ProductoData.EliminiarProducto(id);
        }

        public static bool modifyProducto(int id, Producto producto)
        {
            return ProductoData.ModificarProducto(id, producto);
        }
    }
}
