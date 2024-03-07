using Desafio_CoderHouse2.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaGestionBussines;
using SistemaGestionEntities;
using System.Net;

namespace Desafio_CoderHouse2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        [HttpGet("{idUsuario}")]

        public IEnumerable<Producto> getProductos(int idUsuario)
        {
            return ProductoBussiness.ObtenerProductoPorIdUsu(idUsuario);

        }

        [HttpPost]
        public IActionResult AgregarProducto([FromBody] Producto p)
        {
            if (ProductoBussiness.addProducto(p))
            {
                return base.Ok();
            }
            else
            {
                return base.Conflict(new { mensaje = "No se agrego producto" });
            }

        }

        [HttpPut]
        public IActionResult ModificarProducto(Producto p)
        {
            try
            {

                ProductoBussiness.modifyProducto(p.Id, p);
                return base.Created(nameof(ModificarProducto), new { mensaje = "Producto modificado", status = HttpStatusCode.Created, p });
            }
            catch (Exception ex)
            {
                return base.Conflict(new { mensaje = "Error al modificar un usuario", status = HttpStatusCode.Conflict });
            }
        }

        [HttpDelete("{idProducto}")]
        public IActionResult EliminarProducto([FromBody] int idProducto)
        {
            try
            {
                ProductoBussiness.deleteProducto(idProducto);
                return base.Ok("Producto Eliminado");
            }
            catch (Exception)
            {

                return base.Conflict(new { mensaje = "Error al eliminar un producto", status = HttpStatusCode.Conflict });

            }
        }

      
    }
}
