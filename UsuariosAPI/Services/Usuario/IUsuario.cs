using UsuariosAPI.Models;
using UsuariosAPI.Dto.Usuario;

namespace UsuariosAPI.Services.Usuario

{
    public interface IUsuario
    {
        Task<ResponseModel<List<UsuarioModel>>> ListarUsuarios();
        Task<ResponseModel<UsuarioModel>> BuscarUsuarioPorId(int IdUsuario);
        Task<ResponseModel<UsuarioModel>> CadastrarUsuario(CadastrarUsuarioDto cadastrarUsuarioDto);

    }
}
