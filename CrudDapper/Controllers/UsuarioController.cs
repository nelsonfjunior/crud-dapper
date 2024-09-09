using CrudDapper.Dto;
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

        [HttpGet("{usuarioId}")]
        public async Task<IActionResult> BuscarUsuarioPorId(int usuarioId)
        {
            var usuario = await _usuarioInterface.BuscarUsuarioPorId(usuarioId);

            if (usuario.Status == false)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> CriarUsuario([FromBody] UsuarioCriarDto usuarioCriarDto)
        {
            var usuario = await _usuarioInterface.CriarUsuario(usuarioCriarDto);

            if (usuario.Status == false)
            {
                return BadRequest();
            }

            return Ok(usuario);
        }

        [HttpPut]
        public async Task<IActionResult> EditarUsuario([FromBody] UsuarioEditarDto usuarioEditarDto)
        {
            var usuario = await _usuarioInterface.EditarUsuario(usuarioEditarDto);

            if (usuario.Status == false)
            {
                return BadRequest();
            }

            return Ok(usuario);
        }

        [HttpDelete("{usuarioId}")]
        public async Task<IActionResult> RemoverUsuario(int usuarioId)
        {
            var usuario = await _usuarioInterface.RemoverUsuario(usuarioId);

            if (usuario.Status == false)
            {
                return BadRequest();
            }

            return Ok(usuario);
        }
    }
}
