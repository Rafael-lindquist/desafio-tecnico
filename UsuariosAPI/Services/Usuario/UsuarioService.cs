using Microsoft.EntityFrameworkCore;
using UsuariosAPI.Data;
using UsuariosAPI.Dto.Usuario;
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
        public async Task<ResponseModel<UsuarioModel>> BuscarUsuarioPorId(int IdUsuario)
        {
            ResponseModel<UsuarioModel> resposta = new ResponseModel<UsuarioModel>();
            try
            {
                var usuario = await _context.Usuarios.FirstOrDefaultAsync(usuarioDb => usuarioDb.Id == IdUsuario);

                if (usuario == null)
                {
                    resposta.Mensagem = "Usuário não encontrado.";
                    return resposta;
                }

                resposta.Dados = usuario;
                resposta.Mensagem = "Usuário encontrado.";

                return resposta;
            }
            catch (Exception e)
            {
                resposta.Mensagem = e.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<UsuarioModel>> CadastrarUsuario(CadastrarUsuarioDto cadastrarUsuarioDto)
        {
            // Cadastrar usuarios com as informações do DTO + DateTime.Now
            ResponseModel<UsuarioModel> resposta = new ResponseModel<UsuarioModel>();

            try
            {
                var Usuario = new UsuarioModel
                {
                    Nome = cadastrarUsuarioDto.Nome,
                    Email = cadastrarUsuarioDto.Email,
                    Senha = cadastrarUsuarioDto.Senha,
                    DataDeRegistro = DateTime.Now
                };
                
                _context.Usuarios.Add(Usuario);
                await _context.SaveChangesAsync();
                
                resposta.Mensagem = "Usuário cadastrado com sucesso.";

                return resposta;

            }
            catch (Exception e)
            {
                resposta.Mensagem = e.Message;
                resposta.Status = false;
                return resposta;
            }
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
