using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsuariosAPI.Models;
using UsuariosAPI.Services.Usuario;

namespace UsuariosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuario _usuarioService;
        public UsuarioController(IUsuario usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet("ListarUsuarios")]

        public async Task<ActionResult<ResponseModel<List<UsuarioModel>>>> ListaUsuarios()
        {
            var usuarios = await _usuarioService.ListarUsuarios();
            return Ok(usuarios);
        }

        [HttpGet("BuscarUsuarioPorId/{IdUsuario}")]
        public async Task<ActionResult<ResponseModel<UsuarioModel>>> BuscarUsuarioPorId(int IdUsuario)
        {
            var usuario = await _usuarioService.BuscarUsuarioPorId(IdUsuario);
            return Ok(usuario);
        }
    }
}
