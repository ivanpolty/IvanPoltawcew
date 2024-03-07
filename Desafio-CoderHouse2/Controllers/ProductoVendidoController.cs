using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaGestionBussines;
using SistemaGestionEntities;

namespace Desafio_CoderHouse2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoVendidoController : ControllerBase
    {
        [HttpGet("{idUsuario}")]

        public IEnumerable<ProductoVendido> getProductoVendidos(int idUsuario)
        {
            return ProductoVendidoBussiness.getProductoVendidoPorIdusuario(idUsuario);
        }
    }
}
