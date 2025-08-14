using Microsoft.EntityFrameworkCore;
using UsuariosAPI.Data;
using UsuariosAPI.Models;

namespace UsuariosAPI.Services.Usuario
{
    public class UsuarioService : IUsuario
    {
        private readonly UsuariosDbContext _context;
        public UsuarioService(UsuariosDbContext context)
        {
            _context = context;
        }
        public Task<ResponseModel<UsuarioModel>> BuscarUsuarioPorId(int IdUsuario)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<List<UsuarioModel>>> ListarUsuarios()
        {
            ResponseModel<List<UsuarioModel>> resposta = new ResponseModel<List<UsuarioModel>>();
            try
            {
                var usuarios = await _context.Usuarios.ToListAsync();

                resposta.Dados = usuarios;
                resposta.Mensagem = "Usuários obtidos com sucesso.";

                return resposta;
            }
            catch (Exception e)
            {
                resposta.Mensagem = e.Message;
                resposta.Status = false;

                return resposta;
            }
        }
    }
}
