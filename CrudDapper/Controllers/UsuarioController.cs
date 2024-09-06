using CrudDapper.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudDapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioInterface _usuarioInterface;
        public UsuarioController(IUsuarioInterface usuarioInterface)
        {
            _usuarioInterface = usuarioInterface;
        }

        [HttpGet]
        public async Task<IActionResult> BuscarUsuarios()
        {
            var usuarios = await _usuarioInterface.BuscarUsuarios();

            if (usuarios.Status == false)
            {
                return NotFound();
            }

            return Ok(usuarios);
        }
    }
}
