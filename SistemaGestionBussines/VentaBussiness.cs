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
    }
}
