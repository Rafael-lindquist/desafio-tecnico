using UsuariosAPI.Models;

namespace UsuariosAPI.Services.Usuario
{
    public class UsuarioService : IUsuario
    {
        public Task<ResponseModel<UsuarioModel>> BuscarUsuarioPorId(int IdUsuario)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<UsuarioModel>>> ListarUsuarios()
        {
            throw new NotImplementedException();
        }
    }
}
