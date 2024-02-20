using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaGestionBussines;
using SistemaGestionEntities;
using System.Net;

namespace Desafio_CoderHouse2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet(Name = "GetUsuarios")]
        public IEnumerable<Usuario> GetUsuario()
        {
            return UsuarioBussiness.getUsuarios().ToArray();

        }
        [HttpPut(Name = "Modificar Usuario")]
        public IActionResult modificarUsuario([FromBody] Usuario usu)
        {
            try
            {

                UsuarioBussiness.modifyUsuario(usu.Id, usu);
                return base.Created(nameof(modificarUsuario), new { mensaje = "Producto creado", status = HttpStatusCode.Created, usu });
            }
            catch (Exception ex)
            {
                return base.Conflict(new { mensaje = "Error al modificar un usuario", status = HttpStatusCode.Conflict });
            }


        }
    }
}
