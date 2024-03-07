using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaGestionBussines;
using SistemaGestionEntities;
using System.Net;

namespace Desafio_CoderHouse2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        [HttpGet(Name = "GetVentas")]

        public IEnumerable<Venta> getVentas()
        {
            return VentaBussiness.getVentas();
    
        }
        [HttpPost (Name = "{idUsuario}")]
        public IActionResult FinalizarVenta(int idUsuario, [FromBody] List<Producto> listaproductos )
        {
            try
            {
                VentaBussiness.FinalizarVenta(idUsuario, listaproductos);
                return base.Ok("Venta Agregada");

            }
            catch (Exception)
            {

                return base.Conflict(new { mensaje = "Error al agregar una venta", status = HttpStatusCode.Conflict });
            }

        }
        [HttpDelete (Name ="Eliminar Venta")]
        public IActionResult EliminarVenta([FromBody] int id)
        {
            try
            {
                VentaBussiness.deleteVenta(id);
                return base.Ok("Venta Eliminada");
            }
            catch (Exception)
            {

                return base.Conflict(new { mensaje = "Error al eliminar una venta", status = HttpStatusCode.Conflict });

            }
        }


    }

}
