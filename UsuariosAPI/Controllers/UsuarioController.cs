using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsuariosAPI.Models;
using UsuariosAPI.Services.Usuario;
using UsuariosAPI.Dto.Usuario;

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

        [HttpPost("CadastrarUsuario")]
        public async Task<ActionResult<ResponseModel<UsuarioModel>>> CadastrarUsuario([FromBody] CadastrarUsuarioDto cadastrarUsuarioDto)
        {
            if (cadastrarUsuarioDto == null)
            {
                return BadRequest(new ResponseModel<UsuarioModel>
                {
                    Mensagem = "Os dados do usuário não podem ser nulos.",
                    Status = false
                });
            }
            var usuario = await _usuarioService.CadastrarUsuario(cadastrarUsuarioDto);
            return Ok(usuario);
        }

        [HttpPut("EditarUsuario")]
        public async Task<ActionResult<ResponseModel<UsuarioModel>>> EditarUsuario([FromBody] EditarUsuarioDto editarUsuarioDto)
        {
            if (editarUsuarioDto == null)
            {
                return BadRequest(new ResponseModel<UsuarioModel>
                {
                    Mensagem = "Os dados do usuário não podem ser nulos",
                    Status = false
                });
            }
            var usuario = await _usuarioService.EditarUsuario(editarUsuarioDto);
            return Ok(usuario);
        }

        [HttpDelete("DeletarUsuario/{IdUsuario}")]
        public async Task<ActionResult<ResponseModel<UsuarioModel>>> DeletarUsuario(int IdUsuario)
        {
            var usuario = await _usuarioService.DeletarUsuario(IdUsuario);
            return Ok(usuario);
        }
    }
}
