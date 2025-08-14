using UsuariosAPI.Models;

namespace UsuariosAPI.Services.Usuario

{
    public interface IUsuario
    {
        Task<ResponseModel<List<UsuarioModel>>> ListarUsuarios();
        Task<ResponseModel<UsuarioModel>> BuscarUsuarioPorId(int IdUsuario);

    }
}
