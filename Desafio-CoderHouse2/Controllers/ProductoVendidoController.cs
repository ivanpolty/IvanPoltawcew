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
        [HttpGet(Name = "GetProductoVendido")]

        public IEnumerable<ProductoVendido> getProductoVendidos()
        {
            return ProductoVendidoBussiness.getProductosVendidos();
        }
    }
}
