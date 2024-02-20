using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace Desafio_CoderHouse2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NombreController : ControllerBase
    {

        [HttpGet]
        public string ObtenerNombre()
        {
            return "Ivan Poltawcew";
        }
    }
}
