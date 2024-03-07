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
        [HttpGet("{usuario}/{password}")]

        public ActionResult<Usuario> ObtenerUsuarioPorNombreYPassword(string usuario, string password)
        {
            try
            {

                return UsuarioBussiness.obtenerUsuarioYpassword(usuario, password);
            }
            catch (Exception ex) {
                return base.Conflict(new { mensaje = "Error", status = HttpStatusCode.Conflict });
            }
           


        }

    



    [HttpGet( "{nombreDeUsuario}")]
        public ActionResult<Usuario> GetUsuarioPornombre(string nombreDeUsuario)
        {
            return UsuarioBussiness.ObtenerUsuarioPorNombre(nombreDeUsuario);

        }

        [HttpPost(Name ="Agregar Usuario")]
        public IActionResult agregarUsuario([FromBody] Usuario usu)
        {
            try
            {
                UsuarioBussiness.addUsuario(usu);
                return base.Created(nameof(modificarUsuario), new { mensaje = "Usuario Creado", status = HttpStatusCode.Created, usu });
            }
            catch (Exception)
            {

                return base.Conflict(new { mensaje = "Error al crear un usuario", status = HttpStatusCode.Conflict }); 
            }
        }



        [HttpPut(Name = "Modificar Usuario")]


        public IActionResult modificarUsuario([FromBody] Usuario usu)
        {
            try
            {

                UsuarioBussiness.modifyUsuario(usu.Id, usu);
                return base.Created(nameof(modificarUsuario), new { mensaje = "Usuario Modificado", status = HttpStatusCode.Created, usu });
            }
            catch (Exception ex)
            {
                return base.Conflict(new { mensaje = "Error al modificar un usuario", status = HttpStatusCode.Conflict });
            }


        }

        [HttpDelete (Name ="Eliminar usuario")]

        public IActionResult eliminarUsuario(int id)
        {
            try
            {
                UsuarioBussiness.deleteUsuario(id);
                return base.Created(nameof(modificarUsuario), new { mensaje = "Usuario eliminado", status = HttpStatusCode.Created });

            }
            catch (Exception)
            {

                return base.Conflict(new { mensaje = "Error al eliminar un usuario", status = HttpStatusCode.Conflict });
            }
        }
    }
}
